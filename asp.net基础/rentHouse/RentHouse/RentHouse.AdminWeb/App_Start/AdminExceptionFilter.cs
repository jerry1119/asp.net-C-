using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using log4net;

namespace RentHouse.AdminWeb.App_Start
{
    public class AdminExceptionFilter : IExceptionFilter
    {
        private static ILog logger = LogManager.GetLogger(typeof(AdminExceptionFilter));
        public void OnException(ExceptionContext filterContext)
        {
            logger.ErrorFormat("出现未处理异常{0}",filterContext.Exception);
        }
    }
}