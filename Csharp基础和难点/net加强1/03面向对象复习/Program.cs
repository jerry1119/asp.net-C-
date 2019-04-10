using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03面向对象复习
{
    class Program
    {
        static void Main(string[] args)
        {
            Person p = new Person('中');
            p.Name = "李四";
            p.Age = -19;
            Console.WriteLine(p.Age);
            Console.WriteLine(p.Gender);
            Console.ReadKey();
        }
    }
}
