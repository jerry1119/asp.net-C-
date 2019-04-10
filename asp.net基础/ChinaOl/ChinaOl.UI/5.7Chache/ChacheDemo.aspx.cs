using ChinaOl.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ChinaOl.UI._5._7Chache
{
    public partial class ChacheDemo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //判断缓存中是否有数据
            if (Cache["userInfoList"] == null)
            {
                Bll.UserInfoBll userInfoBll = new Bll.UserInfoBll();
                List<UserInfo> list = userInfoBll.GetList();
                //将数据放到缓存中
                Cache["userInfoList"] = list;
                Response.Write("数据来自数据库");
            }
            else
            {
                List<UserInfo> list = (List<UserInfo>)Cache["userInfoList"];
                Response.Write("数据来自缓存");
            }
        }
    }
}