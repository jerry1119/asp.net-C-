using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChinaOl.UI.Aspx
{
    /// <summary>
    /// Summary description for Delete
    /// </summary>
    public class Delete : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";
            int id;
            if (int.TryParse(context.Request.QueryString["id"], out id))
            {
                Bll.UserInfoBll userInfoBll = new Bll.UserInfoBll();
                if (userInfoBll.DeleteUserInfo(id) > 0)
                {
                    context.Response.Redirect("UserInfoList.aspx");
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