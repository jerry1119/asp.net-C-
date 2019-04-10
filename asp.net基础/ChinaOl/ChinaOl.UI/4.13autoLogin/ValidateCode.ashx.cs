using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;

namespace ChinaOl.UI._4._13autoLogin
{
    /// <summary>
    /// Summary description for ValidateCode
    /// </summary>
    public class ValidateCode : IHttpHandler,System.Web.SessionState.IRequiresSessionState
    {
        //在一般处理程序中如果要使用Session，必须实现IRequiresSessionState接口  这是个标记接口  而aspx页面默认实现了这个借口
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            ChinaOl.ValidateCode validateCode = new ChinaOl.ValidateCode();
            string code = validateCode.CreateValidateCode(6);
            context.Session["SysValidateCode"] = code;//把代产生的验证码给到Session
            validateCode.CreateValidateGraphic(code,context);
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