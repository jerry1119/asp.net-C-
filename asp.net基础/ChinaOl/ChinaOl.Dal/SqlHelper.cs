using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace ChinaOl.Dal
{
    public class SqlHelper
    {
        private static readonly string connStr = ConfigurationManager.ConnectionStrings["SqlConn"].ConnectionString;
        public static DataTable GetDataTable(string sql,CommandType type,params SqlParameter[]pars)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                using (SqlDataAdapter adapter = new SqlDataAdapter(sql, conn))
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
        public static int ExecuteNonquery(string sql, CommandType type, params SqlParameter[] pars)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
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
        public static object ExcuteScalar(string sql, CommandType type, params SqlParameter[] pars)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    if (pars != null)
                    {
                        cmd.Parameters.AddRange(pars);
                    }
                    cmd.CommandType = type;
                    conn.Open();
                    return cmd.ExecuteScalar();
                }
            }
        }
    }
}
