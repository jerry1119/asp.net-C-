using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ChinaOl.UI.Aspx
{
    public partial class AddUserInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //如果隐藏域的值不为空，表示用户单击了提交按钮发出了post请求
            //if (!string.IsNullOrEmpty(Request.Form["isPostBack"]))
            //IsPostBack：如果是post请求该属性的值为ture，如果是get请求该属性的值 为false
            //IsPostBack：是根据__VIEWSTATE隐藏域进行判断的，如果是post请求那么该隐藏域的值会提交到服务器，那么IsPostBack属性也就为true
            //如果将form标签的runat = "server"去掉，那么就不能用该属性进行判断是post请求还是get请求
            //因为去掉后就不会再产生__VIEWSTATE隐藏 域了
            if (IsPostBack)
            {
                AddUser();
            }
        }
       
        private void AddUser()
        {
            Model.UserInfo userinfo = new Model.UserInfo();
            userinfo.UserName = Request.Form["txtName"];
            userinfo.UserPwd = Request.Form["txtPwd"];
            userinfo.Email = Request.Form["txtMail"];
            userinfo.RegTime = DateTime.Now;
            Bll.UserInfoBll userInfoBll = new Bll.UserInfoBll();
            if (userInfoBll.AddUserInfo(userinfo))
            {
                Response.Redirect("UserInfoList.aspx");
            }
            else
            {
                Response.Redirect("Error.html");
            }

            
        }
    }
}