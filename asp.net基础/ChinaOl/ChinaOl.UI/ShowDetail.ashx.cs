using ChinaOl.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace ChinaOl.UI
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
            if (int.TryParse(context.Request.QueryString["id"], out id))
            {
                Bll.UserInfoBll userInfoBll = new Bll.UserInfoBll();
                UserInfo userinfo = userInfoBll.GetUserInfo(id);
                if (userinfo != null)
                {
                    string filePath = context.Request.MapPath("UserDetail.html");
                    string fileContent = File.ReadAllText(filePath);
                    fileContent = fileContent.Replace("$name",userinfo.UserName).Replace("$pwd",userinfo.UserPwd);
                    context.Response.Write(fileContent);
                }
                else
                {
                    context.Response.Redirect("Error.html");
                }
            }
            else
            {
                context.Response.Write("参数错误");
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