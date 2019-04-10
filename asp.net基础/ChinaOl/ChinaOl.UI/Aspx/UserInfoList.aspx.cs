using ChinaOl.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ChinaOl.UI.Aspx
{
    public partial class UserInfoList : System.Web.UI.Page
    {
        public string StrHtml { get; set; }
        public List<UserInfo> UserList { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            Bll.UserInfoBll userInfoBll = new Bll.UserInfoBll();
            List<UserInfo> list = userInfoBll.GetList();
            UserList = list;
            //StringBuilder sb = new StringBuilder();
            //foreach (UserInfo userinfo in list)
            //{
            //    sb.AppendFormat("<tr><td>{0}</td><td>{1}</td><td>{2}</td><td>{3}</td></tr>",userinfo.UserId,userinfo.UserName,userinfo.UserPwd,userinfo.RegTime.ToShortDateString());
            //    StrHtml = sb.ToString();
            //}
        }
    }
}