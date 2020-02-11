using RentHouse.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RentHouse
{
    public class FrontHelper
    {
        /// <summary>
        /// 获取当前登录用户id，没有则返回null
        /// </summary>
        /// <returns></returns>
        public static long? GetUserId(HttpContextBase ctx)
        {
            return (long?)ctx.Session["UserId"];
        }
        /// <summary>
        /// 获取当前城市id
        /// </summary>
        /// <param name="ctx"></param>
        /// <returns></returns>
        public static long GetCityId(HttpContextBase ctx)
        {
            //1.有user登录且有cityid：
            long? userId = GetUserId(ctx);
            long? cityId = null;
            if (userId!=null)
            {
                //user有cityid
                var userService = DependencyResolver.Current.GetService<IUserService>();
                cityId = userService.GetById((long)userId).CityId;
                if (cityId != null)
                {
                    return (long)cityId;
                }
                
            }
            //2.登录用户没有cityid，或未登录
            //如果session中存有cityID，则取这个
            cityId = (long?)ctx.Session["CityId"];
            if (cityId != null)
            {
                return (long)cityId;
            }
            else
            {
                //如果session中没有，则默认取第一个cityID
                var cityService = DependencyResolver.Current.GetService<ICityService>();
                return cityService.GetAll()[0].Id;
            }











        }
    }
}