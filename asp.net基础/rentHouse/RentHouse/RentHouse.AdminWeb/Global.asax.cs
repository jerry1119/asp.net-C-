using System.Web.Mvc;
using System.Web.Routing;
using RentHouse.AdminWeb.App_Start;

namespace RentHouse.AdminWeb
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            //读取log4Net配置信息
            log4net.Config.XmlConfigurator.Configure();
            //添加Filter
            GlobalFilters.Filters.Add(new AdminExceptionFilter());
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}
