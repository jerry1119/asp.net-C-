using RentHouse.AdminWeb.App_Start;
using RentHouse.IService;
using RentHouse.Web.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RentHouse.AdminWeb.Controllers
{
    public class HouseAppointmentController : Controller
    {
        public IHouseAppointmentService HouseAppSvc { get; set; }
        public IAdminUserService UserService { get; set; }
        [CheckPermission("HouseApp.List")]
        public ActionResult List(int pageIndex =1)
        {
            long? userId = AdminHelper.GetUserId(HttpContext);
            long? cityId = UserService.GetById(userId.Value).CityId;
            if (cityId==null)
            {
                return View("Error", (object)"总部的人不能进行房源抢单");
            }
            int pageSize = 3;
            var houseApp =  HouseAppSvc.GetPagedData(cityId.Value, "未处理", pageSize, (pageIndex-1)*pageSize);
            var totalCount = HouseAppSvc.GetTotalCount(cityId.Value, "未处理");

            ViewBag.totalCount = totalCount;
            ViewBag.pageIndex = pageIndex;
            ViewBag.pageSize = pageSize;
            return View(houseApp);
        }
        [CheckPermission("HouseApp.Follow")]
        public ActionResult Follow(long houseAppId)
        {
            long? userId = AdminHelper.GetUserId(HttpContext);
            long? cityId = UserService.GetById(userId.Value).CityId;
            if (cityId == null)
            {
                return View("Error", (object)"总部的人不能进行房源抢单");
            }
            var Isok = HouseAppSvc.Follow(userId.Value,houseAppId);
            if (Isok)
            {
                return Json(new AjaxResult{ Status="ok"});
            }
            else
            {
                return Json(new AjaxResult { Status = "error", ErrorMsg = "抢单失败" });
            }
        }
    }
}