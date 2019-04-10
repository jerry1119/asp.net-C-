using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace practice.CRUD
{
    /// <summary>
    /// Summary description for ShowEdit
    /// </summary>
    public class ShowEdit : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";
            int id;
            if (int.TryParse(context.Request.QueryString["id"], out id))
            {
                string connStr = ConfigurationManager.ConnectionStrings["SqlConn"].ConnectionString;
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter("select*from UserInfo where UserId = @ID", conn))
                    {
                        SqlParameter par = new SqlParameter("@ID", SqlDbType.Int);
                        par.Value = id;
                        adapter.SelectCommand.Parameters.Add(par);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        if (dt.Rows.Count > 0)
                        {
                            //读取模板文件替换占位符
                            string filePath = context.Request.MapPath("ShowEditUser.html");
                            string fileContent = File.ReadAllText(filePath);
                            fileContent = fileContent.Replace("$name",dt.Rows[0]["UserName"].ToString()).Replace("$pwd",dt.Rows[0]["UserPwd"].ToString()).Replace("$mail",dt.Rows[0]["Email"].ToString()).Replace("$id",dt.Rows[0]["UserId"].ToString());
                            context.Response.Write(fileContent);
                        }
                        else
                        {
                            context.Response.Redirect("查无此人");
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