using ChinaOl.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChinaOl.UI._5._5Json
{
    /// <summary>
    /// Summary description for EditUserInfo
    /// </summary>
    public class EditUserInfo : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            UserInfo editUserInfo = new UserInfo();
            editUserInfo.UserId = Convert.ToInt32( context.Request["txtEditUserId"]);
            editUserInfo.UserName = context.Request["txteditUserName"];
            editUserInfo.UserPwd = context.Request["txteditUserPwd"];
            editUserInfo.Email = context.Request["txteditUserMail"];
            editUserInfo.RegTime = Convert.ToDateTime( context.Request["txtEditRegTime"]);
            Bll.UserInfoBll userInfoBll = new Bll.UserInfoBll();
            if (userInfoBll.EditUserInfo(editUserInfo))
            {
                context.Response.Write("yes");
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