using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IService;

namespace AutoFacMVC.Controllers
{
    public class IndexController : Controller
    {
        public IUserService UserService { get; set; } //属性注入

        // GET: Index
        public ActionResult Index()
        {
            bool b = UserService.UserLogin("abc", "123");
            return Content(b.ToString());
        }
    }
}