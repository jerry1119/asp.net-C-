using RentHouse.Common;
using RentHouse.IService;
using RentHouse.Web.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RentHouse.Controllers
{
    public class UserController : Controller
    {

        public ISettingService SettingService { get; set; }
        public IUserService UserService { get; set; }

        [HttpGet]
        public ActionResult ForgotPassword()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ForgotPassword(string phoneNum,string verifyCode)
        {
            //1.判断验证码
            if ((string)TempData["verifyCode"]!=verifyCode)
            {
                return Json(new AjaxResult { Status = "error", ErrorMsg = "验证码错误" });
            }
            //2.判断是否已注册
            var user = UserService.GetbyPhoneNum(phoneNum);
            if (user==null)
            {
                return Json(new AjaxResult { Status = "error", ErrorMsg = "改手机号尚未注册，请前往注册" });
            }
            //3.可以找回密码，发短信验证码给他

            //发送验证码给用户
            //TODO: 这些可以变的配置appkey等，应该放到后台的setting表中，后台这个页面好像也还没做
            String url = "https://api.netease.im/sms/sendcode.action";
            url += "?mobile=" + phoneNum;//请输入正确的手机号
            //templateid=14830149&    url可选参数有几个，这个是设置短信模板
            //网易云信分配的账号，请替换你在管理后台应用下申请的Appkey
            String appKey = "6a97aa1b42cc07fae97a7bf26a90ddf9";
            //网易云信分配的密钥，请替换你在管理后台应用下申请的appSecret
            String appSecret = "d4e535f6de23";
            //随机数（最大长度128个字符）
            String nonce = "12345";

            TimeSpan ts = DateTime.Now.ToUniversalTime() - new DateTime(1970, 1, 1);
            Int32 ticks = System.Convert.ToInt32(ts.TotalSeconds);
            //当前UTC时间戳，从1970年1月1日0点0 分0 秒开始到现在的秒数(String)
            String curTime = ticks.ToString();
            //SHA1(AppSecret + Nonce + CurTime),三个参数拼接的字符串，进行SHA1哈希计算，转化成16进制字符(String，小写)
            String checkSum = CommonHelper.GetCheckSum(appSecret, nonce, curTime);

            IDictionary<object, String> headers = new Dictionary<object, String>();
            headers["AppKey"] = appKey;
            headers["Nonce"] = nonce;
            headers["CurTime"] = curTime;
            headers["CheckSum"] = checkSum;
            headers["ContentType"] = "application/x-www-form-urlencoded;charset=utf-8";
            //执行Http请求
            string SMSCode = SMSHelper.HttpPost(url, null, headers);
            if (!SMSCode.Contains("200"))
            {
                return Json(new AjaxResult() { Status = "error", ErrorMsg = "获取短信验证码失败"+SMSCode });
            }
            TempData["ForgotSMSCode"] = SMSCode;
            //防止网站漏洞
            TempData["ForgotPhoneNum"] = phoneNum;

            return Json(new AjaxResult { Status = "ok" });
        }
        [HttpGet]
        public ActionResult ForgotPassword2()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ForgotPassword2(string smsCode)
        {
            string serverSMSCode = (string)TempData["ForgotSMSCode"];
            if (!serverSMSCode.Contains(smsCode))
            {
                return Json(new AjaxResult { Status = "error", ErrorMsg = "短信验证码错误" });
            }
            TempData["IsSmsOK"] = true;//确保通过了短信验证才行,在后面做检查
            return Json(new AjaxResult { Status="ok"});
        }
        [HttpGet]
        public ActionResult ForgotPassword3()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ForgotPassword3(string password)
        {
            if ((bool?)TempData["IsSmsOK"]!=true)
            {
                return Json(new AjaxResult { Status="error",ErrorMsg="短信验证未通过"});
            }
            string newPassword = password;
            string phoneNum = (string)TempData["ForgotPhoneNum"];
            var user = UserService.GetbyPhoneNum(phoneNum);
            UserService.UpdatePwd(user.Id, newPassword);
            return Json(new AjaxResult { Status = "ok" });
        }
        [HttpGet]
        public ActionResult ForgotPassword4()
        {
            return View();
        }

        // GET: User
        public ActionResult Index()
        {
            return View();
        }
    }
}