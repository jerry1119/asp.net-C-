using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace embylaunchPotPlayer
{
    class Program
    {
        static void Main(string[] args)
        {
            var url = HttpUtility.UrlDecode(args[0]);
            if (url.Contains("/amv/"))
            {
                url = @"Y:" + url.Substring(20);
            }
            else
            {
                url = @"Z:" + url.Substring(21);
            }
            //Console.WriteLine(HttpUtility.UrlDecode(args[0]));
            //Console.WriteLine(url);
            Process.Start(@"F:\OneDrive - dotnetcore\常用软件\PotPlayer\PotPlayerMini.exe", url);
            //Console.ReadKey();
        }
    }
}
