using ChinaOl.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChinaOl.UI._5._5Json
{
    /// <summary>
    /// Summary description for ShowDetail
    /// </summary>
    public class ShowDetail : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            int userId = Convert.ToInt32(context.Request["id"]);
            Bll.UserInfoBll userInfoBll = new Bll.UserInfoBll();
            UserInfo userInfo = userInfoBll.GetUserInfo(userId);
            //别忘了将数据序列化成json数据
            System.Web.Script.Serialization.JavaScriptSerializer js = new System.Web.Script.Serialization.JavaScriptSerializer();
            context.Response.Write(js.Serialize(userInfo));
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