using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using ChinaOl.Model;

namespace ChinaOl.UI
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
                Bll.UserInfoBll userInfoBll = new Bll.UserInfoBll();
                UserInfo userInfo = userInfoBll.GetUserInfo(id);
                if (userInfo != null)
                {
                    string filePath = context.Request.MapPath("ShowEdit.html");
                    string fileContent = File.ReadAllText(filePath);
                    fileContent = fileContent.Replace("$name",userInfo.UserName).Replace("$pwd",userInfo.UserPwd).Replace("$email",userInfo.Email).Replace("$id",userInfo.UserId.ToString());
                    context.Response.Write(fileContent);
                }
                else
                {
                    context.Response.Redirect("查无此人");
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