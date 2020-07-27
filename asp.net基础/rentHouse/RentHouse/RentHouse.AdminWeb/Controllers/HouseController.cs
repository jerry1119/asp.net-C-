using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CodeCarvings.Piczard;
using CodeCarvings.Piczard.Filters.Watermarks;
using RentHouse.AdminWeb.App_Start;
using RentHouse.AdminWeb.Models;
using RentHouse.Common;
using RentHouse.DTO;
using RentHouse.IService;
using RentHouse.Models;
using RentHouse.Web.Common;

namespace RentHouse.AdminWeb.Controllers
{
    public class HouseController : Controller
    {
        public IHouseService HouseService { get; set; }
        public IAdminUserService AdminUserService { get; set; }
        public IRegionService RegionService { get; set; }
        public IIdNameService IdNameService { get; set; }
        public IAttachmentService AttachmentService { get; set; }
        public ICommunityService CommunityService { get; set; }
        // GET: House
        [CheckPermission("House.List")]
        public ActionResult List(long typeId,int pageIndex=1)
        {
            //因为AuthorizFilter做了是否登录的检查，因此这里不会取不到uerid
            long userId = (long)AdminHelper.GetUserId(HttpContext);
            var user = AdminUserService.GetById(userId);
            if (user.CityId==null)
            {
                //TODO如果“总部不能***”的操作很多，也可以定义成一个AuthorizeFilter
                //最好用FilterAttribute的方式标注，这样对其他的不涉及这个问题的地方效率高
                //立即实现
                return View("ERROR", (object) "总部不能进行房源管理");
            }
            int pageSize = 4;
            var houses = HouseService.GetPagedData((long)user.CityId,typeId, pageSize, (pageIndex-1)* pageSize);
            long totalCount = HouseService.GetTotalCount((long)user.CityId, typeId);
            ViewBag.totalCount = totalCount;
            ViewBag.pageIndex = pageIndex;
            ViewBag.typeId = typeId;
            ViewBag.pageSize = pageSize;
            return View(houses);
        }
        [CheckPermission("House.Delete")]
        public ActionResult Delete(long id)
        {
            HouseService.MarkDeleted(id);
            return Json(new AjaxResult() {Status = "ok"});
        }
        [CheckPermission("House.Delete")]
        public ActionResult BatchDelete(long[] selectedIds)
        {
            foreach (var id in selectedIds)
            {
                HouseService.MarkDeleted(id);
            }
            return Json(new AjaxResult() { Status = "ok" });
        }
        //加载社区
        public ActionResult LoadCommunities(long regionId)
        {
            var communities = CommunityService.GetByRegionId(regionId);
            return Json(new AjaxResult() {Status = "ok", Data = communities});
        }
        [HttpGet]
        [CheckPermission("House.Add")]
        
        public ActionResult Add()
        {
            long userId = (long)AdminHelper.GetUserId(HttpContext);
            var user = AdminUserService.GetById(userId);
            if (user.CityId == null)
            {
                //TODO如果“总部不能***”的操作很多，也可以定义成一个AuthorizeFilter
                //最好用FilterAttribute的方式标注，这样对其他的不涉及这个问题的地方效率高
                //立即实现
                return View("ERROR", (object)"总部不能进行房源管理");
            }

            var regions = RegionService.GetAll((long) user.CityId);
            var roomTypes = IdNameService.GetAll("户型");
            var status = IdNameService.GetAll("房屋状态");
            var decorateStatus = IdNameService.GetAll("装修状态");
            var types = IdNameService.GetAll("出租类别");
            var attachments = AttachmentService.GetAll();

            HouseAddNewGetModel model = new HouseAddNewGetModel();
            model.Attachments = attachments;
            model.DecorateStatus = decorateStatus;
            model.Regions = regions;
            model.RoomTypes = roomTypes;
            model.Status = status;
            model.Types = types;
            return View(model);
        }

        [HttpPost]
        [CheckPermission("House.Add")]
        [ValidateInput(false)]
        public ActionResult Add(HouseAddNewDTO house)
        {
            long userId = (long)AdminHelper.GetUserId(HttpContext);
            var user = AdminUserService.GetById(userId);
            if (user.CityId == null)
            {
                //TODO如果“总部不能***”的操作很多，也可以定义成一个AuthorizeFilter
                //最好用FilterAttribute的方式标注，这样对其他的不涉及这个问题的地方效率高
                //立即实现
                return View("ERROR", (object)"总部不能进行房源管理");
            }
            var houseId = HouseService.AddNew(house);
            if (houseId>0)
            {
                //生成房源查看的html文件
                return Json(new AjaxResult() {Status = "ok"});
            }

            return Json(new AjaxResult() {Status = "error", ErrorMsg = "添加失败"});

        }

