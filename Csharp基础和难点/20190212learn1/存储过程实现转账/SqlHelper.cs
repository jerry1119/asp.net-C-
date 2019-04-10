using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 存储过程实现转账
{
    class SqlHelper
    {
        private static readonly string connstr = ConfigurationManager.ConnectionStrings["Sqlconn"].ConnectionString;
        public static int ExcuteNonquery(string sql,CommandType type,params SqlParameter [] pars)
        {
            using (SqlConnection conn = new SqlConnection(connstr))
            {
                using (SqlCommand command = new SqlCommand(sql,conn))
                {
                    if (pars != null)
                    {
                        command.Parameters.AddRange(pars);
                    }
                    command.CommandType = type;

                    conn.Open();
                    return command.ExecuteNonQuery();
                }
            }
               
        }

        public static object ExcuteScaler(string sql, CommandType type, params SqlParameter[] pars)
        {
            using (SqlConnection conn = new SqlConnection(connstr))
            {
                using (SqlCommand command = new SqlCommand(sql, conn))
                {
                    if (pars != null)
                    {
                        command.Parameters.AddRange(pars);
                    }
                    command.CommandType = type;
                    conn.Open();
                    return command.ExecuteScalar();
                }
            }
        }
 
    }
}
