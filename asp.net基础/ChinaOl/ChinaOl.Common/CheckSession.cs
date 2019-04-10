using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChinaOl.Common
{
    //Session统一校验，写在这个类中，哪个页面需要Session校验，继承这个类就行
    public class CheckSession : System.Web.UI.Page
    {
        //Init事件，aspx初始化时触发，先于Page_Load
        public void Page_Init(object sender, EventArgs e)
        {
            if (Session["userInfo"] == null)
            {
                Response.Redirect("Login.aspx");
            }
        }
    }
}
