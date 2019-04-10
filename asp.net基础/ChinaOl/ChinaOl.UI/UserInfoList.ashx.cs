using ChinaOl.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

namespace ChinaOl.UI
{
    /// <summary>
    /// Summary description for UserInfoList
    /// </summary>
    public class UserInfoList : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";
            Bll.UserInfoBll UserInfoService = new Bll.UserInfoBll();
            List<UserInfo> list = UserInfoService.GetList();
            StringBuilder sb = new StringBuilder();
            foreach (UserInfo userinfo in list)
            {
                sb.AppendFormat("<tr><td>{0}</td><td>{1}</td><td>{2}</td><td>{3}</td><td>{4}</td><td><a href='ShowDetail.ashx?id={0}'>详细</a></td><td><a href='UserDelet.ashx?uid={0}'class=deletes>删除</a></td><td><a href='ShowEdit.ashx?id={0}'>编辑</a></td></tr>", userinfo.UserId, userinfo.UserName, userinfo.UserPwd, userinfo.Email, userinfo.RegTime);
            }
            //读取模板文件
            string filePath = context.Request.MapPath("UserInfoList.html");
            string fileContent = File.ReadAllText(filePath);
            fileContent = fileContent.Replace("@tbody",sb.ToString());
            context.Response.Write(fileContent);
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