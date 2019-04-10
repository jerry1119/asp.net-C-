using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace practice.CRUD
{
    /// <summary>
    /// Summary description for ShowDetail
    /// </summary>
    public class ShowDetail : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";
            int id;
            //TryParse尝试将第一个参数转换成整形，如果能转换那么该方法返回true，并且将转换成功
            //的整形数字赋值给第二个参数，否则转化不成功那么该方法返回false；
            //这样做的目的是防止用户在浏览器地址栏id后面填写其他类型的数据，浏览器报错泄露信息
            if (int.TryParse(context.Request.QueryString["id"], out id))
            {
                //根据接收到的ID查询数据表中相应的记录
                string connStr = ConfigurationManager.ConnectionStrings["SqlConn"].ConnectionString;
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter("select * from UserInfo where UserId = @ID",conn))
                    {

                        //adapter.SelectCommand.CommandText = "select*from UserInfo where UserId=@ID";
                        SqlParameter par = new SqlParameter("@ID", SqlDbType.Int);
                        par.Value = id;
                        adapter.SelectCommand.Parameters.Add(par);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        if (dt.Rows.Count > 0)
                        {
                            string filePath = context.Request.MapPath("ShowDetailUser.html");
                            string fileContent = File.ReadAllText(filePath);
                            fileContent = fileContent.Replace("$Name",dt.Rows[0]["UserName"].ToString()).Replace("$Pwd",dt.Rows[0]["UserPwd"].ToString());
                            context.Response.Write(fileContent);
                        }
                        else
                        {
                            context.Response.Write("查无此人");
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