using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RentHouse.IService;
using RentHouse.Services;
using ZSZ.Service.Entities;

namespace RentHouse.AdminWeb.Controllers
{
    public class DefaultController : Controller
    {
        public ICityService CityService { get; set; }
        // GET: Default
        public ActionResult Index()
        {
            if (Session["test"] != null)
            {
                return Content((string)Session["test"]);
            }
            Session["test"] = "123";
            return Content("ok");

            var cityId = CityService.AddNew("拉北京");
            return Content(cityId.ToString());
            //return View();
        }

        public ActionResult Login()
        {
            return View();
        }
    }

}