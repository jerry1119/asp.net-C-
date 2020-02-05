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
    public class RoleController : Controller
    {
        public IRoleService RoleService { get; set; }
        public IPermissionService PermissionService { get; set; }
        // GET: Role
        [CheckPermission("Role.List")]
        public ActionResult List()
        {
            var roles = RoleService.GetAll();
            return View(roles);
        }
        [CheckPermission("Role.Delete")]
        public ActionResult Delete(long id)
        {
            RoleService.MarkDelete(id);
            return Json(new AjaxResult() {Status = "ok"});
        }

        [HttpGet]
        [CheckPermission("Role.Add")]
        public ActionResult Add()
        {
            var perms = PermissionService.GetAll();
            return View(perms);
        }
        [HttpPost]
        [CheckPermission("Role.Add")]
        public ActionResult Add(RoleAddNewModel model)
        {
            //这两个操作应该放到事务中,以免造成只成功了一个
            //检查model验证是否通过
            if (!ModelState.IsValid)
            {
                return Json(new AjaxResult() {Status = "error", ErrorMsg = MVCHelper.GetValidMesg(ModelState)});
            }
            long roleId = RoleService.AddNew(model.Name);
            PermissionService.AddPermIds(roleId,model.PermissionIds);

            return Json(new AjaxResult() { Status = "ok" });
        }

        [HttpGet]
        [CheckPermission("Role.Edit")]
        public ActionResult Edit(long id)
        {
            var rolePerms = PermissionService.GetByRoleId(id);
            var allPerms = PermissionService.GetAll();
            var role = RoleService.GetById(id);
            RoleEditGetModel roleEditGetModel = new RoleEditGetModel();
            roleEditGetModel.AllPerms = allPerms;
            roleEditGetModel.RolePerms = rolePerms;
            roleEditGetModel.Role = role;
            return View(roleEditGetModel);
        }
        [HttpPost]
        [CheckPermission("Role.Edit")]
        public ActionResult Edit(RoleEditModel model)
        {
            var role = RoleService.GetById(model.Id);
            if (role.Name!=model.Name)
            {
                RoleService.Update(role.Id,model.Name);
            }
            PermissionService.UpdatePermIds(role.Id,model.PermissionIds);
            return Json(new AjaxResult() { Status = "ok" });
        }
    }
}