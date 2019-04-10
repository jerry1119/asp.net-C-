using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Data;

namespace practice.CRUD
{
    /// <summary>
    /// Summary description for DeleteUser
    /// </summary>
    public class DeleteUser : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            int id;
            if (int.TryParse(context.Request.QueryString["id"], out id))
            {
                string connStr = ConfigurationManager.ConnectionStrings["SqlConn"].ConnectionString;
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = conn;
                        cmd.CommandText = "delete from UserInfo where UserId = @ID";
                        SqlParameter par = new SqlParameter("@ID",SqlDbType.Int);
                        par.Value = id;
                        cmd.Parameters.Add(par);
                        conn.Open();
                        if (cmd.ExecuteNonQuery() > 0)
                        {
                            context.Response.Redirect("UserInfoList.ashx");
                        }
                        else
                        {
                            context.Response.Redirect("Error.html");
                        }
                    }
                }
            }
            else
            {
                context.Response.Write("参数异常");

            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}