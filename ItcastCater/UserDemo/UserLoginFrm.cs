using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace UserDemo
{
    public partial class UserLoginFrm : Form
    {
        public UserLoginFrm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            //先把窗体上的数据拿到，然后校验数据的完整性
            if (string.IsNullOrEmpty(textUserName.Text.Trim()) ||
                 string.IsNullOrEmpty(textUserPwd.Text.Trim()))
            {
                MessageBox.Show("请输入正确的用户名和密码");
                return;
            }
            string connStr = ConnectionStringHelper.GetCurrentConnectionString();
          
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                //SqlCommand cmd = conn.CreateCommand()这句代码等同于
                //SqlCommand cmd = new SqlCommand;
                //cmd.CreateCommand = conn;
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    conn.Open();
                    //MessageBox.Show("开启成功");

                    // string sql = string.Format("select count(1) from UserInfo where UserName = '{0}' and UserPwd = '{1}'", textUserName.Text, textUserPwd.Text);
                    //解决SQL注入漏洞
                    string sql = string.Format("select count(1) from UserInfo where UserName = @UserName and UserPwd = @UserPwd");
                    //使用了参数后，给参数赋值
                    
                    cmd.Parameters.AddWithValue("@UserName",textUserName.Text);
                    cmd.Parameters.AddWithValue("@UserPwd",Md5Helper.EncryptString( textUserPwd.Text));
                    //参数化之后，将特殊字符编码化了  在查询语句中的特殊字符就被完全是当成特殊字符了
                    //cmd的职责就是执行sql脚本
                    cmd.CommandText = sql;
                    object result = cmd.ExecuteScalar();//返回查询结果的第一行第一列的值
                    int rows = Convert.ToInt32(result);
                    if (rows >= 1)
                    {
                        MessageBox.Show("登录成功");
                    }
                    else
                    {
                        MessageBox.Show("登录失败");
                    }
                }
            }
        }

        private void UserLoginFrm_Load(object sender, EventArgs e)
        {
            //textUserPwd.UseSystemPasswordChar = true;
        }
    }
}
