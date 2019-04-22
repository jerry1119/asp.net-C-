using System.Reflection;
using System.Web.Mvc;
using System.Web.Routing;
using Autofac;
using Autofac.Integration.Mvc;
using RentHouse.AdminWeb.App_Start;
using RentHouse.IService;

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

            //添加autoFac
            ContainerBuilder builder = new ContainerBuilder();
            builder.RegisterControllers(Assembly.GetAssembly(typeof(MvcApplication))).PropertiesAutowired();

            builder.RegisterFilterProvider();

            builder.RegisterAssemblyTypes(Assembly.Load("RentHouse.Services")).AsImplementedInterfaces()
                .Where(c=>!c.IsAbstract&&typeof(IServiceMark).IsAssignableFrom(c)).PropertiesAutowired();
            //Assign：赋值
            //type1.IsAssignableFrom(type2);type1类型的变量是否可以指向type2类型的对象
            //换一种说法：type2是否实现了type1接口/type2是否继承自type1
            //typeof(IServiceSupport).IsAssignableFrom(type)只注册实现了IServiceSupport的类
            //避免其他无关的类注册到AutoFac中

            IContainer container = builder.Build();
            //注册系统级别的DependencyResolver，这样当MVC框架创建Controller等对象的时候都是管Autofac要对象
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}
