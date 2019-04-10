using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 资料管理器
{
    public partial class test : Form
    {
        public test()
        {
            InitializeComponent();
        }

        private void test_Load(object sender, EventArgs e)
        {
            string sql = "select * from studentInfo";
            DataTable dt = new DataTable();
            dt = SqlHelper.DataAdapter(sql,CommandType.Text);
            dataGridView1.DataSource = dt;
        }
    }
}
