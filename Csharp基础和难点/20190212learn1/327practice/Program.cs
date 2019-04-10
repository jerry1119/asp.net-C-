using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _327practice
{
    class Program
    {
        static void Main(string[] args)
        {
            Person [] p = { new Teacher(),new Driver(),new Student()};
            for (int i = 0; i < p.Length; i++)
            {
                p[i].SayHello();
            }
            p[2].Eat();
            Student a = new Student();
            a.Eat();
            Test1 test1 = new Test1();
            Console.WriteLine(test1.aa); //也就是说抽象类可以有字段而接口不能
            test1.Cat();
            Console.ReadKey();
        }
    }

    class Person
    {
        public virtual void SayHello()
        {
            Console.WriteLine("我是学生");
        }
        public void Eat()
        {
            Console.WriteLine("人吃什么");
        }
    }
    class Teacher :Person
    {
        public override void SayHello()
        {
            Console.WriteLine("我是老师");
        }
    }
    class Driver : Person
    {
        public override void SayHello()
        {
            Console.WriteLine("我是司机");
        }
    }
    class Student:Person
    {
        //父类已经有一个相同的方法了，并且继承下来了,所以要加一个 new 关键字来隐藏父类的成员
        public new void Eat()
        {
            Console.WriteLine("学生吃什么");
        }
    }
    abstract class Test
    {
        public string aa = "sads";
        public abstract void Cat();
       
       
    }
    class Test1 : Test
    {
        public override void Cat()
        {
            Console.WriteLine("cat");
        }
    }
}
