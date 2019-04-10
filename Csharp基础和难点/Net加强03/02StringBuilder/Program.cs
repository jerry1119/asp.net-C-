using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02StringBuilder
{
    class Program
    {
        static void Main(string[] args)
        {
            //string str = string.Empty;
            //StringBuilder sb = new StringBuilder();
            //Stopwatch sp = new Stopwatch();
            //sp.Start();
            //for (int i = 0; i < 100000; i++)
            //{
            //    //str += i;
            //    //00:00:15.4733651
            //    sb.Append(i);
            //    //00:00:00.0179725
            //}
            //sp.Stop();
            //Console.WriteLine(sp.Elapsed);
            //Console.WriteLine(sb.ToString());
            StringBuilder sb = new StringBuilder();
            sb.Append("张三");
            sb.Append("李四");
            sb.Append("王五");
            sb.Insert(1,"新来的");
            sb.Replace("王五","***");
            sb.Remove(0,2);
            Console.WriteLine(sb.ToString());
            Console.ReadKey();


            Console.ReadKey();
        }
    }
}
