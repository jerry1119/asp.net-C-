using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RentHouse.AdminWeb.App_Start;
using RentHouse.AdminWeb.Models;
using RentHouse.IService;
using RentHouse.Web.Common;

namespace RentHouse.AdminWeb.Controllers
{
    public class AdminUserController : Controller
    {
        public IAdminUserService AdminUserService { get; set; }
        public IRoleService RoleService { get; set; }
        public ICityService CityService { get; set; }
        // GET: AdminUser
        [CheckPermission("AdminUser.List")]
        public ActionResult List()
        {
            var users = AdminUserService.GetAll();
            return View(users);
        }
        /// <summary>
        /// 检查手机号是否已存在
        /// </summary>
        /// <param name="phoneNum"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public ActionResult CheckPhoneNum(string phoneNum, long? userId)
        {
            var user = AdminUserService.GetByPhoneNum(phoneNum);
            bool isOK = false;
            //如果没有给userId，则说明是“插入”，只要检查是不是存在这个手机号
            if (userId == null)
            {
                isOK = (user == null);
            }
            else//如果有userId，则说明是修改，则要把自己排除在外
            {
                isOK = (user == null || user.Id == userId);
            }

            return Json(new AjaxResult() {Status = isOK ? "ok" : "exists"});
        }
        [CheckPermission("AdminUser.Delete")]
        public ActionResult Delete(long id)
        {
            AdminUserService.MarkDeleted(id);
            return Json(new AjaxResult() { Status = "ok" });
        }
        [CheckPermission("AdminUser.Delete")]
        public ActionResult BatchDelete(long[] selectedIds)
        {
            foreach (var id in selectedIds)
            {
                AdminUserService.MarkDeleted(id);
            }
            return Json(new AjaxResult() { Status = "ok" });
        }
        [HttpGet]
        [CheckPermission("AdminUser.Add")]
        public ActionResult Add()
        {
            var roles = RoleService.GetAll();
            var cities = CityService.GetAll();
            AdminUserAddNewGetModel model = new AdminUserAddNewGetModel();
            model.Roles = roles;
            model.Cities = cities;
            return View(model);
        }
        [HttpPost]
        [CheckPermission("AdminUser.Add")]
        public ActionResult Add(AdminUserAddNewModel model)
        {
            if (!ModelState.IsValid)
            {
                return Json(new AjaxResult() { Status = "error", ErrorMsg = MVCHelper.GetValidMesg(ModelState) });
            }

            var user = AdminUserService.GetByPhoneNum(model.PhoneNum);
            if (user != null)
            {
                return Json(new AjaxResult() { Status = "error", ErrorMsg = "该手机号已被注册" });
            }
            //发现在service里面也判断了一次手机是否注册，感觉越早判断越好，service那个就没必要了
            //TODO:这里应该用事务
            long adminUserId = AdminUserService.AddAdminUser(model.Name, model.PhoneNum, model.PassWord, model.Email, model.CityId);
            RoleService.AddRoleIds(adminUserId, model.RoleIds);

            return Json(new AjaxResult() { Status = "ok" });
        }

        [HttpGet]
        [CheckPermission("AdminUser.Edit")]
        public ActionResult Edit(long id)
        {
            var user = AdminUserService.GetById(id);
            var cities = CityService.GetAll();
            var userRoles = RoleService.GetByAdminUserId(id);
            var allRoles = RoleService.GetAll();
            AdminUserEditGetModel model = new AdminUserEditGetModel();
            model.User = user;
            model.AllRoles = allRoles;
            model.Cities = cities;
            model.UserRoles = userRoles;
            return View(model);
        }

        [HttpPost]
        [CheckPermission("AdminUser.Edit")]
        public ActionResult Edit(AdminUserEditModel model)
        {
            //修改的时候密码为空表示不修改，这样的话属性验证过不了，直接去掉这个了
            //if (!ModelState.IsValid)
            //{
            //    return Json(new AjaxResult() { Status = "error", ErrorMsg = MVCHelper.GetValidMesg(ModelState) });
            //}

            var user = AdminUserService.GetByPhoneNum(model.PhoneNum);
            if (user == null)
            {
                return Json(new AjaxResult() { Status = "error", ErrorMsg = "该手机号不存在" });
            }
            //TODO:这里应该用事务
            AdminUserService.UpdateAdminUser(user.Id, model.Name, model.PhoneNum, model.PassWord, model.Email, model.CityId);
            RoleService.UpdateRoleIds(user.Id, model.RoleIds);

            return Json(new AjaxResult() { Status = "ok" });
        }
    }
}