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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //打开记录日记窗体
            addDiary FromaddDiary = new addDiary();
            //FromaddDiary.Show();
            //订阅子窗体的事件，当子窗体事件触发后执行loadInfo方法
            FromaddDiary.action += FromaddDiary_action;
            FromaddDiary.ShowDialog();
                                   
        }

        private void FromaddDiary_action()
        {
            loadInfo2();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            loadInfo2();           
        }
        private void loadInfo2()
        {
            string sql = "usp_UserDiary";
            DataTable dt = new DataTable();
            dt = SqlHelper.ExcuteReader2(sql, CommandType.StoredProcedure);
            dataGridView1.DataSource = dt;
        }
        private void loadInfo()
        {
            string sql = "select ID, Title,CreateTime, UserId from DiaryInfo";
            List<DiaryInfo> list = new List<DiaryInfo>();
            //在外面使用reader时最好是用using的方式，免得忘记close了
            using (SqlDataReader reader = SqlHelper.ExcuteReader(sql, CommandType.Text))
            {
                if (reader.HasRows)
                {
                    while (reader.Read()) // 一条条一直往下读数据，如果没有数据了，就会返回false
                    {
                        DiaryInfo diary  = new DiaryInfo();
                        diary.ID = reader.GetInt32(0);
                        diary.Title = reader.IsDBNull(1) ? null : reader.GetString(1);
                        //diary.CreateTime = reader.IsDBNull(2) ? null : reader.GetDateTime(2); //报错了，不会
                        diary.CreateTime = (DateTime)reader.GetValue(2);
                        diary.UserId = Convert.ToInt32(reader.GetValue(3));
                        list.Add(diary);
                    }
                }
            }           
            dataGridView1.DataSource = list;
        }
        //行焦点进入时间
        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
       {
            //User user = new User();
            ////获取当前选中的对象
            //DataGridViewRow currentrow = this.dataGridView1.Rows[e.RowIndex];
            ////获取当前行中绑定的user对象
            //user = currentrow.DataBoundItem as User;
            //textBox1.Text = user.UserName;
            //textBox2.Text = user.Pwd;
        }
    }
}
