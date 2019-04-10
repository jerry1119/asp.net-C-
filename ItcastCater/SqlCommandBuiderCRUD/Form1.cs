using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SqlCommandBuiderCRUD
{
    public partial class MainFrm : Form
    {
        public MainFrm()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string connStr = ConfigurationManager.ConnectionStrings["Sql"].ConnectionString;
            //为什么将配置文件和这里的Name都改为Sql就能取到数据了,而小写的sql就不行呢
            // MessageBox.Show(connStr);
            //创建一个 适配器类。
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                //修改的sql一定要跟 查询的sql脚本一致
                string strsql = "select UserId,UserName,UserPwd,DelFlag from UserInfo";
                using (SqlDataAdapter adapter = new SqlDataAdapter(strsql, conn))
                {
                    //拿到修改完之后的DataTable对象
                    DataTable dt = this.dgvUserInfoCRUD.DataSource as DataTable;
                    //把修改完的内存表dt  变化映射到数据库中的表变化
                    //SqlCommandBuilder  帮助我们的Adapter生成相关的CRUD SqlCommand
                    using (SqlCommandBuilder cmdBuilder = new SqlCommandBuilder(adapter))
                    {
                        adapter.Update(dt);
                    }
                }
            }
            MessageBox.Show("保存成功");
        }

        private void MainFrm_Load(object sender, EventArgs e)
        {
            string connStr = ConfigurationManager.ConnectionStrings["Sql"].ConnectionString;
            //为什么将配置文件和这里的Name都改为Sql就能取到数据了,而小写的sql就不行呢
            // MessageBox.Show(connStr);
            //创建一个 适配器类。
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string strsql = "select UserId,UserName,UserPwd,DelFlag from UserInfo";
                using (SqlDataAdapter adapter = new SqlDataAdapter(strsql, conn))
                {
                    DataTable dt = new DataTable();

                    adapter.Fill(dt);
                    dgvUserInfoCRUD.DataSource = dt;
                }
            }
        }
    }
}
