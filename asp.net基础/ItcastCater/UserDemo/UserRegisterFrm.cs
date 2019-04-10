using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

namespace UserDemo
{
    public partial class UserRegisterFrm : Form
    {
        public UserRegisterFrm()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainFrm frm = new MainFrm();
            frm.Show();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textRegisterUserName.Text.Trim()) ||
                string.IsNullOrEmpty(textRegisterPwd.Text.Trim()))
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
                        string username =  textRegisterUserName.Text;
                        string password = Md5Helper.EncryptString( textRegisterPwd.Text);
                        string sqlIntsert = string.Format("insert into  UserInfo( UserName,UserPwd,DelFlag) values('{0}','{1}',0)",username,password);
                        cmd.CommandText = sqlIntsert;
                       int a =  cmd.ExecuteNonQuery();//执行一个非查询语句，别忘了加这句,我这里给它赋值到a，只是为了测试下返回什么
                    //MessageBox.Show(a.ToString());//这里给我返回的结果是 1 意思应该是执行成功了一条非查询语句

                    //MessageBox.Show("开启成功");
                    // string sql = string.Format("insert into  UserInfo( UserName,UserPwd) values('{0}','{1}')", textRegisterUserName.Text, textRegisterPwd.Text);
                    /* string sql = string.Format("select count(1) from UserInfo where UserName = '{0}' ",textRegisterUserName.Text);
                     cmd.CommandText = sql;
                     object result = cmd.ExecuteScalar();
                     MessageBox.Show(result.ToString());
                     */
                    //object result = cmd.ExecuteScalar();
                    //int rows = Convert.ToInt32(result);
                    //if (rows >= 1)
                    //{
                    //    MessageBox.Show("登录成功");
                    //}
                    //else
                    //{
                    //    MessageBox.Show("登录失败");
                    //}

                }
               }

            MessageBox.Show("注册成功");
        }
    }
}
