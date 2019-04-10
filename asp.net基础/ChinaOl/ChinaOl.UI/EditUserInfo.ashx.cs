using ChinaOl.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChinaOl.UI
{
    /// <summary>
    /// Summary description for EditUserInfo
    /// </summary>
    public class EditUserInfo : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";
            int id = Convert.ToInt32(context.Request.Form["txtId"]);//接收隐藏域中的值，
            Bll.UserInfoBll userInfoBll = new Bll.UserInfoBll();
            UserInfo userInfo = userInfoBll.GetUserInfo(id);//通过这个id获取用户信息
            userInfo.UserName = context.Request.Form["txtName"];//通过表单中的信息重新赋值
            userInfo.UserPwd = context.Request.Form["txtPwd"];
            userInfo.Email = context.Request.Form["txtMail"];

            if (userInfoBll.EditUserInfo(userInfo))
            {
                context.Response.Redirect("UserInfoList.ashx");
            }
            else
            {
                context.Response.Redirect("Error.html");
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