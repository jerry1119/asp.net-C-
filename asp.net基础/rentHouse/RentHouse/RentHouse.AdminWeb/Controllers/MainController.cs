using System.IO;
using System.Web.Mvc;
using CaptchaGen;
using RentHouse.AdminWeb.Models;
using RentHouse.Common;
using RentHouse.IService;
using RentHouse.Web.Common;

namespace RentHouse.AdminWeb.Controllers
{
    public class MainController : Controller
    {
        public IAdminUserService AdminUserService { get; set; }
        public ICityService CityService { get; set; }
        // GET: Default
        public ActionResult Index()
        {
            long? userId = (long?) HttpContext.Session["LoginUserId"];
            if (userId==null)
            {
                return Redirect("~/Main/Login");
            }
            var user = AdminUserService.GetById((long)userId);
            return View(user);
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult Logout()
        {
            Session.Abandon();//销毁Session
            return Redirect("~/Main/Login");
        }
        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            if (!ModelState.IsValid)
            {
                return Json(new AjaxResult
                {
                    Status = "error",
                    ErrorMsg = MVCHelper.GetValidMesg(ModelState)
                });
            }

            if (model.VerifyCode!=(string)TempData["verifyCode"])
            {
                return Json(new AjaxResult { Status="error",ErrorMsg="验证码错误"});
            }

            bool result = AdminUserService.CheckLogin(model.PhoneNum, model.Password);
            if (result)
            {
                //将userId存放到session中
                Session["LoginUserId"] = AdminUserService.GetByPhoneNum(model.PhoneNum).Id;
                return Json(new AjaxResult { Status="ok"});
            }
            else
            {
                return Json(new AjaxResult { Status = "error",ErrorMsg="用户名或者密码错误" });
            }
        }
        public ActionResult CreateVerifyCode()
        {
            var verifyCode = CommonHelper.GenerateCaptchaCode(4);
            TempData["verifyCode"] = verifyCode;  //放在tempdata中取一次就自动销毁
            //TODO:有网了把验证码插件装上
             MemoryStream ms = ImageFactory.GenerateImage(verifyCode, 50, 100, 20, 6); //高度，宽度，字体大小，扭曲程度
             return File(ms, "image/jpeg");
            //暂时这样给回去自己看
            //return Json(new AjaxResult(){Status = verifyCode});
        }
    }

}