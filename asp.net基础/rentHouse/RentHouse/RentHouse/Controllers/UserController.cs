using RentHouse.IService;
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
            
        }
        // GET: User
        public ActionResult Index()
        {
            return View();
        }
    }
}