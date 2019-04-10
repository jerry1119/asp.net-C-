using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChinaOl.UI._5._5Json
{
    /// <summary>
    /// Summary description for GetJson
    /// </summary>
    public class GetJson : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            context.Response.Write("{\"Name\":\"zhangsan\",\"Age\":\"15\"}");
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