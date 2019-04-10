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
    /// Summary description for EditUser
    /// </summary>
    public class EditUser : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            //1:接收表单数据
            string userName = context.Request.Form["txtName"];
            string userPwd = context.Request.Form["txtPwd"];
            string userMail = context.Request.Form["txtMail"];
            int id = Convert.ToInt32(context.Request.Form["txtId"]);//接收隐藏域的值
            //2：连接数据库，构建相应的SQL语句，最后执行SQl语句
            string connStr = ConfigurationManager.ConnectionStrings["SqlConn"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "update UserInfo set UserName=@UserName,UserPwd=@UserPwd,Email=@Email where UserId=@ID";
                    SqlParameter[] pars = {
                        new SqlParameter("@UserName",SqlDbType.NVarChar,32),
                        new SqlParameter("@UserPwd",SqlDbType.NVarChar,32),
                        new SqlParameter("@Email",SqlDbType.NVarChar,32),
                        new SqlParameter("@ID",SqlDbType.Int)
                    };
                    pars[0].Value = userName;
                    pars[1].Value = userPwd;
                    pars[2].Value = userMail;
                    pars[3].Value = id;
                    cmd.Parameters.AddRange(pars);
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

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}