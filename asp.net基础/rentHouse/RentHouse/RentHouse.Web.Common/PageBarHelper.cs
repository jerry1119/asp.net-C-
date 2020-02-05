using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentHouse.Web.Common
{
    public class PageBarHelper
    {
        //每一页数据的条数
        public int PageSize { get; set; }

        //总数据条数

        public int TotalCount { get; set; }

        //显示出来的页码的最多个数

        public int MaxPageCount { get; set; }

        //当前页的页码  从1开始计算起始页而不是0
        public int PageIndex { get; set; }

        /// <summary>
        /// 链接的格式，约定其中页码用{pn}占位符
        /// </summary>
        public string UrlPattern { get; set; }// "/Role/List?pageIndex={pn}"

        /// <summary>
        /// 当前页的页码的样式名字
        /// </summary>
        public string CurrentPageClassName { get; set; }

        public PageBarHelper()
        {
            this.PageSize = 4;
            this.MaxPageCount = 5;
        }

        public string GetPagerHtml()
        {
            //计算出总页数
            int pageCount = (int) Math.Ceiling(TotalCount * 1.0f / PageSize);
            if (pageCount==1)
            {
                return string.Empty;
            }

            int startPageIndex = Math.Max(1, PageIndex - MaxPageCount / 2);//第一个页码

            int endPageIndex = Math.Min(pageCount, startPageIndex+MaxPageCount-1);//最后一个页码

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<ul>");
            if (PageIndex>1)
            {
                sb.AppendFormat("<li><a href='{0}' class ='{1}'>上一页</a></li>",
                    this.UrlPattern.Replace("{pn}", (PageIndex - 1).ToString()), this.CurrentPageClassName);
            }

            for (int i = startPageIndex; i <= endPageIndex; i++)
            {
                if (i==PageIndex)
                {
                    sb.AppendFormat("<li><a class='{0}'>{1}</a></li>", this.CurrentPageClassName, i);
                }
                else
                {
                    sb.AppendFormat("<li><a href='{0}' class ='{1}'>{2}<a/></li>",
                        this.UrlPattern.Replace("{pn}", i.ToString()), this.CurrentPageClassName,i);
                }
            }

            if (PageIndex<pageCount)
            {
                sb.AppendFormat("<li><a href='{0}' class ='{1}'>下一页</a></li>",
                    this.UrlPattern.Replace("{pn}", (PageIndex + 1).ToString()), this.CurrentPageClassName);
            }
            sb.AppendLine("</ul>");
            return sb.ToString();
        }
    }
}
