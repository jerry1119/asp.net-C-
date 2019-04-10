using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _02获得页面中所有职位
{
    class Program
    {
        static void Main(string[] args)
        {
            //D:\BaiduYunDownload\传智2015 24期.net无加密版\2015-04-18\北京婚礼策划招聘_北京婚礼策划师招聘_北京招聘婚礼策划师助理-北京58同城.html
            //<a.+?_t=.+?>(?<work>.+?)</a>
            string path = @"D:\BaiduYunDownload\传智2015 24期.net无加密版\2015-04-18基础加强4(更多视频教程关注微信公众号菜鸟要飞)\资料\资料\北京58同城.html";
            WebClient web = new WebClient();
           byte[] buffer =  web.DownloadData(path);
            string html = Encoding.UTF8.GetString(buffer);
            MatchCollection mc = Regex.Matches(html, "<a.+?_t=.+?>(?<work>.+?)</a>");
            foreach (Match item in mc)
            {
                if (item.Success)
                {
                    Console.WriteLine(item.Groups["work"].Value);
                }
            }
            Console.ReadKey();
        }
    }
}
