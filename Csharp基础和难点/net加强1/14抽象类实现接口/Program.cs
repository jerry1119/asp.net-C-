using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14抽象类实现接口
{
    class Program
    {
        static void Main(string[] args)
        {
            I1 i = new Boy();//new Girl();
            i.Test();
            Console.ReadKey();
        }
    }
    interface I1
    {
        void Test();
       
    }
    abstract class Person : I1
    {
        public void Test()
        {
            Console.WriteLine("抽象类实现接口");
        }
    }
    class Boy : Person
    {

    }
    class Girl : Person
    { }

}
