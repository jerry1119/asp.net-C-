using ChinaOl.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ChinaOl.UI.Aspx
{
    public partial class EditUser : System.Web.UI.Page
    {
        public UserInfo EditUserInfo { get; set; }
        Bll.UserInfoBll userInfoBll = new Bll.UserInfoBll();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ShowEditUserInfo();
            }
            else
            {
                UpdateUserInfo();
            }
        }
        /// <summary>
        /// 完成数据的更新
        /// </summary>
        private void UpdateUserInfo()
        {
            UserInfo userInfo = new UserInfo();
            userInfo.UserId = Convert.ToInt32(Request.Form["txtId"]);
            userInfo.UserName = Request.Form["txtName"];
            userInfo.UserPwd = Request.Form["txtPwd"];
            userInfo.Email = Request.Form["txtMail"];
            userInfo.RegTime =Convert.ToDateTime( Request.Form["txtRegTime"]);
            if (userInfoBll.EditUserInfo(userInfo))
            {
                Response.Redirect("UserInfoList.aspx");
            }
            else
            {
                Response.Redirect("Error.html");
            }
        }

        /// <summary>
        /// 展示要修改的用户的信息
        /// </summary>
        private void ShowEditUserInfo()
        {
            int id;
            if (int.TryParse(Context.Request.QueryString["id"], out id))
            {
                
                UserInfo userinfo =  userInfoBll.GetUserInfo(id);
                if (userinfo != null)
                {
                    EditUserInfo = userinfo;
                }
                else
                {
                    Response.Redirect("Error.html");
                }
            }
            else
            {
                Response.Redirect("Error.html");
            }
        }
    }
}