using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08抽象类
{
    class Program
    {
        static void Main(string[] args)
        {
            //抽象类不予许创建对象
            Animal a = new Cat();//new Dog();
            a.Bark();
            Console.ReadKey();

        }
    }
    abstract class Animal
    {
        public abstract void Bark();

        private string _name;

        public string Name
        {
            get
            {
                return _name;
            }

            set
            {
                _name = value;
            }
        }

        public int Age1
        {
            get
            {
                return Age;
            }

            set
            {
                Age = value;
            }
        }

        private int Age;
    }

    class Dog : Animal
    {
        public override void Bark()
        {
            Console.WriteLine("狗叫");
        }

    }
    class Cat : Animal
    {
        public override void Bark()
        {
            Console.WriteLine("猫叫");
        }
    }
}
