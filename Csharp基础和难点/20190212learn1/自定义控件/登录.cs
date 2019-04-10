using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 自定义控件
{
    public partial class 登录 : UserControl
    {
        public 登录()
        {
            InitializeComponent();
        }
        public event Action<object, userInfoEventArgs> userLogin;

        

        private void button1_Click(object sender, EventArgs e)
        {

            userInfoEventArgs user = new userInfoEventArgs(textBox1.Text,textBox2.Text,false);
            if (userLogin != null)
            {
                userLogin(this, user);
            }
            else
            {
                MessageBox.Show("没人订阅这个事件");
            }
        }

      
    }
    public class userInfoEventArgs : EventArgs
    {
        public userInfoEventArgs(string userName,string userPwd,bool loginIsOK) {
            this.userName = userName;
            this.userPwd = userPwd;
            this.loginIsOK = loginIsOK;
        }
        public string userName { get; set; }
        public string userPwd { get; set; }
        public bool loginIsOK { get; set; }
    }
}
