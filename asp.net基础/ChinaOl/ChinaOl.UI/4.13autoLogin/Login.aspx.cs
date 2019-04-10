using ChinaOl.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ChinaOl.UI._4._13autoLogin
{
    public partial class Login : System.Web.UI.Page
    {
        public string Msg { get; set; }
        public string LonginUserName { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                #region 之前的
                //string userName = Request.Form["txtName"];

                ////写到 Cookie中
                ////先编码一下
                //Response.Cookies["userName"].Value = Server.UrlEncode(userName);
                //Response.Cookies["userName"].Expires = DateTime.Now.AddDays(7); 
                #endregion
                if (CheckValidateCode())
                {
                    CheckUserInfo();
                }
                else
                {
                    Msg = "验证码错误";
                }

            }
            else
            {
                #region 之前的
                ////读Cookie
                //if (Request.Cookies["userName"].Value != null)
                //{
                //    string name = Server.UrlDecode( Request.Cookies["userName"].Value);
                //    LonginUserName = name;
                //    //把Cookie的过期时间延后    滑动过期时间
                //    Response.Cookies["userName"].Expires = DateTime.Now.AddDays(7);

                //} 
                #endregion
                //判断Cookie中的值
                CheckCookieInfo();
            }
        }

        #region 校验Cookie信息
        private void CheckCookieInfo()
        {
            if (Request.Cookies["username"] != null && Request.Cookies["userpwd"] != null)
            {
                //自己在测试的时候，发现如果Cookie中存的是中文，这里接收到Cookie来进行查找用户信息，会找不到，而英文则没问题，有待解决
                //已解决：Server.UrlEncode()和Server.UrlDecode()  用这两个方法把中文进行编码和解码就行了
                string userName = Server.UrlDecode( Request.Cookies["username"].Value);
                string userPwd = Request.Cookies["userpwd"].Value;
                Bll.UserInfoBll userInfoBll = new Bll.UserInfoBll();
                UserInfo AotoLoginUserInfo = userInfoBll.GetUserInfo(userName);
                if (AotoLoginUserInfo != null)
                {
                    
                    if (Common.webCommon.GetMd5String(Common.webCommon.GetMd5String(AotoLoginUserInfo.UserPwd))==userPwd)
                    {
                        Session["userInfo"] = AotoLoginUserInfo;
                        Response.Redirect("UserInfiList.aspx");
                    }
                }
                //如果拿到的Cookie数据与数据库中用户的用户名和密码不符合，就将该Cookie删掉
                Response.Cookies["username"].Expires = DateTime.Now.AddDays(-1);
                Response.Cookies["userpwd"].Expires = DateTime.Now.AddDays(-1);

            }
        } 
        #endregion

        #region 判断用户名和密码是否正确
        private void CheckUserInfo()
        {
            
            string userName = Request.Form["txtName"];
            string userPwd = Request.Form["txtPwd"];
            Bll.UserInfoBll userInfoBll = new Bll.UserInfoBll();
            UserInfo LoginUserInfo = userInfoBll.GetUserInfo(userName);
            if (LoginUserInfo != null)
            {
                if (userPwd == LoginUserInfo.UserPwd)
                {
                    //判断用户是否选择了自动登录
                    //页面上有多个复选框时，只能将选中复选框的值提交到服务端
                    if (!string.IsNullOrEmpty(Request.Form["autoLogin"]))
                    {
                        Response.Cookies["username"].Value = Server.UrlEncode( LoginUserInfo.UserName);
                        Response.Cookies["username"].Expires = DateTime.Now.AddDays(3);
                        Response.Cookies["userpwd"].Value = Common.webCommon.GetMd5String(Common.webCommon.GetMd5String(LoginUserInfo.UserPwd));
                        Response.Cookies["userpwd"].Expires = DateTime.Now.AddDays(3);
                    }
                    Session["userInfo"] = LoginUserInfo;
                    Response.Redirect("UserInfiList.aspx");
                }
                else
                {
                    Msg = "用户名或密码错误";
                }
            }
            else
            {
                Msg = "该用户名尚未注册";
            }
        }

        #endregion
        #region 判断验证码是否正确
        private bool CheckValidateCode()
        {
            bool isSucess = false;
            if (Session["SysValidateCode"] != null)//使用Session时一定要校验是否为空
            {
                string UserValidateCode = Request.Form["txtCode"];//获取用户输入的验证码  
                string SysValidateCode = Session["SysValidateCode"].ToString();
                if (SysValidateCode.Equals(UserValidateCode, StringComparison.InvariantCultureIgnoreCase))
                //忽略大小写
                {
                    isSucess = true;
                    Session["SysValidateCode"] = null;//验证成功后一定要将Session清掉
                }
                //else
                //{
                //    Session["SysValidateCode"] = null;
                //}
            }
            return isSucess;



        } 
        #endregion
    }
}