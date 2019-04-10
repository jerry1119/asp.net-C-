using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Configuration;

namespace practice.CRUD
{
    /// <summary>
    /// Summary description for AddUser
    /// </summary>
    public class AddUser : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            //1:接收表单数据
          string userName=  context.Request.Form["txtName"];
            string userPwd = context.Request.Form["txtPwd"];
            string userMail = context.Request.Form["txtMail"];
            //2：连接数据库，构建相应的SQL语句，最后执行SQl语句
            string connStr = ConfigurationManager.ConnectionStrings["SqlConn"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "insert into UserInfo(UserName,UserPwd,Email,RegTime)values(@UserName,@UserPwd,@Email,@RegTime)";
                    //cmd.Parameters.AddWithValue("@UserName",textUserName.Text);
                    SqlParameter[] pars = {
                        new SqlParameter("@UserName",SqlDbType.NVarChar,32),
                        new SqlParameter("@UserPwd",SqlDbType.NVarChar,32),
                        new SqlParameter("@Email",SqlDbType.NVarChar,32),
                        new SqlParameter("RegTime",SqlDbType.DateTime)
                    };
                    pars[0].Value = userName;
                    pars[1].Value = userPwd;
                    pars[2].Value = userMail;
                    pars[3].Value = DateTime.Now;
                    cmd.Parameters.AddRange(pars);//别忘了复值后追加到Sqlcommand中
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