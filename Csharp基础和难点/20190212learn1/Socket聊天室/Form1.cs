using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Socket聊天室
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        List<Socket> SocketsList = new List<Socket>();
        private void button1_Click(object sender, EventArgs e)
        {
            //创建sokect对象
            Socket socket = new Socket( AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            IPAddress iP = IPAddress.Parse(txtIP.Text);
            IPEndPoint iPEndPoint = new IPEndPoint(iP, int.Parse(txtPort.Text));
            //给绑定绑定ip地址和端口号
            socket.Bind(iPEndPoint);
            //开始侦听
            socket.Listen(10);
            rtbInfo.AppendText("服务器已打开\r\n");
            //创建一个新代理socket对象为新创建的链接，也就是接收到一个链接进来，就会创建一个，会阻塞线程，直到有用户链接进来才会往下走
            //Socket serverSocket = socket.Accept();
            //手动创建并开启线程：
            //new Thread(()=> {
            //    while (true)
            //    {
            //        Socket serverSocket = socket.Accept();
            //    }
            //}).Start();
            //用线程池
            ThreadPool.QueueUserWorkItem(new WaitCallback((o)=> {
                Socket serverSocket = o as Socket;
                while (true)
                {
                    Socket proxSoket = serverSocket.Accept();
                    SetText(proxSoket.RemoteEndPoint.ToString(), "客服端已连接",rtbInfo);
                    SocketsList.Add(proxSoket);
                    //不停接收用户发来的消息,这个方法也会阻塞线程，也放到线程池中
                    ThreadPool.QueueUserWorkItem(new WaitCallback( this.ReceiveData), proxSoket);
                }
            }),socket);
        }
        /// <summary>
        /// 接收数据的方法
        /// </summary>
        /// <param name="state">代理socket对象</param>
        private void ReceiveData(object state)
        {
            Socket pSocket = state as Socket;
            string ClientIP = pSocket.RemoteEndPoint.ToString(); //拿到用户ip
            while (true)
            {
                try
                {
                    byte[] byteInfo = new byte[1024 * 1024];
                    int len = pSocket.Receive(byteInfo);
                    
                    //如果接收到的信息长度为0，
                    if (len <= 0)
                    {
                        //用户正常退出
                        SocketsList.Remove(pSocket);
                        
                        if (pSocket.Connected)
                        {
                            pSocket.Shutdown(SocketShutdown.Both);
                            pSocket.Close();

                            SetText(ClientIP , " 正常断开连接", rtbInfo);
                        }
                        else
                        {
                            SetText(ClientIP , " 用户异常断开连接1", rtbInfo);
                        }
                        return;  // return的作用是线程退出
                    }
                    string str = Encoding.Default.GetString(byteInfo, 0, len);
                    SetText(ClientIP , str, rtbInfo);
                }
                catch (Exception)
                {
                    //客服端异常退出
                    SocketsList.Remove(pSocket);
                    if (pSocket.Connected)
                    {
                        //string ClientIP = pSocket.RemoteEndPoint.ToString(); //拿到用户ip
                        pSocket.Shutdown(SocketShutdown.Both);
                        pSocket.Close();

                        SetText(ClientIP , " 异常断开连接", rtbInfo);
                    }
                    else
                    {
                        SetText(ClientIP," 用户异常断开连接2", rtbInfo);
                    }
                    return;  // return的作用是线程退出
                }
            }
        }
        /// <summary>
        /// 将信息显示到主窗体上
        /// </summary>
        /// <param name="str">要显示的信息</param>
        /// <param name="rtbInfo">显示信息的窗体控件对象</param>
        private void SetText(string userIp, string receiveData, RichTextBox rtbInfo)
        {
            if (rtbInfo.InvokeRequired)
            {
                rtbInfo.Invoke(new Action<string, string, RichTextBox>((Ip, str, rtb) => {
                    rtb.AppendText(Ip + " :       " + DateTime.Now.ToString() + "\r\n" + str + "\r\n");
                }), userIp, receiveData, rtbInfo);
            }
            else
            {
                rtbInfo.AppendText(userIp + ":      " + DateTime.Now.ToString() + "\r\n" + receiveData + "\r\n");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (SocketsList.Count > 0)
            {
                for (int i = 0; i < SocketsList.Count; i++)
                {
                    byte[] byteSend = Encoding.Default.GetBytes(txtSend.Text);
                    SocketsList[i].Send(byteSend);
                }
                SetText("我  ", txtSend.Text, rtbInfo);
                txtSend.Text = "";
            }
            else
            {
                SetText("提示","当前没有用户链接",rtbInfo);
            }
        }
    }
}
