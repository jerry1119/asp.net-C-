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
            var cityId = CityService.AddNew("拉北京");
            return Content(cityId.ToString());
            //return View();
        }
    }
}