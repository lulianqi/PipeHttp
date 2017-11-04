#define TESTMODE
#define THREADPOOLMODE

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyPipeHttpHelper
{
    public class PipeHttp:IDisposable
    {
        public static RawHttpRequest GlobalRawRequest = new RawHttpRequest();
        private static int idIndex = 0;
        private static object idIndexLock = new object();

        static PipeHttp()
        {
        }

        public RawHttpRequest pipeRequest = new RawHttpRequest();

        public delegate void delegatePipeInfoReport(string mes, int id);
        public delegate void delegatePipeResponseOut(byte[] response, int id);
        public delegate void delegatePipeStateOut(PipeState state, int id);

        public event delegatePipeInfoReport OnPipeInfoReport;
        public event delegatePipeResponseOut OnPipeResponseReport;
        public event delegatePipeStateOut OnPipeStateReport;

        private object tag;                                 //用于双向绑定
        private int id = 0;                                 //PipeHttp ID
        private PipeState state = PipeState.NotConnected;   //仅表示当前PipeHttp Socket状态，当前PipeHttp可能创建多个Socket连接，之前创建的状态不再维护。
        private Socket mySocket;                            //管道连接
        private bool isReportResponse = false;              //是否将返回数据推送给上层应用
        private int reConectCount = 0;                      //在指定数目后更新管道(默认0表示一直使用初始管道)（因为部分nginx都有100的限制），设置后会让单条管道发送性能下降
        private int nowConectCount = 0;
        Thread reciveThread;                                //接收线程
        private IPAddress connctHost;                       //链接地址
        private int reciveBufferSize = 1024 * 128;          //接收缓存，当需要大量PipeHttp时请设置较小值（当isReportResponse为false该值无效）


        public PipeHttp():this(0,true)
        {
        }

        /// <summary>
        /// initialization PipeHttp
        /// </summary>
        /// <param name="yourReConectCount">ReConect Count</param>
        /// <param name="yourIsReportResponse">is report response</param>
        public PipeHttp(int yourReConectCount, bool yourIsReportResponse)
        {
            lock (idIndexLock)
            {
                id = idIndex;
                idIndex++;
            }
            reConectCount = yourReConectCount;
            isReportResponse = yourIsReportResponse;
            //Connect();
        }

        /// <summary>
        /// get or set Tag
        /// </summary>
        public Object Tag
        {
            get { return tag; }
            set { tag = value; }
        }

        /// <summary>
        /// get the pipe id 【获取当前管道Id】
        /// </summary>
        public int Id
        {
            get { return id; }
        }

        /// <summary>
        /// get or set ReciveBufferSize 【连接前设置有效】
        /// </summary>
        public int ReciveBufferSize
        {
            get { return reciveBufferSize; }
            set { reciveBufferSize = value; }
        }

        /// <summary>
        /// get  IsReportResponse 【仅能在初始化时设置】
        /// </summary>
        public bool IsReportResponse
        {
            get { return isReportResponse; }
        }

        /// <summary>
        /// get now pepe state 
        /// </summary>
        public PipeState GetState
        {
            get { return state; }
        }

        /// <summary>
        /// get now reConectCount (if it is 0 that is say it will never reconnect)【仅能在初始化时设置，如果为0表示不会进行重连】
        /// </summary>
        public int GetreReconectCount
        {
            get { return reConectCount; }
        }

        private void ReportPipeInfo(string mes)
        {
            if (OnPipeInfoReport!=null)
            {
                OnPipeInfoReport(mes, id);
            }
        }

        private void ChangePipeState(PipeState yourState)
        {
            state = yourState;
            if(OnPipeInfoReport!=null)
            {
                OnPipeStateReport(state, id);
            }
        }

        private void ReportPipeResponse(byte[] bytes)
        {
            if (OnPipeResponseReport != null)
            {
                OnPipeResponseReport(bytes, id);
            }
        }

        /// <summary>
        /// connect the pipe (if it is connected,it will use old socket) 【对于已经连接的pipe不会再次连接，而由于默认无心跳保持机制，可能存在实际已经断开，而tcp层依然认为连接存在的情况，可以发送任意数据确认是否有效，或者直接断开再次连接】
        /// </summary>
        /// <returns>is sucess</returns>
        public bool Connect()
        {
            ChangePipeState(PipeState.Connecting);
            if (mySocket != null)
            {
                if (mySocket.Connected)
                {
                    ChangePipeState(PipeState.Connected);
                    return true;
                }
            }
            if (string.IsNullOrEmpty(pipeRequest.ConnectHost))
            {
                ChangePipeState( PipeState.DisConnected);
                return false;
            }
            try
            {
                if (!IPAddress.TryParse(pipeRequest.ConnectHost, out connctHost))
                {
                    System.Net.IPHostEntry host = System.Net.Dns.GetHostEntry(pipeRequest.ConnectHost);
                    connctHost = host.AddressList[0];
#if TESTMODE
                    System.Diagnostics.Debug.WriteLine("-------------------------------------");
                    System.Diagnostics.Debug.WriteLine("Dns back");
                    foreach (var tempIp in host.AddressList)
                    {
                        System.Diagnostics.Debug.WriteLine(tempIp.ToString());
                    }
                    System.Diagnostics.Debug.WriteLine("-------------------------------------");
#endif
                }
                mySocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                //mySocket.NoDelay = true;
                IPEndPoint hostEndPoint = new IPEndPoint(connctHost, pipeRequest.ConnectPort);
                mySocket.Connect(hostEndPoint);
                if (isReportResponse)
                {
                    //ThreadPool.QueueUserWorkItem(new WaitCallback(ReceviData), mySocket);  //这里使用线程池将失去部分对线程的控制能力(创建及启动会自动被延迟)
                    reciveThread = new Thread(new ParameterizedThreadStart(ReceviData));
                    reciveThread.IsBackground = true;
                    reciveThread.Start(mySocket);
                }
                ReportPipeInfo("connect ok");
            }
            catch(Exception ex)
            {
                ReportPipeInfo(ex.Message);
                ChangePipeState( PipeState.DisConnected);
                return false;
            }
            ChangePipeState( PipeState.Connected);
            return true;
        }

        /// <summary>
        /// ReConnect （it will creat new socket but the old will not be stoped  immediately ）【无论并不会马上结束上一个TCP连接（链接会在指定时间内接收不到任何消息后自动被关闭，接收线程也会一起结束），就是说上一个链接依然会接收到未到达的回包】
        /// </summary>
        public void ReConnect()
        {
            if (mySocket != null)
            {
                mySocket = null; //置空mySocket让Connect可以开启新连接
                ReportPipeInfo("ReConnect");
                if (isReportResponse)
                {
                    reciveThread.Name = "close";
                }
            }
            Connect();
        }

        /// <summary>
        /// DisConnect （now socket will be stoped  immediately）【会立刻关闭当前链接并放弃任何未到达的数据包】
        /// </summary>
        public void DisConnect()
        {
            ReportPipeInfo("DisConnect");
            mySocket.Close();
            if (isReportResponse)
            {
                reciveThread.Name = "close";
                reciveThread.Abort();
            }
            ChangePipeState(PipeState.DisConnected);
        }

        /// <summary>
        /// send one raw http
        /// </summary>
        /// <param name="requestRawBytes">raw data</param>
        public void SendOne(byte[] requestRawBytes)
        {
            if (requestRawBytes==null)
            {
                return;
            }
            if (mySocket == null)
            {
                ReportPipeInfo("the pipe is not connect");
                return;
            }
            if (!mySocket.Connected)
            {
                ReportPipeInfo("the pipe is dis connect");
                return;
            }
            try
            {
                mySocket.Send(requestRawBytes);
                if (reConectCount > 0)
                {
                    nowConectCount++;
                    if (nowConectCount >= reConectCount)
                    {
                        nowConectCount = 0;
                        ReConnect();
                    }
                }
            }
            catch (Exception ex)
            {
                ReportPipeInfo(ex.Message);
                ReConnect();
            }
        }

        /// <summary>
        /// send one inner http (you can set it by PipeRequest)【使用内置的PipeRequest，如果要控制发送内容，请设置PipeRequest】
        /// </summary>
        public void SendOne()
        {
            SendOne(pipeRequest.RawRequest);
        }

        /// <summary>
        /// send inner http with sendCount
        /// </summary>
        /// <param name="sendCount">send Count</param>
        public void Send(int sendCount)
        {
            for (int i = 0; i < sendCount; i++)
            {
                SendOne();
            }
        }

        /// <summary>
        /// send asyn【异步发送，(由此触发的重连，新线程的创建都会使用异步的方式)如果要更新管道请设置reConectCount】
        /// </summary>
        /// <param name="times">发多少组</param>
        /// <param name="repeatTimes">每组多少次</param>
        /// <param name="waitTime">每组延时多少</param>
        public void AsynSend(int times, int repeatTimes, int waitTime)
        {
            ThreadPool.QueueUserWorkItem(new WaitCallback((object ob) =>
            {
                for (int i = 0; i < ((int[])ob)[0]; i++)
                {
                    Send(((int[])ob)[1]);
                    if (((int[])ob)[2] > 0)
                    {
                        if (((int[])ob)[2] > 0)
                        {
                            Thread.Sleep(((int[])ob)[2]);
                        }
                    }
                }
                ReportPipeInfo("asynSendThread complete");
            }), new int[] { times, repeatTimes, waitTime });
        }

        public void AsynSendEx(int times, int repeatTimes, int waitTime)
        {
            Thread asynSendThread = new Thread(new ParameterizedThreadStart(
                (object ob) =>
                {
                    for (int i = 0; i < ((int[])ob)[0]; i++)
                    {
                        Send(((int[])ob)[1]);
                        if (((int[])ob)[2] > 0)
                        {
                            if (((int[])ob)[2] > 0)
                            {
                                Thread.Sleep(((int[])ob)[2]);
                            }
                        }
                    }
                    ReportPipeInfo("asynSendThread complete");
                }));
            asynSendThread.IsBackground = true;
            asynSendThread.Start(new int[] { times, repeatTimes, waitTime });
        }

        private void ReceviData(object yourSocket)
        {
            byte[] nowReciveBytes = new byte[1024 * 128];
            Socket nowSocket = (Socket)yourSocket;
            int receiveCount = 0;
            int freeTime = 0;
            while (true)
            {
                if (!nowSocket.Connected)
                {
                    ReportPipeInfo("the tcp is disconnect");
                    ChangePipeState(PipeState.DisConnected);
                    break;
                }
                try
                {
                    receiveCount = nowSocket.Receive(nowReciveBytes);
                    if (receiveCount > 0)
                    {
                        freeTime = 0;
                        byte[] tempOutBytes = new byte[receiveCount];
                        Array.Copy(nowReciveBytes, tempOutBytes, receiveCount);
                        ReportPipeResponse(tempOutBytes);
                        //System.Diagnostics.Debug.WriteLine(string.Format("\r\n----------------------{0}------------------------", DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss fff")));
                        //string respose = Encoding.UTF8.GetString(nowReciveBytes, 0, receviCount);
                        //System.Diagnostics.Debug.Write(respose);
                        //Thread.Sleep(10);
                    }
                    else
                    {
                        //超过40S没有数据
                        if (freeTime < 200)
                        {
                            freeTime++;
                        }
                        else if (Thread.CurrentThread.Name == "close")
                        {
                            ReportPipeInfo("the abandon socket receive task close by no data received");
#if TESTMODE
                            System.Diagnostics.Debug.WriteLine("receive task close by no data received");
#endif
                            nowSocket.Close();  //该链接是一个被抛弃的连接，关闭他不要改变当前PipeHttp状态（因为被遗弃前可能还有未接收完成的数据所以没有马上关闭）
                            break;
                        }
                        Thread.Sleep(freeTime);
                    }
                }
                catch (System.Threading.ThreadAbortException)
                {
                    ReportPipeInfo("Applications active close ");//应用程序主动关闭接收线程
                    nowSocket.Close();
                    if (!(Thread.CurrentThread.Name == "close"))
                    {
                        ChangePipeState(PipeState.DisConnected);
                    }
                    break;
                }
                catch (Exception ex)
                {
                    ReportPipeInfo(ex.Message);//应用程序被动关闭接收线程
                    nowSocket.Close();
                    if (!(Thread.CurrentThread.Name == "close"))
                    {
                        ChangePipeState(PipeState.DisConnected);
                    }
                    break;
                }
                finally
                {
                    
                }
            }
        }

        /// <summary>
        /// Dispose  【实现【IDisposable】强烈建议结束前调用】
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
        }

        protected void Dispose(bool disposing)
        {
            if (mySocket!=null)
            {
                mySocket.Close();
                mySocket.Dispose();
                mySocket = null;
            }
            if (reciveThread!=null)
            {
                reciveThread.Abort();
                reciveThread = null;
            }
        }

        //如果没有非托管资源的释放，需谨慎添加析构函数，其可能影响GC性能
        ~PipeHttp()
        {
            Dispose(false);
        }
    }
}
