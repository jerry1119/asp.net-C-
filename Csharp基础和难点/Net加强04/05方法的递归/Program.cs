using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05方法的递归
{
    class Program
    {
        static void Main(string[] args)
        {
            TellStory();
            Console.ReadKey();
        }
        static int i = 0;
        static void TellStory()
        {
            Console.WriteLine("从前有座山，山里有座庙");
            Console.WriteLine("庙里有个老和尚和小和尚");
            Console.WriteLine("有一天，小和尚哭了，老和尚给小和尚讲了一个故事");

            i++;
            if (i >= 5)
            {
                return;    //函数调用了几次就得return几次才能出去
            }
            TellStory();
        }
    }
}
