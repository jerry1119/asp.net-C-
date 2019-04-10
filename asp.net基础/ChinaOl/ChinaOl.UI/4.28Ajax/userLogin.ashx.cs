using ChinaOl.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChinaOl.UI._4._28Ajax
{
    /// <summary>
    /// Summary description for userLogin
    /// </summary>
    public class userLogin : IHttpHandler,System.Web.SessionState.IRequiresSessionState
    {
        //别忘了实现这个接口  IRequiresSessionState 切记
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string userName = context.Request["userName"];
            string userPwd = context.Request["userPwd"];
            Bll.UserInfoBll userInfoBll = new Bll.UserInfoBll();
            string msg = string.Empty;
            UserInfo userInfo = new UserInfo();
            if (userInfoBll.validateUserInfo(userName, userPwd, out msg, out userInfo))
            {
                
                context.Session["userInfo"] = userInfo;
                context.Response.Write("ok:" + msg);
            }
            else
            {
                context.Response.Write("no:" + msg);
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