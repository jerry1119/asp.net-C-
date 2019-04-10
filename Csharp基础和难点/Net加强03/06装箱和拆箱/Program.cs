using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06装箱和拆箱
{
    class Program
    {
        static void Main(string[] args)
        {
            // ArrayList list = new ArrayList();
            // 00:00:00.0430667
            //  List<int> list = new List<int>();
            //List是泛型已经定义了是int类型，而ArrayList是非泛型
            //需要将每一个值类型的i进行装箱为引用类型，每次都执行了装箱操作所以慢很多
            // 00:00:00.0155605
            //Stopwatch sw = new Stopwatch();
            //sw.Start();
            //for (int i = 0; i < 1000000; i++)
            //{
            //    list.Add(i);

            //}
            //sw.Stop();
            //Console.WriteLine(sw.Elapsed);
            // Test(100);  //方法重载时优先选不会产生装拆箱操作的
            //  int n = 10;
            // IComparable com = n; //接口与值类型之间的装箱或拆箱
            //int n = 10;
            //object o = n;//装箱
            //n = 100;
            //Console.WriteLine(n + "," + (int)o);
            //Console.ReadKey();

            ////int n = 10;
            ////double d = 3.14;
            ////string s = "zhangsan";
            ////Console.WriteLine(n + d + s);

            ////string.Concat()

            //int n = 10;
            //string s1 = n.ToString();
            //string s2 = n.GetType().ToString();//由于GetType()不是虚方法子类没有重写，所以调用时需要通过object来调用，查看IL
            //Console.WriteLine(s1 + "\t\t\t" + s2);

            string s1 = "a";
            int n1 = 10;
            double d1 = 99.9;
            object o = 10;  //这里一次装箱
            string s2 = "x";
            string s3 = s1 + n1 + d1 + o + s2;//2次装箱
            Console.WriteLine(s3);
            Console.ReadKey(); 
            //string.Concat()
            Console.ReadKey();
        }
        static void Test(object o)
        { }
        static void Test1(int n)
        { }
    }
}
