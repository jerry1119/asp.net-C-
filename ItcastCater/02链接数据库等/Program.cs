using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _02链接数据库等
{
    class Program
    {
        static void Main(string[] args)
        {

            #region 第一个链接对象
            //链接字符串：就是我们的链接进行设的字符串
            //server：表示链接的服务，可以用 .  机器名  ip地址等表示
            //uid：sqlserver用户名  pwd：密码
            //database表示要连接的数据库
            //string connStr = "server =.;uid = sa;pwd = 123456;database=ChinaOlSysDb";
            //SqlConnection conn = new SqlConnection(connStr);
            ////打开数据库
            //conn.Open();
            //Console.WriteLine("打开数据库");

            //Thread.Sleep(3000);//停3s
            //conn.Close();
            //conn.Dispose();//释放
            //Console.WriteLine("数据库关闭了"); 

            #endregion
            #region 02SqlCommand对象
            ////连接上数据库，然后往数据库中添加一条数据
            //string connStr = "server = (local);database = ChinaOlSysDb;uid = sa;pwd = 123456";
            //这种写法也行
            //string connStr = "Data Source =(local);Initial Catalog = ChinaOlSysDb;UserId=sa;Password=123456 ";
            ////根据字符串创建一个连接对象
            //SqlConnection conn = new SqlConnection(connStr);
            ////创建一个Sql命令对象
            //SqlCommand cmd = new SqlCommand();
            ////给命令对象指定链接对象
            //cmd.Connection = conn;
            //conn.Open();//别忘了
            ////此属性放我们的Sql脚本
            //cmd.CommandText = "insert into UserInfo( UserName, UserAge) values(N'瓜皮', 23)";

            //cmd.ExecuteNonQuery();//执行一个非查询Sql语句，返回受影响的行数

            //conn.Close();//不要忘记关闭数据库链接
            //     Console.ReadKey();
            #endregion

            Console.ReadKey();
        }
    }
}
