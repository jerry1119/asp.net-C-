using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Autofac;
using Autofac.Integration.Mvc;

namespace AutoFacMVC
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            var builder = new ContainerBuilder();
            var asm = typeof(MvcApplication).Assembly;
            builder.RegisterControllers(asm).PropertiesAutowired();//注册当前程序集中所有的Controller,并且属性注入
            builder.RegisterFilterProvider();//注册所有的filter
            //还要注册所有要用到的类库的接口实现方法
            //先拿到所有相关类库的程序集
            Assembly [] assemblies = new Assembly[]{Assembly.Load("Service") };//注意这里是实现类的程序集不是接口程序集
            builder.RegisterAssemblyTypes(assemblies)
                .Where(type => !type.IsAbstract) //过滤掉抽象方法
                .AsImplementedInterfaces()   //注册所有的接口
                .PropertiesAutowired();       //属性注入

            var container = builder.Build();
            //注册系统级别的 DependencyResolver，这样当 MVC 框架创建 Controller 等对象的时候都是管 Autofac 要对象。
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}
