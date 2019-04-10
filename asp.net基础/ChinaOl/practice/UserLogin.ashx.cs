using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace practice
{
    /// <summary>
    /// Summary description for UserLogin
    /// </summary>
    public class UserLogin : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType ="text/html";
            //string filePath = context.Request.MapPath("UserLogin.html");
            //string fileContent = File.ReadAllText(filePath);
            //context.Response.Write(fileContent); 
            string userName = context.Request.Form["userName"];
            string userPwd = context.Request.Form["userPwd"];
            context.Response.Write("用户名是："+userName+",密码是："+userPwd);                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                            
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