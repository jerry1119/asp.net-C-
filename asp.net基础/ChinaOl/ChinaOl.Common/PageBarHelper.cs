using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChinaOl.Common
{
    public class PageBarHelper
    {
        public static string GetPageBar(int pageIndex, int pageCount)
        {
            if (pageCount == 1)
            {
                return string.Empty;
            }
            int start = pageIndex - 2;
            if (start < 1)
            {
                start = 1;
            }
            int end = start + 4;
            if (end > pageCount)
            {
                end = pageCount;
                start = end - 4 < 1 ? 1 : end - 4;//别忘了加个判断
            }
            StringBuilder sb = new StringBuilder();
            if (pageIndex > 1)
            {
                sb.AppendFormat("<a href='?pageIndex={0}'class='myPageBar'>上一页</a>",pageIndex-1);
                //href后面不写具体的地址，那么哪个页面调用了这个方法，就会转跳到哪个页面，这样更灵活
            }
            for (int i = start; i <= end; i++)
            {
                if (i == pageIndex)
                {
                    sb.Append(i);
                }
                else
                {
                    sb.AppendFormat("<a href='?pageIndex={0}'class='myPageBar'>{0}</a>", i);
                }
            }
            if (pageIndex < pageCount)
            {
                sb.AppendFormat("<a href='?pageIndex={0}'class='myPageBar'>下一页</a>", pageIndex+1);
            }
            return sb.ToString();
        }
    }
}
