using ChinaOl.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChinaOl.UI._5._5Json
{
    /// <summary>
    /// Summary description for AddUserInfo
    /// </summary>
    public class AddUserInfo : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            UserInfo userInfo = new UserInfo();
            userInfo.UserName = context.Request["txtUserName"];
            userInfo.UserPwd = context.Request["txtUserPwd"];
            userInfo.Email = context.Request["txtUserMail"];
            userInfo.RegTime = DateTime.Now;
            Bll.UserInfoBll userInfoBll = new Bll.UserInfoBll();
            //这里没有涉及到校验信息是否符合要求，等以后来完善
            if (userInfoBll.AddUserInfo(userInfo))
            {
                context.Response.Write("ok");
            }
            else
            {
                context.Response.Write("no");
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