using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using RentHouse.IService;
using RentHouse.Web.Common;
using ZSZ.CommonMVC;

namespace RentHouse.AdminWeb.App_Start
{
    public class AuthorizeFilter : IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            //获得当前要执行的Action上标注的CheckPermissionAttribute实例对象
            CheckPermissionAttribute[] permAtts = (CheckPermissionAttribute[])filterContext.ActionDescriptor.GetCustomAttributes(typeof(CheckPermissionAttribute), false);
            if (permAtts.Length<=0) //没有任何标注的情况就不管，比如登录页
            {
                return;
            }
            //检查当前用户是否登录
            long? userId = (long?) filterContext.HttpContext.Session["LoginUserId"];
            if (userId==null)
            {
                //根据不同的请求方式，给不同的结果
                if (filterContext.HttpContext.Request.IsAjaxRequest())
                {
                    AjaxResult ajaxResult = new AjaxResult();
                    ajaxResult.Status = "redirect";
                    ajaxResult.Data = "/Main/Login";
                    ajaxResult.ErrorMsg = "没有登录";
                    filterContext.Result = new JsonNetResult(){Data =ajaxResult };
                }
                else
                {
                    filterContext.Result = new RedirectResult("/Main/Login");
                }
                return;
            }
            //检查是否有权限
            //由于AuthorizeFilter不是被autofac创建，因此不会自动进行属性的注入
            //需要手动获取Service对象
            IAdminUserService adminUserService =
                DependencyResolver.Current.GetService<IAdminUserService>();
            var adminUser = adminUserService.GetById((long)userId);
            foreach (var permAtt in permAtts)
            {
                //判断当前登录用户是否具有permAtt.Permission权限
                if (!adminUserService.HasPermission(userId.Value, permAtt.Permission))
                {
                    //只要碰到任何一个没有的权限，就禁止访问
                    //在IAuthorizationFilter里面，只要修改filterContext.Result 
                    //那么真正的Action方法就不会执行了
                    if (filterContext.HttpContext.Request.IsAjaxRequest())
                    {
                        AjaxResult ajaxResult = new AjaxResult();
                        ajaxResult.Status = "error";
                        ajaxResult.ErrorMsg = "没有权限"+permAtt.Permission;
                        filterContext.Result = new JsonNetResult() { Data = ajaxResult };
                    }
                    else
                    {
                        filterContext.Result = new ContentResult(){Content = "没有" + permAtt.Permission + "权限" };
                    }
                    return;
                }
            }
        }
    }
}