using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using System.IO;

namespace practice.CRUD
{
    /// <summary>
    /// Summary description for UserInfoList
    /// </summary>
    public class UserInfoList : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";
            string connStr = ConfigurationManager.ConnectionStrings["SqlConn"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                using (SqlDataAdapter adapter = new SqlDataAdapter("select * from UserInfo",conn))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        StringBuilder sb = new StringBuilder();
                        foreach (DataRow row in dt.Rows)
                        {
                            sb.AppendFormat("<tr><td>{0}</td><td>{1}</td><td>{2}</td><td>{3}</td><td>{4}</td><td><a href='ShowDetail.ashx?id={0}'>详细</a></td><td><a href='DeleteUser.ashx?id={0}' class='deletes'>删除</a></td><td ><a href='ShowEdit.ashx?id={0}'>编辑</a></td></tr>", row["UserId"].ToString(), row["UserName"].ToString(), row["UserPwd"].ToString(), row["Email"].ToString(), row["RegTime"].ToString());
                        }
                        //读取模板文件，替换占位符。
                        string filePath = context.Request.MapPath("UserInfoList.html");
                        string fileContent = File.ReadAllText(filePath);
                        fileContent = fileContent.Replace("@tbody", sb.ToString());
                        context.Response.Write(fileContent);
                    }
                    else
                    {
                        context.Response.Write("暂无数据");
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