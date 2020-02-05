using System.Web.Mvc;
using RentHouse.AdminWeb.App_Start;
using RentHouse.AdminWeb.Models;
using RentHouse.DTO;
using RentHouse.IService;
using RentHouse.Services;
using RentHouse.Web.Common;

namespace RentHouse.AdminWeb.Controllers
{
    public class PermissionController : Controller
    {
        public IPermissionService PermissionService { get; set; }
        // GET: Permission
        [CheckPermission("AdminUser.List")]
        public ActionResult List()
        {
            PermissionDTO [] perms = PermissionService.GetAll();
            return View(perms);
        }
        [CheckPermission("AdminUser.Delete")]
        public ActionResult Delete(long id)
        {
            PermissionService.MarkDeleted(id);
            //return RedirectToAction(nameof(List));
            return Json(new AjaxResult {Status= "ok"});
        }
        [HttpGet]
        [CheckPermission("AdminUser.Edit")]
        public ActionResult Edit(long id)
        {
            var perm = PermissionService.GetById(id);
            return View(perm);
        }
        [HttpPost]
        [CheckPermission("AdminUser.Edit")]
        public ActionResult Edit(PermissionEditModel model)
        {
            PermissionService.UpdatePermission(model.id,model.Name,model.Description);
            //todo:检查name不能重复
            return Json(new AjaxResult() {Status = "ok"});
        }
        [HttpGet]
        [CheckPermission("AdminUser.Add")]
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        [CheckPermission("AdminUser.Add")]
        public ActionResult Add(PermissionAddNewModel model)
        {
            long permId = PermissionService.AddPermission(model.Name, model.Description);
            //todo:权限项名字不能重复
            if (permId!=0)
            {
                return Json(new AjaxResult() {Status = "ok"});
            }
            else
            {
                return Json(new AjaxResult() {ErrorMsg = "添加失败"});
            }
        }
    }
}