using ChinaOl.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using ChinaOl.Common;
using System.Web.UI.WebControls;

namespace ChinaOl.UI._4._13autoLogin
{
    public partial class UserInfiList : CheckSession//这里继承session校验这个类，因为session校验这个类已经继承了System.web.ui.page,这里就不用继承了
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Session["userInfo"] == null)
            //{
            //    Response.Redirect("Login.aspx");
            //}
            //else
            //{
            //    Response.Write("欢迎" + ((UserInfo)Session["userInfo"]).UserName+"登录本系统");
            //}
            Response.Write("欢迎" + ((UserInfo)Session["userInfo"]).UserName + "登录本系统");
        }
    }
}