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

namespace 存储过程实现转账
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int from = Convert.ToInt32(textBox1.Text.Trim());
            int to = Convert.ToInt32(textBox2.Text.Trim());
            double balance = double.Parse(textBox3.Text.Trim());
            
            string sql = "usp_transfer";
            SqlParameter[] pars = new SqlParameter[]{
                new SqlParameter("@from",SqlDbType.Int){ Value=from},//直接在创建对象的时候赋值，叫对象初始化器
                new SqlParameter("@to",SqlDbType.Int){ Value=to},
                new SqlParameter("@balance",SqlDbType.Money){ Value=balance},
                new SqlParameter("@result",SqlDbType.Int){ Direction= ParameterDirection.Output}
            };
           
            SqlHelper.ExcuteNonquery(sql, CommandType.StoredProcedure, pars);
            int result = Convert.ToInt32( pars[3].Value);
            if (result == 1)
            {
                MessageBox.Show("转账成功！！！");
            }
            else if (result == 2)
            {
                MessageBox.Show("转账失败！！");
            }
            else if (result == 3)
            {
                MessageBox.Show("余额不足");
            }
            else
            {
                MessageBox.Show("未知错误");
            }
        }
    }
}
