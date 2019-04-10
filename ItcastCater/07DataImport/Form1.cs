using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace _07DataImport
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSelectDataFile_Click(object sender, EventArgs e)
        {
            using  (OpenFileDialog ofd = new OpenFileDialog() )
            {
                //ofd.Filter = "文本文件|.txt";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    this.textFilePath.Text = ofd.FileName;
                    //导入数据工作
                    ImportData(ofd.FileName);
                    MessageBox.Show("导入成功");
                }
            }
        }
        //做数据导入工作
        private void ImportData(string fileName)
        {
            string temp = string.Empty;
            //第一步：=拿到文件
            //File.ReadAllLines();
            using (StreamReader reader = new StreamReader(fileName, Encoding.UTF8))
            {
                reader.ReadLine();//去掉第一行
                string connStr = ConfigurationManager.ConnectionStrings["sql2"].ConnectionString;
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        conn.Open();
                        while (!string.IsNullOrEmpty(temp = reader.ReadLine()))
                        {
                            string[] strs = temp.Split(',');
                            string sql = string.Format(@"
                         insert into stuInfo
                         (stuName,stuSex,stuBirthday,stuPhone)
                          values('{0}','{1}','{2}','{3}')", strs[1], strs[2], strs[3], strs[4]);
                            cmd.CommandText = sql;
                            cmd.ExecuteNonQuery();
                        } 
                    }
                }
            }
        }
    }
}
