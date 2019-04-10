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

namespace 日记demo
{
    public partial class addDiary : Form
    {
        public addDiary()
        {
            InitializeComponent();
        }

        private void addDiary_Load(object sender, EventArgs e)
        {
            List<User> list = GetUserList();
            //第一种方式，直接将user对象绑定到 item上，但是需要user类的tostring方法重写一下，改成输出user.username
            //foreach (var user in list)
            //{
            //    comboBox1.Items.Add(user);
            //}
            //第二种方式，将list直接绑定到控件上，在设置控件的 valuemember 和 displaymember即可
            comboBox1.DataSource = list;
            comboBox1.DisplayMember = "UserName";
            comboBox1.ValueMember = "ID";
        }
        //获取用户列表
        private List<User> GetUserList()
        {
            string sql = "select ID,UserName,Pwd from Users";
            List<User> list = new List<User>();
            using (SqlDataReader reader = SqlHelper.ExcuteReader(sql, CommandType.Text))
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        User user = new User();
                        user.ID = reader.GetInt32(0);
                        user.UserName = reader.IsDBNull(1) ? null: reader.GetString(1);
                        user.Pwd = reader.IsDBNull(2) ? null : reader.GetString(2);
                        list.Add(user);
                    }
                    
                }               
            }
            return list;
        }
        public event Action action;
        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
               int result = InsertDiary();
                if (result > 0)
                {
                    
                    MessageBox.Show("添加成功");
                    if (action != null)
                    {
                        action();
                    }
                   
                    this.Close();
                }
                else
                {
                    MessageBox.Show("添加失败");
                }
            }
        }

       

        private int InsertDiary()
        {
            User user = comboBox1.SelectedItem as User;
            string title = textBox1.Text.Trim();
            string content = richTextBox1.Text.Trim();
            if (string.IsNullOrEmpty(title))
            {
                MessageBox.Show("请填写标题");
                return 0;
            }
            if (string.IsNullOrEmpty(content))
            {
                MessageBox.Show("请填写类容");
                return 0;

            }
            string sql = "insert into DiaryInfo values(@Title,@Content,@CreateTime,@UserId)";
            SqlParameter[] pars = {
                    new SqlParameter("@Title",SqlDbType.NVarChar,50){ Value=title},
                    new SqlParameter("@Content",SqlDbType.NVarChar,50){ Value=content},
                    new SqlParameter("@CreateTime",SqlDbType.DateTime){ Value=DateTime.Now },
                    new SqlParameter("@UserId",SqlDbType.Int){ Value =user.ID }
                };
            return SqlHelper.ExcuteNonquery(sql,CommandType.Text,pars);
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
