using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _15接口登记案例
{
    class Program
    {
        static void Main(string[] args)
        {
            //Person需要登记
            //House需要登记
            //Car也需要登记
            //Monney也需要登记

            //最后写一个函数 来实现以上物品登记

            DengJi(new Person());
            DengJi(new House());
            DengJi(new Car());
            DengJi(new Monney());
            Console.ReadKey();
        }
        static void DengJi(IDengJi dj)
        {
            dj.DengJi();
        }
    }

 

    interface IDengJi
    {
        void DengJi();
    }
    class Person : IDengJi
    {
        public void DengJi()
        {
            Console.WriteLine("Person需要登记");
        }
    }
    class House : IDengJi
    {
        public void DengJi()
        {
            Console.WriteLine("House需要登记");
        }
    }
    class Car : IDengJi
    {
        public void DengJi()
        {
            Console.WriteLine("Car需要登记");
        }
    }
    class Monney : IDengJi
    {
        public void DengJi()
        {
            Console.WriteLine("Monney需要登记");
        }
    }
    
}
