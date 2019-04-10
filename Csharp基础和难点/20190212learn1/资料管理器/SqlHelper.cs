using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 资料管理器
{
    public  class SqlHelper
    {
        private static readonly string connstr = ConfigurationManager.ConnectionStrings["Sql"].ConnectionString;
        //读数据返回sqldatareader
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
                    return cmd.ExecuteReader(CommandBehavior.CloseConnection);
                }
                catch (Exception)
                {
                    conn.Close();
                    throw;
                }
            }
           
        }

        public static object ExcuteScaler(string sql, CommandType type, params SqlParameter[] pars)
        {
            using (SqlConnection conn = new SqlConnection (connstr))
            {
                using (SqlCommand cmd = new SqlCommand(sql,conn))
                {
                    cmd.CommandType = type;
                    if (pars != null)
                    {
                        cmd.Parameters.AddRange(pars);
                    }
                    conn.Open();
                    return cmd.ExecuteScalar();
                }
            }
        }

        public static int ExcuteNoquery(string sql, CommandType type, params SqlParameter [] pars)
        {
            using (SqlConnection conn = new SqlConnection(connstr))
            {
                using (SqlCommand cmd = new SqlCommand(sql,conn))
                {
                    if (pars != null)
                    {
                        cmd.Parameters.AddRange(pars);
                    }
                    cmd.CommandType = type;
                    conn.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
        }

        //查询数据返回datatable
        public static DataTable DataAdapter(string sql, CommandType type, params SqlParameter[] pars)
        {
            using (SqlDataAdapter adapter = new SqlDataAdapter(sql, connstr))
            {
                if (pars != null)
                {
                    adapter.SelectCommand.Parameters.AddRange(pars);
                }
                adapter.SelectCommand.CommandType = type;
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }
        }
    }
}
