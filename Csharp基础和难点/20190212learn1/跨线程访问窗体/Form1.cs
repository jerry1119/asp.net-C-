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

namespace 跨线程访问窗体
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            //IPAddress ip = IPAddress.Parse(this.txtIP.Text);
                
            new Thread(()=>{
                while (true)
                {
                    if (label1.InvokeRequired)
                    {
                        //Invoke方法就是找到拥有这个控件的线程，让这个线程来执行指定的委托方法
                        label1.Invoke(new Action<Label,string>(setTime), label1,DateTime.Now.ToString());
                    }
                    else
                    {
                        label1.Text = DateTime.Now.ToString();
                    }
                }
            }).Start();
        }

        private void setTime(Label label,string time)
        {
            label.Text = time;
        }
    }
}
