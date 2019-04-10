using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace _310匿名方法等
{
    public delegate void DelegateTest(string testName);
    delegate bool DelDemo(int a, int b);
    //泛型委托：
    public delegate T DelegateT<T>(T t1, T t2);
    class Program
    {
        static void Main(string[] args)
        {
            //匿名类  C#3.0的特性
            //var annoyCla1 = new
            //{
            //    ID = 10010,
            //    Name = "EdisonChou",
            //    Age = 25
            //};

            //Console.WriteLine("ID:{0}-Name:{1}-Age:{2}", annoyCla1.ID, annoyCla1.Name, annoyCla1.Age);
            //Console.WriteLine(annoyCla1.ToString());
            //Console.ReadKey();


            //普通委托未简写的使用方法 : 定义一个testFunc方法并作为参数传入委托中
            void TestFunc(string name)
            {
                Console.WriteLine("Hello: " + name);
            }
            DelegateTest dgTest1 = new DelegateTest(TestFunc);
            dgTest1("hejie");
            //由上面的步凑可以看出，我们要声明一个委托实例要为其编写一个符合规定的命名方法。
            //但是，如果程序中这个方法只被这个委托使用的话，总会感觉代码结构有点浪费

            //匿名方法 C#2.0的特性  使用匿名方法声明委托，就会使代码结构变得简洁，也会省去实例化的一些开销。
            //DelegateTest delegateTest2 = new DelegateTest(delegate (string name)
            //{
            //    Console.WriteLine("God," + name);
            //});
            //简写
            //DelegateTest delegateTest2 = delegate (string name)
            //{
            //    Console.WriteLine("God," + name);
            //};
            //最终可简写为Lambda表达式
            DelegateTest delegateTest2 =(string name) => Console.WriteLine("God," + name);

            delegateTest2("hejie");

            //另一个例子：
            DelDemo delDemo = new DelDemo(delegate (int a, int b)
            {
                return a > b;
            });
            Console.WriteLine(delDemo(3, 5));  //输出结果为false
            //简写为Lambda表达式
            DelDemo delDemo1 = ( a, b)=> a > b;
            Console.WriteLine(delDemo(6, 5));

            //泛型委托
       
            DelegateT<int> delegateT = ( x, y) => x + y;
            int t = delegateT(3, 5);
            Console.WriteLine(t);

            //内置委托
            Action action = () => Console.WriteLine("无参无返回值的委托");
            action();
            //通过action的泛型
            Action<string, string> action2 = (a, b) => Console.WriteLine(a+b);
            action2("有参数", "无返回值的委托");
            //有返回值的内置委托
            Func<int, int, string> func = (x1, x2) => (x1 + x2).ToString();
            string ss = func(6, 7);
            Console.WriteLine(ss);
            Console.ReadKey();
        }

        
    }
}
