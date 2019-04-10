using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 封装练习
{
    class Child
    {
        //封装的快捷键 Ctrl +R + E
        private  Gender sex = Gender.男 ;//性别

        public Gender Sex
        {
            get
            {
                return sex;
            }

            //这里删掉set块，使Sex变为只读属性
        }

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

        private string _name;//名字
        private int _age;//年龄
        public int Age {
            get { return _age; }
            set { _age = value; }
        }

        public int Height
        {
            get
            {
                return _height;
            }

            set
            {
                _height = value;
            }
        }

        private int _height;//身高

        public void PlayBall() //方法的声明(这是无参方法)
        {// 方法体or方法的实现
            Console.WriteLine("踢足球啦！");
        }
        //有参方法     "sugar"  糖的类型（形参） 在调用方法时实参把值传递给它
        public void EatSugar(string sugar)
        {
            if (sugar == "榴莲糖")
            {
                Console.WriteLine("不喜欢吃");
                return; //关键字：return  结束方法的调用,返回到方法的调用者
            }
            else {
                Console.WriteLine("喜欢吃");
            }
        }
        public void EatSugar(int count)
        {
            if (count > 3)
            {
                Console.WriteLine("吃太多不好");
            }
            else
            {
                Console.WriteLine("吃吧");
            }
        }
        public void EatSugar(string sugar, int count) //两种类型的参数
        {
            if (sugar == "牛奶糖" && count > 2)
            {
                Console.WriteLine("牛奶糖不能吃太多");
            }
            else if (count > 3)
            {
                Console.WriteLine("糖不能吃太多了");
            }
            else {
                Console.WriteLine("吃糖糖吧!");

            }
        }
        //方法的重载：同一个类中，多个方法名字相同但参数（类型或数量）不同。
        //注意：同一个类中，同名方法的参数必须不同。

        public int Add(int n1, int n2)
        {
            int sum = n1 + n2;
            return sum; // 返回值
        }

        public Child() //无参的构造方法
        {

        }

        public Child(string name, Gender sex,int age)//带参的构造方法
        {
            Name = name;
            Age = age;
            this.sex = sex;  //this  当前对象  一般命名不冲突时也可不写this.
                              //主要是为了区分与形参重名的类的方法、成员等

            
        }

        public Child(string name, int age)//构造方法的重载和方法的重载类似
        {
            Name = name;
            Age = age;
        }
    }
}
