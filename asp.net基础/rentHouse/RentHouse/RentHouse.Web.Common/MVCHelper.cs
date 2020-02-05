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
                if (modelState[key].Errors.Count<=0)
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
    }
}