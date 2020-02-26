using CaptchaGen;
using System;
using System.IO;
using System.Web.Mvc;
using RentHouse.Common;
using RentHouse.IService;
using RentHouse.Web.Common;
using RentHouse.Models;
using System.Collections.Generic;

namespace RentHouse.Controllers
{
    public class MainController : Controller
    {
        public IUserService UserService { get; set; }
        public ICityService CityService { get; set; }
        // GET: 
        public ActionResult Index()
        {
            //获取当前用户城市名
            var cityId = FrontHelper.GetCityId(HttpContext);
            var cityName = CityService.GetById(cityId).Name;
            ViewBag.cityName = cityName;
            //获取所有城市名
            var cities = CityService.GetAll();
            return View(cities);
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(UserLoginModel model)
        {
            if (!ModelState.IsValid)
            {
                return Json(new AjaxResult() {Status = "error", ErrorMsg = MVCHelper.GetValidMesg(ModelState)});
            }

            var user = UserService.GetbyPhoneNum(model.PhoneNum);
            //1.判断用户是否存在
            if (user==null)
            {
                return Json(new AjaxResult() { Status = "error", ErrorMsg = "用户不存在或密码错误" });
            }
            //2.判断用户是否被锁定
            if (UserService.IsLocked(user.Id))
            {
                TimeSpan? leftTimeSpan = TimeSpan.FromMinutes(30)-(DateTime.Now -user.LastLoginErrorDateTime);
                return Json(new AjaxResult() { Status = "error", ErrorMsg = "用户已被锁定，请"+(int)leftTimeSpan.Value.TotalMinutes+"分钟后重试" });
            }
            //3，判断密码
            if (UserService.CheckLogin(model.PhoneNum, model.Password))
            {
                //一旦登录成功，就重置所有登录错误信息，避免影响下一次登录
                UserService.ResetLoginError(user.Id);
                //把当前登录用户信息存入Session 
                Session["UserId"] = user.Id;
                Session["CityId"] = user.CityId;
                return Json(new AjaxResult() {Status = "ok"});
            }
            else
            {
                UserService.IncrLoginError(user.Id);
                return Json(new AjaxResult() { Status = "error", ErrorMsg = "用户不存在或密码错误" });
            }
        }
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(RegisterModel model)
        {
            if (!ModelState.IsValid)
            {
                return Json(new AjaxResult() {Status = "error", ErrorMsg = MVCHelper.GetValidMesg(ModelState)});
            }
            //检查一下注册的时候手机号是不是被改掉了，防止漏洞
            string serverPhone = TempData["RegPhoneNum"].ToString();
            if (serverPhone!=model.PhoneNum)
            {
                return Json(new AjaxResult() { Status = "error", ErrorMsg = "手机号不一致，请重试" });
            }
            if (!TempData["SMSCode"].ToString().Contains(model.SmsCode))
            {
                return Json(new AjaxResult() {Status = "error", ErrorMsg = "短信验证码错误"});
            }
            var user = UserService.GetbyPhoneNum(model.PhoneNum);
            if (user != null)
            {
                return Json(new AjaxResult() { Status = "error", ErrorMsg = "手机号已被注册" });
            }

            UserService.AddNew(model.PhoneNum, model.Password);
            return Json(new AjaxResult() { Status = "ok"});
        }
        public ActionResult CreateVerifyCode()
        {
            var verifyCode = CommonHelper.GenerateCaptchaCode(4);
            MemoryStream picStream = ImageFactory.GenerateImage(verifyCode, 60, 100, 20, 6);
            TempData["verifyCode"] = verifyCode;
            return File(picStream, "image/jpeg");
        }

        public ActionResult SendSmsVerifyCode(string phoneNum,string verifyCode)
        {
            if ((string)TempData["verifyCode"]!=verifyCode)
            {
                return Json(new AjaxResult() {Status = "error", ErrorMsg = "验证码错误"});
            }

            var user = UserService.GetbyPhoneNum(phoneNum);
            if (user!=null)
            {
                return Json(new AjaxResult() {Status = "error", ErrorMsg = "手机号已被注册"});
            }
            //发送验证码给用户
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
                return Json(new AjaxResult() {Status = "error", ErrorMsg = "获取短信验证码失败"});
            }
            TempData["SMSCode"] = SMSCode;
            //把发送验证码的手机号放到TempData，在注册的时候再次检查一下注册的是不是这个手机号
            //防止网站漏洞
            TempData["RegPhoneNum"] = phoneNum;
            return Json(new AjaxResult() { Status = "ok"});
            //TempData["SMSCode"] = "1234";
            //return Json(new AjaxResult() { Status = "ok"});
        }

        [HttpPost]
        public ActionResult SwitchCityId(long cityId)
        {
            //将cityId存到数据库user字段中
            var userId =  FrontHelper.GetUserId(HttpContext);
            if (userId==null)
            {
                HttpContext.Session["CityId"] = cityId;
            }
            else
            {
                var user = UserService.GetById((long)userId);
                UserService.SetUserCityId(user.Id,cityId);
            }
            return Json(new AjaxResult(){Status = "ok"});
        }
    }
}