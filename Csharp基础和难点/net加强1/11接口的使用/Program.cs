using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11接口的使用
{
    class Program
    {
        static void Main(string[] args)
        {
            //实现多态
            IKouLan k1 = new Driver();//new Teacher();//new Student();
            k1.koulan();
            //Driver d = new Driver();
            //d.koulan();
            //d.CHLSS();
            //Person p = new Driver();
            //p.CHLSS();
            Console.ReadKey();

        }
        
    }
    class Person
    {
        public void CHLSS()
        {
            Console.WriteLine("人可以吃喝拉撒睡");
        }
    }
    interface IKouLan     //接口
    {
        void koulan();
    }
    class Teacher : Person, IKouLan
    {
        public void koulan()
        {
            Console.WriteLine("教师也可以扣篮");
        }
    }
    class Student : Person, IKouLan
    {
        public void koulan()
        {
            Console.WriteLine("学生也扣篮");
        }
    }
    class Driver : Person, IKouLan
    {
        public void koulan()
        {
            Console.WriteLine("司机也扣篮");
        }
    }
    class DisabledPeople : Person
    {
    }
}