        [HttpGet]
        [CheckPermission("House.Edit")]
        public ActionResult Edit(long Id)
        {
            long userId = (long)AdminHelper.GetUserId(HttpContext);
            var user = AdminUserService.GetById(userId);
            if (user.CityId == null)
            {
                //TODO如果“总部不能***”的操作很多，也可以定义成一个AuthorizeFilter
                //最好用FilterAttribute的方式标注，这样对其他的不涉及这个问题的地方效率高
                //立即实现
                return View("ERROR", (object)"总部不能进行房源管理");
            }
            var regions = RegionService.GetAll((long)user.CityId);
            var roomTypes = IdNameService.GetAll("户型");
            var status = IdNameService.GetAll("房屋状态");
            var decorateStatus = IdNameService.GetAll("装修状态");
            var types = IdNameService.GetAll("出租类别");
            var attachments = AttachmentService.GetAll();
            var house = HouseService.GetById(Id);
            HouseEditGetModel model = new HouseEditGetModel();
            model.Attachments = attachments;
            model.DecorateStatus = decorateStatus;
            model.Regions = regions;
            model.RoomTypes = roomTypes;
            model.Status = status;
            model.Types = types;
            model.House = house;
            return View(model);
        }

        [HttpPost]
        [CheckPermission("House.Edit")]
        [ValidateInput(false)]  //允许输入的内容包含标签 脚本 解决 从客户端中检测到有潜在危险的 Request.Form 值错误
        public ActionResult Edit(HouseEditModel model)
        {
            long userId = (long)AdminHelper.GetUserId(HttpContext);
            var user = AdminUserService.GetById(userId);
            if (user.CityId == null)
            {
                return View("ERROR", (object)"总部不能进行房源管理");
            }
            var house = HouseService.GetById(model.HouseId);
            house.Address = model.Address;
            house.Area = model.Area;
            house.AttachmentIds = model.AttachmentIds;
            house.CheckInDateTime = model.CheckInDateTime;
            house.CommunityId = model.CommunityId;
            house.Description = model.Description;
            house.DecorateStatusId = model.DecorateStatusId;
            house.Direction = model.Direction;
            house.FloorIndex = model.FloorIndex;
            house.LookableDateTime = model.LookableDateTime;
            house.MonthRent = model.MonthRent;
            house.OwnerName = model.OwnerName;
            house.OwnerPhoneNum = model.OwnerPhoneNum;
            house.RoomTypeId = model.RoomTypeId;
            house.StatusId = model.StatusId;
            house.TypeId = model.TypeId;
            house.TotalFloorCount = model.TotalFloorCount;
            HouseService.Update(house);
            return Json(new AjaxResult() { Status = "ok" });
        }

        public ActionResult PicUpLoad(long houseId)
        {
            return View(houseId);
        }

        public ActionResult UploadPic(long houseId, HttpPostedFileBase file)
        {
            //一般是用文件的md5值来命名
            string fileMd5 = CommonHelper.CalcMd5(file.InputStream);
            string fileExt = Path.GetExtension(file.FileName);
            string path = "/upload/" + DateTime.Now.ToString("yyyy/MM/dd") + "/" + fileMd5 + fileExt;
            string trumbPath = "/upload/" +DateTime.Now.ToString("yyyy/MM/dd")+ "/" + fileMd5 + "_trumb" + fileExt;
            string trumbFullPath = Server.MapPath("~"+trumbPath);
            string fullPath = Server.MapPath("~" + path);
            new FileInfo(trumbFullPath).Directory.Create();
            file.InputStream.Position = 0; //指针复位
            //缩略图
            ImageProcessingJob jobThumb = new ImageProcessingJob();
            jobThumb.Filters.Add(new FixedResizeConstraint(200, 200));//缩略图尺寸 200*200
            jobThumb.SaveProcessedImageToFileSystem(file.InputStream, trumbFullPath, new JpegFormatEncoderParams());

            file.InputStream.Position = 0; //指针复位
            ImageWatermark imgWatermark = new ImageWatermark(@"F:\86.jpg");
            imgWatermark.ContentAlignment = System.Drawing.ContentAlignment.BottomRight;//水印位置
            imgWatermark.Alpha = 80;//透明度，需要水印图片是背景透明的 png 图片
            ImageProcessingJob jobNormal = new ImageProcessingJob();
            jobNormal.Filters.Add(imgWatermark);//添加水印
            //jobNormal.Filters.Add(new FixedResizeConstraint(600, 600));//限制图片的大小，避免生成大图。如果想原图大小处理，就不用加这个 Filter然后调用 SaveProcessedImageToFileSystem 或者 SaveProcessedImageToStream 来保存文件
            imgWatermark.SaveProcessedImageToFileSystem(file.InputStream,fullPath,new JpegFormatEncoderParams());

            HouseService.AddNewHousePic(new HousePicDTO()
                {HouseId = houseId, Url = path, ThumbUrl = trumbPath});
            return Json(new AjaxResult(){Status = "ok"});
        }

        public ActionResult PicList(long houseId)
        {
            var pics = HouseService.GetPics(houseId);
            return View(pics);
        }
        //图片删除
        public ActionResult PicDelete(long[] selectedIds)
        {
            foreach (var picId in selectedIds)
            {
                 HouseService.DeleteHousePic(picId);
            }
            //不建议删除图片
            return Json(new AjaxResult() {Status = "ok"});
        }

        public void CreateStaticPages(long houseId)
        {
            HouseIndexModel model = new HouseIndexModel
            {
                Attachments = AttachmentService.GetById(houseId),
                House = HouseService.GetById(houseId),
                HousePics = HouseService.GetPics(houseId)
            };
            MVCHelper.RenderViewToString(this.ControllerContext, "", model);
        }
    }
}