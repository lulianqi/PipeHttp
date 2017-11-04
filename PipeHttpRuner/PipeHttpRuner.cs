using MyPipeHttpHelper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PipeHttpRuner
{
    public partial class PipeHttpRuner : Form
    {
        public PipeHttpRuner()
        {
            InitializeComponent();
            MyInitializeComponent();
        }

        private List<PipeHttp> pipeList;
        private bool isPutResponseInStream;
        private FileStream responseFileStream;
        private string responseFilePath;
        private Timer getResponsTimer;
        private int nowGetResponsTimerIndex;

        private void MyInitializeComponent()
        {
            //Control.CheckForIllegalCrossThreadCalls = false;                                    //自行控制ui线程安全
            cb_responseType.SelectedIndex = 0;
            cb_editRequestMethod.SelectedIndex = 0;
            cb_editRequestEdition.SelectedIndex = 0;
            PipeHttp.GlobalRawRequest.CreateRawData(Encoding.UTF8, tb_rawRequest.Text);
            tb_pileHost_TextChanged(null, null);
            tb_pilePort_TextChanged(null, null);
            responseFilePath = System.Windows.Forms.Application.StartupPath + string.Format("\\Response\\response_{0}.txt", DateTime.Now.ToString("yyyy.MM.dd"));
            getResponsTimer = new Timer();
            getResponsTimer.Interval = 200;
            getResponsTimer.Tick += getResponsTimer_Tick;
            //getResponsTimer.Start();
        }

        void getResponsTimer_Tick(object sender, EventArgs e)
        {
            if(nowGetResponsTimerIndex!=0)
            {
                nowGetResponsTimerIndex = 0;
                if(lb_getResponseState.ForeColor==Color.LimeGreen)
                {
                    lb_getResponseState.ForeColor = Color.LightSalmon;
                }
                else
                {
                    lb_getResponseState.ForeColor = Color.LimeGreen;
                }
            }
        }

        private void ReportMyMessage(string mes)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new MethodInvoker(delegate { ReportMyMessage(mes); }));
            }
            else
            {
                rtb_dataRecieve.AddDate(mes, Color.Bisque, true);
            }
            
        }

        void ph_OnPipeInfoReport(string mes, int id)
        {
            if(this.InvokeRequired)
            {
                this.Invoke(new MethodInvoker(delegate { ph_OnPipeInfoReport(mes, id); }));
            }
            else
            {
                rtb_dataRecieve.AddDate(string.Format("ID:[{0}] : {1}", id, mes), Color.Black, true);
            }
            
        }

        void ph_OnPipeResponseReport(byte[] response, int id)
        {
            if (this.InvokeRequired)
            {
                //this.Invoke(new MethodInvoker(delegate { ph_OnPipeResponseReport(response, id); }));
                this.BeginInvoke(new Action<byte[],int>(ph_OnPipeResponseReport), new object[] { response, id });  //数据量过大会影响接收
            }
            else
            {
                if (isPutResponseInStream)
                {
                    responseFileStream.Write(response, 0, response.Length);
                    nowGetResponsTimerIndex++;
                }
                else
                {
                    string resposeStr = Encoding.UTF8.GetString(response);
                    //System.Diagnostics.Debug.Write(resposeStr);
                    rtb_dataRecieve.AddDate(resposeStr, Color.Maroon, false);
                }
            }  
        }

        void ph_OnPipeStateReport(PipeState state, int id)
        {
            if(this.InvokeRequired)
            {
                this.Invoke(new MethodInvoker(delegate { ph_OnPipeStateReport(state,id); }));
            }
            else
            {
                foreach(ListViewItem tempItem in lv_pipeList.Items)
                {
                    if(id==((PipeHttp)tempItem.Tag).Id)
                    {
                        switch (state)
                        {
                            case PipeState.Connected:
                                tempItem.BackColor = Color.LightGreen;
                                lv_pipeList.Update();
                                break;
                            case PipeState.Connecting:
                                tempItem.BackColor = Color.LightYellow;
                                lv_pipeList.Update();
                                break;
                            default:
                                tempItem.BackColor = Color.Plum;
                                lv_pipeList.Update();
                                break;
                        }
                        break;
                    }
                }
            }
        }

        private void AddPipeList(PipeHttp ph)
        {
            pipeList.Add(ph);
            ListViewItem lvt = new ListViewItem(new string[] { ph.Id.ToString(), ph.GetreReconectCount.ToString() });
            lvt.Tag = ph;
            lv_pipeList.Items.Add(lvt);
        }

        private void ClearPipeList()
        {
            foreach(PipeHttp tempPh in pipeList)
            {
                tempPh.Dispose();
            }
            foreach(ListViewItem tempLvt in lv_pipeList.Items)
            {
                tempLvt.Tag = null;
            }
            lv_pipeList.Items.Clear();
            pipeList.Clear();
        }

        private void PipeHttpRuner_Load(object sender, EventArgs e)
        {
            pipeList = new List<PipeHttp>();

            return;
            PipeHttp.GlobalRawRequest.ConnectHost = "www.baidu.com";
            PipeHttp.GlobalRawRequest.StartLine = "GET http://www.baidu.com/ HTTP/1.1";
            PipeHttp.GlobalRawRequest.Headers.Add("Content-Type: application/x-www-form-urlencoded");
            PipeHttp.GlobalRawRequest.Headers.Add(string.Format("Host: {0}", PipeHttp.GlobalRawRequest.ConnectHost));
            PipeHttp.GlobalRawRequest.Headers.Add("Connection: Keep-Alive");
            PipeHttp.GlobalRawRequest.CreateRawData();
            PipeHttp ph = new PipeHttp(100, true);
            ph.pipeRequest = PipeHttp.GlobalRawRequest;
            ph.OnPipeResponseReport += ph_OnPipeResponseReport;
            ph.OnPipeInfoReport += ph_OnPipeInfoReport;
            ph.Connect();
            ph.Send(100);
        }




        #region UI main event
        //添加管道
        private void bt_addPile_Click(object sender, EventArgs e)
        {
            int reConnectTime = 0;
            int pileAddCount = 0;
            if (int.TryParse(tb_reConTime.Text, out reConnectTime) && int.TryParse(tb_addTime.Text, out pileAddCount))
            {
                if (reConnectTime < 0)
                {
                    reConnectTime = 0;
                    tb_reConTime.Text = "0";
                    ReportMyMessage("ReConTime can not less than 0 ,so we set it 0");
                }
                if (pileAddCount < 1)
                {
                    pileAddCount = 1;
                    tb_addTime.Text = "1";
                    ReportMyMessage("PileAddCount can not less than 1 ,so we set it 1");
                }
                for (int i = 0; i < pileAddCount; i++)
                {
                    PipeHttp tempPipeHttp = new PipeHttp(reConnectTime, cb_responseType.SelectedIndex == 0);
                    tempPipeHttp.OnPipeInfoReport += ph_OnPipeInfoReport;
                    tempPipeHttp.OnPipeResponseReport += ph_OnPipeResponseReport;
                    tempPipeHttp.OnPipeStateReport += ph_OnPipeStateReport;
                    tempPipeHttp.pipeRequest = PipeHttp.GlobalRawRequest;
                    AddPipeList(tempPipeHttp);
                }
            }
            else
            {
                MessageBox.Show("illegal reConTime or addTime text");
            }
        }

        

        private void bt_connectAllPile_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem tempLvt in lv_pipeList.Items)
            {
                PipeHttp tempPh = (PipeHttp)tempLvt.Tag;
                //tempPh.IsReportResponse = cb_isRecieve.Checked;
                if (tempPh.Connect())
                {
                    //tempLvt.BackColor = Color.LightGreen;
                    //lv_pipeList.Update();
                }
                else
                {
                    ReportMyMessage(string.Format("ID:[{0}] connect fail", tempPh.Id.ToString()));
                }
            }
        }

        private void bt_sendRequest_Click(object sender, EventArgs e)
        {
            int sendCount = 1;
            if (int.TryParse(tb_RequstCount.Text, out sendCount))
            {
                if (!ck_saveResponse.Checked)
                {
                    if(pipeList.Count*sendCount>=1000)
                    {
                        if(MessageBox.Show("it show much response data if you want save it to stream file","response mode chose",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
                        {
                            ck_saveResponse.Checked = true;
                        }
                    }
                }
                foreach (PipeHttp tempPh in pipeList)
                {
                    if (cb_isAsynSend.Checked)
                    {
                        ReportMyMessage(string.Format("ID:[{0}] AsynSend  [{1}]", tempPh.Id.ToString(), DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss fff")));
                        tempPh.AsynSend(sendCount, 1, 0);
                    }
                    else
                    {
                        ReportMyMessage(string.Format("ID:[{0}] send start [{1}]", tempPh.Id.ToString(), DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss fff")));
                        tempPh.Send(sendCount);
                        ReportMyMessage(string.Format("ID:[{0}] send complete [{1}]", tempPh.Id.ToString(), DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss fff")));
                    }
                }
            }
            else
            {
                MessageBox.Show("illegal RequstCount text");
            }
        }

        //设置全局请求数据
        private void tb_rawRequest_Leave(object sender, EventArgs e)
        {
            PipeHttp.GlobalRawRequest.CreateRawData(Encoding.UTF8, tb_rawRequest.Text);
        }

        private void tb_pileHost_TextChanged(object sender, EventArgs e)
        {
            PipeHttp.GlobalRawRequest.ConnectHost = tb_pileHost.Text;
        }

        private void tb_pilePort_TextChanged(object sender, EventArgs e)
        {
            int tempCounectPort = 80;
            if (int.TryParse(tb_pilePort.Text, out tempCounectPort))
            {
                if (tempCounectPort > 65532)
                {
                    tempCounectPort = 80;
                    tb_pilePort.Text = "80";
                }
            }
            else
            {
                tb_pilePort.Text = "80";
            }
            PipeHttp.GlobalRawRequest.ConnectPort = tempCounectPort;
        }

        private void ck_saveResponse_CheckedChanged(object sender, EventArgs e)
        {
            if(ck_saveResponse.Checked)
            {
                pb_saveResponseStream.Visible = true;
                lb_getResponseState.Visible = true;
                getResponsTimer.Enabled = true;
                isPutResponseInStream = true;
                int tempFileTag=0;
                string tempBakPath=responseFilePath;
                while (File.Exists(tempBakPath))
                {
                    tempFileTag++;
                    if(tempFileTag==10000)
                    {
                        break;
                    }
                    tempBakPath = string.Format("{0}_bak{1}", responseFilePath, tempFileTag);
                }
                if (responseFilePath != tempBakPath)
                {
                    Directory.Move(responseFilePath, tempBakPath);
                }
                responseFileStream = new FileStream(responseFilePath, FileMode.OpenOrCreate, FileAccess.Write, FileShare.ReadWrite);
            }
            else
            {
                pb_saveResponseStream.Visible = false;
                lb_getResponseState.Visible = false;
                getResponsTimer.Enabled = false;
                isPutResponseInStream = false;
                responseFileStream.Dispose();
            }
        }

        private void pb_saveResponseStream_Click(object sender, EventArgs e)
        {
            if(responseFileStream!=null)
            {
                responseFileStream.Flush(true);
            }
        }
        //pictureBox change for all
        private void pictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            ((PictureBox)sender).BackColor = Color.Honeydew;
        }

        //pictureBox change for all
        private void pictureBox_MouseLeave(object sender, EventArgs e)
        {
            ((PictureBox)sender).BackColor = Color.Transparent;
        }
        
        #endregion

        #region edit request event
        private void bt_editAddHead_Click(object sender, EventArgs e)
        {
            lv_editRequestHeads.Items.Add(new ListViewItem(string.Format("{0}: {1}", tb_editHeadKey.Text, tb_editHeadVaule.Text)));
        }

        //请求编辑取消
        private void pb_editRequestCancel_Click(object sender, EventArgs e)
        {
            panel_editRequest.Visible = false;
        }

        //请求编辑确定
        private void pb_editRequestComfrim_Click(object sender, EventArgs e)
        {
            //get host 
            int tempStart = tb_editSartLine.Text.IndexOf("//");
            int tempEnd = 0;
            if (tempStart>0)
            {
                tempStart = tempStart + 2;
                tempEnd = tb_editSartLine.Text.IndexOf('/', tempStart);
                if (tempEnd > 0)
                {
                    tb_pileHost.Text = tb_editSartLine.Text.Substring(tempStart , tempEnd - tempStart);
                }
                else
                {
                    tb_pileHost.Text = tb_editSartLine.Text.Substring(tempStart );
                }
            }

            //get requeset
            PipeHttp.GlobalRawRequest.StartLine = string.Format("{0} {1} {2}", cb_editRequestMethod.Text, tb_editSartLine.Text, cb_editRequestEdition.Text);
            PipeHttp.GlobalRawRequest.Headers.Clear();
            foreach (ListViewItem tempHead in lv_editRequestHeads.Items)
            {
                PipeHttp.GlobalRawRequest.Headers.Add(tempHead.Text);
            }
            PipeHttp.GlobalRawRequest.EntityBody = tb_editRequestBody.Text;
            PipeHttp.GlobalRawRequest.CreateRawData();
            tb_rawRequest.Text = PipeHttp.GlobalRawRequest.GetRequestText();
            panel_editRequest.Visible = false;
        }

        //移除heads
        private void pb_editRequestDelHaeds_Click(object sender, EventArgs e)
        {
            lv_editRequestHeads.Items.Clear();
        }

        private void lv_editRequestHeads_DoubleClick(object sender, EventArgs e)
        {
            if(lv_editRequestHeads.SelectedItems!=null)
            {
                foreach(ListViewItem tempHead in lv_editRequestHeads.SelectedItems)
                {
                    lv_editRequestHeads.Items.Remove(tempHead);
                }
            }
        }

        private void pb_editRawRequest_Click(object sender, EventArgs e)
        {
            panel_editRequest.Visible = true;
        } 
        #endregion

        

        private void removeThisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(lv_pipeList.SelectedItems!=null)
            {
                foreach(ListViewItem tempItem in lv_pipeList.SelectedItems)
                {
                    PipeHttp tempPh = (PipeHttp)tempItem.Tag;
                    tempPh.OnPipeInfoReport -= ph_OnPipeInfoReport;
                    tempPh.OnPipeResponseReport -= ph_OnPipeResponseReport;
                    tempPh.OnPipeStateReport -= ph_OnPipeStateReport;
                    tempPh.Dispose();
                    pipeList.Remove(tempPh);
                    lv_pipeList.Items.Remove(tempItem);
                }
            }
        }

        private void removeAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem tempItem in lv_pipeList.Items)
            {
                PipeHttp tempPh = (PipeHttp)tempItem.Tag;
                tempPh.OnPipeInfoReport -= ph_OnPipeInfoReport;
                tempPh.OnPipeResponseReport -= ph_OnPipeResponseReport;
                tempPh.OnPipeStateReport -= ph_OnPipeStateReport;
                tempPh.Dispose();
                pipeList.Remove(tempPh);
                lv_pipeList.Items.Remove(tempItem);
            }
        }

        private void reconnectThisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lv_pipeList.SelectedItems != null)
            {
                foreach (ListViewItem tempItem in lv_pipeList.SelectedItems)
                {
                    PipeHttp tempPh = (PipeHttp)tempItem.Tag;
                    tempPh.ReConnect();
                }
            }
        }

        private void reconnectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem tempItem in lv_pipeList.Items)
            {
                PipeHttp tempPh = (PipeHttp)tempItem.Tag;
                tempPh.ReConnect();
            }
        }




    }
}
