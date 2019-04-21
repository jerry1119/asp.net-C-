using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using log4net;

namespace RentHouse.App_Start
{
    public class FrontExceptionFilter : IExceptionFilter
    {
        private ILog logger = LogManager.GetLogger(typeof(FrontExceptionFilter));
        public void OnException(ExceptionContext filterContext)
        {
            logger.ErrorFormat("出现未处理异常:{0}",filterContext.Exception);
        }
    }
}