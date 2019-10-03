using System.Web.Mvc;
using RentHouse.DTO;
using RentHouse.IService;
using RentHouse.Services;

namespace RentHouse.AdminWeb.Controllers
{
    public class PermissionController : Controller
    {
        public IPermissionService PermissionService { get; set; }
        // GET: Permission
        public ActionResult List()
        {
            PermissionDTO [] perms = PermissionService.GetAll();
            return View(perms);
        }
    }
}