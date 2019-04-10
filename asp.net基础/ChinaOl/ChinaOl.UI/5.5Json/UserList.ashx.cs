using ChinaOl.Common;
using ChinaOl.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChinaOl.UI._5._5Json
{
    /// <summary>
    /// Summary description for UserList
    /// </summary>
    public class UserList : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            Bll.UserInfoBll userInfoBll = new Bll.UserInfoBll();
            int pageIndex;
            if(!int.TryParse(context.Request["pageIndex"], out pageIndex))
            {
                pageIndex = 1;
            }
            int pageSize = 3;
            int pageCount = userInfoBll.GetPageCount(pageSize);//获取总页数
            //判断当前页码值的取值范围
            pageIndex = pageIndex < 1 ? 1 : pageIndex;
            pageIndex = pageIndex > pageCount ? pageCount : pageIndex;
            //获取分页数据
            List<UserInfo> list= userInfoBll.GetPageList(pageIndex,pageSize);
            //获取页码条
            string pageBar = PageBarHelper.GetPageBar(pageIndex,pageCount);
            //用微软提供的 JavaScriptSerializer 类将数据序列化成Json字符串
            System.Web.Script.Serialization.JavaScriptSerializer js = new System.Web.Script.Serialization.JavaScriptSerializer();
            string str = js.Serialize(new { UList = list,MyPageBar=pageBar});//用匿名类把分页数据和页码条写到一起
            context.Response.Write(str);
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