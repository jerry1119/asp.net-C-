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

namespace Socket聊天室客户端
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Socket socket;
        private void button1_Click(object sender, EventArgs e)
        {
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint iPEndPoint = new IPEndPoint(IPAddress.Parse(txtIP.Text), int.Parse(txtPort.Text));
            try
            {
                socket.Connect(iPEndPoint);
                setText("","已连接服务器: " + socket.RemoteEndPoint.ToString() , rtbInfo);
            }
            catch (Exception)
            {
                setText("","服务器连接失败", rtbInfo);
                return;
            }
            ThreadPool.QueueUserWorkItem(new WaitCallback((o)=> {
                Socket clientSocket = o as Socket;
                string clientIP = clientSocket.RemoteEndPoint.ToString();
                while (true)
                {
                    try
                    {
                        byte[] data = new byte[1024 * 1024];
                        int len = clientSocket.Receive(data);
                        if (len <= 0)
                        {
                            if (clientSocket.Connected)
                            {
                                clientSocket.Shutdown(SocketShutdown.Both);
                                clientSocket.Close();
                            }
                            setText(clientIP,"服务端正常断开连接",rtbInfo);
                            return;
                        }
                        string receiveData = Encoding.Default.GetString(data, 0, len);
                        setText(clientIP , receiveData, rtbInfo);
                    }
                    catch (Exception)
                    {
                        if (clientSocket.Connected)
                        {
                            clientSocket.Shutdown(SocketShutdown.Both);
                            clientSocket.Close();
                        }
                        setText(clientIP , "服务端异常断开连接", rtbInfo);
                        return;
                    }
                }
            }),socket);
        }

        private void setText(string userIp, string receiveData, RichTextBox rtbInfo)
        {
            if (rtbInfo.InvokeRequired)
            {
                rtbInfo.Invoke(new Action<string,string,RichTextBox>((Ip,str,rtb)=> {
                    rtb.AppendText(Ip + " :       " + DateTime.Now.ToString()+"\r\n" +str+ "\r\n");
                }),userIp,receiveData,rtbInfo);
            }
            else
            {
                rtbInfo.AppendText(userIp + ":      " + DateTime.Now.ToString() + "\r\n"+receiveData+"\r\n");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (socket!=null&&socket.Connected)
            {
                byte[] byteSend = Encoding.Default.GetBytes(txtSend.Text);
                socket.Send(byteSend);
                setText("我  ", txtSend.Text, rtbInfo);
                txtSend.Text = "";
            }
            else
            {
                setText("","请连接服务器",rtbInfo);
            }
        }
    }
}
