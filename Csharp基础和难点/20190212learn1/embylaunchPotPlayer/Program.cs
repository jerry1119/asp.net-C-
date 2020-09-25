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
            
            var embyUrl = HttpUtility.UrlDecode(args[0]);
            Console.WriteLine(embyUrl);
            Console.ReadKey();
            string iniPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "embylaunchPotPlayer.ini");
            string playerPath = IniRead("emby", "potplayer", "", iniPath);
            string embyUrlClien = IniRead("emby", "embyUrlClien", "", iniPath);
            string localUrlCllien = IniRead("emby", "localUrlCllien", "", iniPath);
            if (!string.IsNullOrEmpty(embyUrlClien))
            {
                embyUrl = embyUrl.Replace(embyUrlClien, "");
            }

            if (embyUrl.EndsWith("/"))
            {
                embyUrl = embyUrl.Substring(0, embyUrl.Length - 1);
            }
            string localUrl = localUrlCllien + embyUrl.Replace("emby://", "");
            Console.WriteLine(embyUrl);
            Console.WriteLine(localUrl);
            Console.ReadKey();
            Process.Start(playerPath, localUrl);
        }
        public static string IniRead(string section, string key, string def, string filePath)
        {
            StringBuilder sb = new StringBuilder(1024);
            GetPrivateProfileString(section, key, def, sb, 1024, filePath);
            return sb.ToString();
        }

    }
}
