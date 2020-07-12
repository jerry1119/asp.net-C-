using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RentHouse.DTO;
using RentHouse.IService;
using RentHouse.Models;
using RentHouse.Web.Common;

namespace RentHouse.Controllers
{
    public class HouseController : Controller
    {
        public IHouseService HouseService { get; set; }

        public IAttachmentService AttachmentService { get; set; }

        public IRegionService RegionService { get; set; }

        public ICityService CityService { get; set; }
        public IHouseAppointmentService HouseAppointmentService { get; set; }

        public ActionResult MakeAppointment(HouseAppointmentModel model)
        {
            if (!ModelState.IsValid)
            {
                string msg = MVCHelper.GetValidMesg(ModelState);
                return Json(new AjaxResult { Status = "error", ErrorMsg = msg });
            }
            long? userId = FrontHelper.GetUserId(HttpContext);
            HouseAppointmentService.AddNew(userId,model.Name, model.PhoneNum, model.HouseId, model.VisitDate);
            return Json(new AjaxResult { Status="ok"});
        }

        public ActionResult Search(long typeId,string keyWords,string monthRent,string oderByType,long? regionId)
        {
            //获取当前用户城市ID
            var cityId = FrontHelper.GetCityId(HttpContext);
            //获取城市下所有区域
            var regions = RegionService.GetAll(cityId);
            HouseSearchViewModel viewModel = new HouseSearchViewModel();
            viewModel.Regions = regions;
            HouseSearchOptions searchOptions = new HouseSearchOptions();
            
            searchOptions.TypeId = typeId;
            searchOptions.Keywords = keyWords;
            searchOptions.PageSize = 10;
            searchOptions.RegionId = regionId;
            searchOptions.CityId = cityId;
            searchOptions.CurrentIndex = 1;

            switch (oderByType)
            {
                case "MonthRentDesc":
                    searchOptions.OrderByType = HouseSearchOrderByType.MonthRentDesc;
                    break;
                case "MonthRentAsc":
                    searchOptions.OrderByType = HouseSearchOrderByType.MonthRentAsc;
                    break;
                case "AreaAsc":
                    searchOptions.OrderByType = HouseSearchOrderByType.AreaAsc;
                    break;
                case "AreaDesc":
                    searchOptions.OrderByType = HouseSearchOrderByType.AreaDesc;
                    break;
            }
            //解析月租部分
            int? startMonthRent;
            int? endMonthRent;
            ParseMonthRent(monthRent,out startMonthRent,out endMonthRent);

            searchOptions.StartMonthRent = startMonthRent;
            searchOptions.EndMonthRent = endMonthRent;

            var houseSearchResult = HouseService.Search(searchOptions);
            viewModel.Houses = houseSearchResult.result;
            return View(viewModel);
        }
        public ActionResult Search2(long typeId, string keyWords, string monthRent, string oderByType, long? regionId)
        {
            //获取当前用户城市ID
            var cityId = FrontHelper.GetCityId(HttpContext);
            //获取城市下所有区域
            var regions = RegionService.GetAll(cityId);
            
            return View(regions);
        }
        public ActionResult LoadMore(long typeId, string keyWords, string monthRent, string oderByType,int currentIndex, long? regionId)
        {
            //获取当前用户城市ID
            var cityId = FrontHelper.GetCityId(HttpContext);
            
            HouseSearchOptions searchOptions = new HouseSearchOptions();

            searchOptions.TypeId = typeId;
            searchOptions.Keywords = keyWords;
            searchOptions.PageSize = 10;
            searchOptions.RegionId = regionId;
            searchOptions.CityId = cityId;
            searchOptions.CurrentIndex = currentIndex;

            switch (oderByType)
            {
                case "MonthRentDesc":
                    searchOptions.OrderByType = HouseSearchOrderByType.MonthRentDesc;
                    break;
                case "MonthRentAsc":
                    searchOptions.OrderByType = HouseSearchOrderByType.MonthRentAsc;
                    break;
                case "AreaAsc":
                    searchOptions.OrderByType = HouseSearchOrderByType.AreaAsc;
                    break;
                case "AreaDesc":
                    searchOptions.OrderByType = HouseSearchOrderByType.AreaDesc;
                    break;
            }
            //解析月租部分
            int? startMonthRent;
            int? endMonthRent;
            ParseMonthRent(monthRent, out startMonthRent, out endMonthRent);

            searchOptions.StartMonthRent = startMonthRent;
            searchOptions.EndMonthRent = endMonthRent;

            var houseSearchResult = HouseService.Search(searchOptions);
            var houses = houseSearchResult.result;
            return Json(new AjaxResult { Status = "ok", Data = houses }) ;
        }
        public ActionResult Index(long id)
        {
            var house = HouseService.GetById(id);
            if (house==null)
            {
                //return Json(new AjaxResult() {Status = "error", ErrorMsg = "房源获取失败"}); 这里写这个干嘛，是url又不是ajax,应该直接返回error页面
                return View("Error",(object)"不存在的房源id");
            }

            var housePics = HouseService.GetPics(house.Id);
            var attachments = AttachmentService.GetById(house.Id);
            HouseIndexModel model = new HouseIndexModel()
            {
                Attachments = attachments,House = house,HousePics = housePics
            };
            return View(model);
        }
        /// <summary>
        /// 分析"200-300","300-*"这样的价格区间
        /// </summary>
        /// <param name="value">200-300</param>
        /// <param name="startMonthRent">解析出来的起始租金</param>
        /// <param name="endMonthRent">解析出来的结束租金</param>
        private void ParseMonthRent(string value,out int? startMonthRent,out int? endMonthRent)
        {
            //如果没有传递monthRent参数，说明不限制房租
            if (string.IsNullOrEmpty(value))
            {
                startMonthRent = null;
                endMonthRent = null;
                return;
            }

            string[] values = value.Split('-');
            string strStart = values[0];
            string strEnd = values[1];
            if (strStart == "*")
            {
                startMonthRent = null;//不设限
            }
            else
            {
                startMonthRent = Convert.ToInt32(strStart);
            }

            if (strEnd == "*")
            {
                endMonthRent = null;//不设限
            }
            else
            {
                endMonthRent = Convert.ToInt32(strEnd);
            }
        }
    }
}