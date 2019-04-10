using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 显示接口案例
{
    class Program
    {
        static void Main(string[] args)
        {
            I1 i = new Person();
            i.Test();
            Console.ReadLine();
        }
    }

    interface I1
    {
        void Test();
    }
    class Person : I1
    {
        public void Test()
        {
            Console.WriteLine("这个Test函数是属于Person的");
        }
        // 显示实现接口：告诉编译器这个函数才是接口，不是类
        void I1.Test()
        {
            Console.WriteLine("显示实现接口");
        }
    }
}
