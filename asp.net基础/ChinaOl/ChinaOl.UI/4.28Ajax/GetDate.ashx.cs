using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChinaOl.UI._4._28Ajax
{
    /// <summary>
    /// Summary description for GetDate
    /// </summary>
    public class GetDate : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            // context.Response.Write(context.Request.QueryString["name"]);
            context.Response.Write(context.Request["name"]);//在不好判断是get，还是post时，不写Querstring或者Form,服务端自己判断
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