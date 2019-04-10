using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 日记demo
{
    class SqlHelper
    {
        private static readonly string connstr = ConfigurationManager.ConnectionStrings["Sqlconn"].ConnectionString;
        public static int ExcuteNonquery(string sql, CommandType type, params SqlParameter[] pars)
        {
            //用using相当于集成了try catch 在finally使用了释放的方法，也就是不用手动去conn.dispose()了,而这里的dispose方法中继承了close方法，所以close也不用写了

            using (SqlConnection conn = new SqlConnection(connstr))
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    if (pars != null)
                    {
                        cmd.Parameters.AddRange(pars);
                    }
                    cmd.CommandType = type;
                    try
                    {
                        conn.Open();
                    }
                    catch (Exception e)
                    {
                        System.Windows.Forms.MessageBox.Show("链接数据库失败");
                    }
                    return cmd.ExecuteNonQuery();

                }
            }
        }

        public static SqlDataReader ExcuteReader(string sql, CommandType type, params SqlParameter[] pars)
        {
            SqlConnection conn = new SqlConnection(connstr);

            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                if (pars != null)
                {
                    cmd.Parameters.AddRange(pars);
                }
                cmd.CommandType = type;
                try
                {
                    conn.Open();
                    return cmd.ExecuteReader(CommandBehavior.CloseConnection);//使用这个枚举表示将来在使用完reader后，在关闭reader的同时会将想关联的connection对象也关闭
                }
                catch 
                {
                    //如果有异常，将链接关闭
                    conn.Close();
                    conn.Dispose();
                    throw;  //把异常抛出
                    
                }                                                          
            }
        }

        public static DataTable ExcuteReader2(string sql, CommandType type, params SqlParameter[] pars)
        {
            using (SqlConnection conn = new SqlConnection(connstr))
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.CommandType = type;
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        DataTable dt = new DataTable();
                        dt.Load(reader);
                        return dt;
                    }
                }

            }


        }
    }
}
