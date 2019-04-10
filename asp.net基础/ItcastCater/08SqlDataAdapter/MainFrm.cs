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

namespace _08SqlDataAdapter
{
    public partial class MainFrm : Form
    {
        public MainFrm()
        {
            InitializeComponent();
        }

        private void MainFrm_Load(object sender, EventArgs e)
        {
            //把UserInfo表中数据加载到 窗体的DataGridView
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
                    //把数据库中的数据填充到内存表Dt中。
                    //有多张表时可用DataSet
                    #region  DataSet用法
                    //string connSql = ConfigurationManager.ConnectionStrings["sql"].ConnectionString;
                    //string sql =
                    //   @"Select UserId, UserName, UserAge, DelFlag, CreateDate, UserPwd, LastErrorDateTime, ErrorTimes from userInfo;
                    //select * from AreaFull";

                    //using (SqlDataAdapter adapter = new SqlDataAdapter(sql, connSql))
                    //{
                    //    DataSet ds = new DataSet();//datatable
                    //    adapter.Fill(ds);
                    //    this.dgvUserInfo.DataSource = ds.Tables[0];
                    //} 
                    #endregion
                    //填充之前不需要打开数据库连接，Adapter会自动打开连接，并执行sql。
                    //Fill方法内部：
                    //-------SqlDataAdapter(strSql,conn)初始化后：
                    //1、先判断SqlConnection是否初始化，如果没有打开连接，那么打开连接。
                    //2、初始化一个Select：sql  SqlCommand对象。
                    //----------
                    //3、通过cmd对象执行以下，然后返回一个SqlDataReader对象。
                    //4、读取数据库中的数据，然后填充到DataTable上去
                    adapter.Fill(dt);
                    //把内存表显示到DataGridView上去。
                    //this.DgvUserInfo.DataSource = dt;//这种弱类型的数据不好
                    //封装成强类型
                    List<UserInfo> userList = new List<UserInfo>();
                    foreach (DataRow datarow in dt.Rows)
                    {
                        //Console.WriteLine(datarow["UserId"] + "   " + datarow[1]);
                        //将每一行数据封装成UserInfo对象
                        userList.Add(new UserInfo()
                        {
                            Id = int.Parse(datarow["UserId"].ToString()),//之前在这多打了个括号，一直出错。。
                            UserName = datarow["UserName"].ToString(),
                            UserPwd = datarow["UserPwd"].ToString()

                        });

                    }
                    this.DgvUserInfo.DataSource = userList;
                }
            }
        }
    }
}
