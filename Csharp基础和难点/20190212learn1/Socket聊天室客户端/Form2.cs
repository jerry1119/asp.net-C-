using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Socket聊天室
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        Socket socket;
        private void button1_Click(object sender, EventArgs e)
        {
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint iPEndPoint = new IPEndPoint(IPAddress.Parse(txtIP.Text), int.Parse(txtPort.Text));
            socket.Connect(iPEndPoint);
            rtbInfo.AppendText("已连接服务器");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (socket != null)
            {
                byte [] byteSend = Encoding.Default.GetBytes(txtSend.Text);
                socket.Send(byteSend);
            }
            else
            {
                rtbInfo.AppendText("请连接服务器\r\n");
            }
        }
    }
}
