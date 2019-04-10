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

namespace _04SqlConnectionStringBiulderDemo
{
    public partial class MainFrm : Form
    {
        public MainFrm()
        {
            InitializeComponent();
            //这个类专门获取链接字符串
            SqlConnectionStringBuilder scsb = new SqlConnectionStringBuilder();
            //可以设默认值
            scsb.UserID = "sa";
            scsb.DataSource = ".";
            this.propGrid4connString.SelectedObject = scsb;
          
        }

        private void btnGetString_Click(object sender, EventArgs e)
        {
            string str = this.propGrid4connString.SelectedObject.ToString();

            Clipboard.Clear();//粘贴板
            Clipboard.SetText(str);
            MessageBox.Show(str);
        }
    }
}
