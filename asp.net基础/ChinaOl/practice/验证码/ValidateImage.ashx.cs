using ChinaOl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace practice.验证码
{
    /// <summary>
    /// Summary description for ValidateImage
    /// </summary>
    public class ValidateImage : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";
            ValidateCode validateCode = new ValidateCode();
            string code = validateCode.CreateValidateCode(6);
            validateCode.CreateValidateGraphic(code, context);
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