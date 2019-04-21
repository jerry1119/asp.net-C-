using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using RentHouse.App_Start;

namespace RentHouse
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            //配置log4net读取config配置文件
            log4net.Config.XmlConfigurator.Configure();
            GlobalFilters.Filters.Add(new FrontExceptionFilter());
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
           
        }
    }
}
