using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace embylaunchPotPlayer
{
    class Program
    {
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string lpAppName, string lpKeyName, string lpDefault, StringBuilder lpReturnedString, int nSize, string lpFileName);

        static void Main(string[] args)
        {
            var url = HttpUtility.UrlDecode(args[0]);
            string iniPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "embylaunchPotPlayer.ini");
            string playerPath = IniRead("emby", "potplayer", "", iniPath);
            Process.Start(playerPath, url);
        }
        public static string IniRead(string section, string key, string def, string filePath)
        {
            StringBuilder sb = new StringBuilder(1024);
            GetPrivateProfileString(section, key, def, sb, 1024, filePath);
            return sb.ToString();
        }


        //static void Main1(string[] args)
        //{
        //    var url = HttpUtility.UrlDecode(args[0]);
        //    if (url.Contains("/amv/"))
        //    {
        //        url = @"Y:" + url.Substring(20);
        //    }
        //    else
        //    {
        //        url = @"Z:" + url.Substring(21);
        //    }


        //    //Console.WriteLine(HttpUtility.UrlDecode(args[0]));
        //    //Console.WriteLine(url);
        //    Process.Start(@"F:\OneDrive - dotnetcore\常用软件\PotPlayer\PotPlayerMini.exe", url);
        //    //Console.ReadKey();
        //}
    }
}
