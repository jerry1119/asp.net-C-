using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _09提取页面的所有邮箱
{
    class Program
    {
        static void Main(string[] args)
        {
            WebClient web = new WebClient();
            //UTF-8
            // string html = web.DownloadString(@"D:\BaiduYunDownload\传智2015 24期.net无加密版\2015-04-18基础加强4(更多视频教程关注微信公众号菜鸟要飞)\资料\资料\大家留下email交友吧_email_天涯部落.html");
            byte[] buffer = web.DownloadData(@"D:\BaiduYunDownload\传智2015 24期.net无加密版\2015-04-18基础加强4(更多视频教程关注微信公众号菜鸟要飞)\资料\资料\大家留下email交友吧_email_天涯部落.html");
            string html = Encoding.UTF8.GetString(buffer);
            MatchCollection mc = Regex.Matches(html, @"[0-9a-zA-Z.-]+@\w+(\.[a-zA-Z]+){1,2}");
            List<string> mails = new List<string>();
            foreach (Match item in mc)
            {
                if (item.Success)
                {

                    if (!mails.Contains(item.ToString()))
                    {
                        mails.Add(item.ToString());
                    }
                    
                }
            }
            foreach (string items in mails)
            {
                Console.WriteLine(items);
            }
            Console.WriteLine(mails);
            Console.ReadKey();
        }
    }
}
