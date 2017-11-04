using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPipeHttpHelper
{
    /// <summary>
    /// Connecte state 【管线连接状态】
    /// </summary>
    public enum PipeState
    {
        Connected,                //【已连接】
        DisConnected,             //【断开连接】
        NotConnected,             //【】
        Connecting
    }
}
