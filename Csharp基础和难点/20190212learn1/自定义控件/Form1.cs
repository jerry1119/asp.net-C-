using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 自定义控件
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            登录1.userLogin += Login_userLogin;            
        }

        private void Login_userLogin(object arg1, userInfoEventArgs e)
        {


            if (e.userName == "123" && e.userPwd == "123")
            {
                登录1.BackColor = Color.Green;
            }
            else
            {
                登录1.BackColor = Color.Red;
                
            }
        }

      
    }
}
