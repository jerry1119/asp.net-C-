using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RentHouse.IService;
using RentHouse.Models;
using RentHouse.Web.Common;

namespace RentHouse.Controllers
{
    public class HouseController : Controller
    {
        public IHouseService HouseService { get; set; }

        public IAttachmentService AttachmentService { get; set; }

        // GET: House
        public ActionResult Index(long id)
        {
            var house = HouseService.GetById(id);
            if (house==null)
            {
                return Json(new AjaxResult() {Status = "error", ErrorMsg = "房源获取失败"});
            }

            var housePics = HouseService.GetPics(house.Id);
            var attachments = AttachmentService.GetById(house.Id);
            HouseIndexModel model = new HouseIndexModel()
            {
                Attachments = attachments,House = house,HousePics = housePics
            };
            return View(model);
        }
    }
}