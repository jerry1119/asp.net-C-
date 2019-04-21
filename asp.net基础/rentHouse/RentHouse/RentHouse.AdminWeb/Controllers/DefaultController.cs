using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RentHouse.Services;

namespace RentHouse.AdminWeb.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        public ActionResult Index()
        {
            using (RhDbContext ctx = new RhDbContext())
            {
                ctx.Database.Create();
            }
            return View();
        }
    }
}