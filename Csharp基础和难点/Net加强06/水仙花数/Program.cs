using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 水仙花数
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int n = 100; n < 1000; n++)
            {
                int x = n / 100;
                int y = n / 10 % 10;
                int z = n % 10;
                if (x * x * x + y * y * y + z * z * z == n)
                {
                    Console.WriteLine(n);
                }
           

            }
            Console.ReadKey();
        }
    }
}
