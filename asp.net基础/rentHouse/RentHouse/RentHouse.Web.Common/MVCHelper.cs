using System;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace RentHouse.Web.Common
{
    public class MVCHelper
    {
        // 有 两 个ModelStateDictionary 类，别弄混乱了，要用 using System.Web.Mvc; 下的
        public static string GetValidMesg(ModelStateDictionary modelState)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var key in modelState.Keys)
            {
                if (modelState[key].Errors.Count <= 0)
                {
                    continue;
                }
                sb.Append("属性【").Append(key).Append("】错误：");
                foreach (var modelError in modelState[key].Errors)
                {
                    sb.AppendLine(modelError.ErrorMessage);
                }
            }

            return sb.ToString();
        }

        public static string ToQueryString(NameValueCollection nvc)
        {
            StringBuilder sb = new StringBuilder();
            //不确定范围的时候用foreach好点，比如这里
            for (int i = 0; i < nvc.Keys.Count; i++)
            {
                string key = nvc.Keys[i];
                //EscapeDataString就是对特殊字符进行uri编码
                sb.Append(key).Append("=").Append(Uri.EscapeDataString(nvc[key])).Append("&");
            }

            return sb.ToString().Trim('&');
        }
        // 修改 QueryString 中 name 的值为 value，如果不存在，则添加
        // NameValueCollection 存放的是 QueryString 中的键值对 
        public static string UpdateQueryString(NameValueCollection nvc, string name, string value)
        {
            NameValueCollection newNvc = new NameValueCollection(nvc);
            if (newNvc.AllKeys.Contains(name))
            {
                newNvc[name] = value;
            }
            else
            {
                newNvc.Add(name, value);
            }
            return ToQueryString(newNvc);
        }
        // 从 QueryString 中移除 name 的值 
        public static string DeleteQueryString(NameValueCollection nvc, string name)
        {
            NameValueCollection newNvc = new NameValueCollection(nvc);
            if (newNvc.AllKeys.Contains(name))
            {
                newNvc.Remove(name);
            }

            return ToQueryString(newNvc);
        }

        public static string RenderViewToString(ControllerContext context, string viewPath, object model = null)
        {
            ViewEngineResult viewEngineResult = ViewEngines.Engines.FindView(context, viewPath, null); 
            if (viewEngineResult == null) 
                throw new FileNotFoundException("View" + viewPath + "cannot be found.");
            var view = viewEngineResult.View; 
            context.Controller.ViewData.Model = model;
            using (var sw = new StringWriter())
            {
                var ctx = new ViewContext(context, view, context.Controller.ViewData, context.Controller.TempData, sw);
                view.Render(ctx, sw);
                return sw.ToString();
            }
        }
    }
}