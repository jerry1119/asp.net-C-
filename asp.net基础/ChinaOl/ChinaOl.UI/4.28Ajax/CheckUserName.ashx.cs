using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChinaOl.UI._4._28Ajax
{
    /// <summary>
    /// Summary description for CheckUserName
    /// </summary>
    public class CheckUserName : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string userName = context.Request["name"];
            Bll.UserInfoBll userInfiBll = new Bll.UserInfoBll();
            if (userInfiBll.GetUserInfo(userName) != null)
            {
                context.Response.Write("用户名已存在");
            }
            else
            {
                context.Response.Write("用户名可用");
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