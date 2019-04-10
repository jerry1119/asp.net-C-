using ChinaOl.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChinaOl.UI
{
    /// <summary>
    /// Summary description for AddUserInfo
    /// </summary>
    public class AddUserInfo : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";
            string userName = context.Request.Form["txtName"];
            string userPwd = context.Request.Form["txtPwd"];
            string userMail = context.Request.Form["txtMail"];
            //DateTime userRegTime = DateTime.Now;直接在后面给uerinfo赋值就可以了
            UserInfo userinfo = new UserInfo();
            userinfo.UserName = userName;
            userinfo.UserPwd = userPwd;
            userinfo.Email = userMail;
            userinfo.RegTime = DateTime.Now;
            Bll.UserInfoBll userinfobll = new Bll.UserInfoBll();
            if (userinfobll.AddUserInfo(userinfo))
            {
                context.Response.Redirect("UserInfoList.ashx");
            }
            else
            {
                context.Response.Redirect("Error.html");
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