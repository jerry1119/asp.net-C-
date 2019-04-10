using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 封装练习
{
    class Program
    {
        static Dog dog;
        static void Main(string[] args)
        {

            Child child = new Child();//声明和实例化对象//调用构造方法
            child.PlayBall(); //调用方法
            child.EatSugar("榴莲糖");//实参，将会传递到方法中的形参
            child.EatSugar(4);
            child.EatSugar("牛奶糖",3);
            int sum;//和
             sum = child.Add(3,7);
            Console.WriteLine("和是"+sum);  //return 将结果返回
            //用有参数构造方法初始化对象
            Child child1 = new Child("翠花",Gender.女,5);
            Console.WriteLine("我是{0}，性别是{1}，年龄是{2}",child1.Name,child1.Sex,child1.Age);
            //用无参数构造方法初始化对象
            Child child2 = new Child();
            child2.Name = "小美";
            child2.Age = 4;
            //用对象初始化器初始化对象(实际上也是使用的无参构造方法)
            Child child3 = new Child {Name = "周杰伦",Age = 5 };

            //Dog dog = new Dog();
            dog.Name = "小白";
            dog.Sing();


            Child c1 = new Child("刘有才",Gender.男,3);
           // Growth(c1);//按引用传参，方法修改形参，通常实参也会被修改
            Growth(c1.Age);//按值传参，方法修改形参，实参不会被修改
            Console.WriteLine("我现在{0}岁了！",c1.Age);

            int age = 3;
            int ly, ny;
            Growth(age,out ly,out ny);
            Console.WriteLine("我明年{0}岁，去年{1}岁",ny,ly);
            Console.Read();

        }

        static void Growth(Child child)//引用类型参数，按引用传参
        {
            child.Age++;
            Console.WriteLine("1我又长大了一岁");
        }

        static void Growth(int age)//值类型参数，按值传参,若想要按引用传参，则可用ref关键字
        {
            age++;
            Console.WriteLine("2我又长大了一岁");
        }

        static void Growth(int age,out int lastyear,out int nextyear)
        {
            lastyear = age - 1;
            nextyear = age + 1;
        }

        
    }
}
//构造方法的作用 ： 为属性赋值
//如果没有显示构造方法，则会有一个默认的无参的构造方法也就是（）里是空的
//如果显示定义了构造方法，则没有默认的构造方法
//只能用new 方法名()的形式调用构造方法
//构造方法通常声明为public
//构造方法没有返回值类型
//构造方法名必须与类名相同