using System;

namespace PetShop
{

    interface ICatchMice
    {
       void CatchMice();
    }

    interface IClimbTree
    {
        void ClimbTree();
    }
     abstract public class Pet           //包含抽象方法，必须写成抽象类，抽象类不能被实例化
    {
        public Pet(string name)
        {
            _name = name;
        }
        protected string _name;
        public void PrintName()
        {
            Console.WriteLine("pet's name is "+_name);
           
        }

        // virtual public void Speak()             //虚方法
        //{
        //     Console.WriteLine(_name+" is speaking");
        // }
        abstract public void Speak();        //抽象方法
    }

    public class Dog : Pet
    {
        static int Num;
        static Dog()
        {
            Num = 0;
        }
        new public void PrintName()         //用new 关键字隐藏基类的方法
        {
            Console.WriteLine("宠物的名字是"+_name);
        }
        sealed override public void Speak()           //用override进行重写
        {
            Console.WriteLine(_name + " is speaking:"+"wangwang");
        }

        public Dog(string name):base(name)
        {
            ++Num;
        }

        static public void ShowNum()
        {
            Console.WriteLine("Dog's number is "+Num);
        }
    }
    public class Labrador : Dog
    {
        public Labrador(string name) : base(name)
        { 
        }
       // override public void Speak()      因为Dog类中重写Speak方法时使用了sealed密闭，所以这里不能重写
       // { }
    }
    //public static implicit operator Cat(Dog dog) //隐式转换
    //{
   //     return new Cat(dog._name);
   // }

    static class PetGuide
    {
        static public void HowToFeedDog(this Dog dog)
        {
            Console.WriteLine("Play a vedio about how to feed a dog");
        }
    }
    public class Cat : Pet,ICatchMice,IClimbTree
    {
        override public void Speak()
        {
            Console.WriteLine(_name + " is speaking:"+"miao");
        }

        public Cat(string name):base(name)     //继承基类的构造函数
        {
            
        }
        public void CatchMice()
        {
            Console.WriteLine("Catch mice");
        }
        public void ClimbTree()
        {
            Console.WriteLine("Climb tree");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            // Pet dog = new Dog();
            //dog._name = "Jack";
            // dog.PrintName();
            // Pet cat = new Cat();        //基类的引用
            // cat._name = "Tom";
            //  cat.PrintName();
            // dog.Speak();
            // cat.Speak();
            Pet[] pets = new Pet[] {new Dog("Jack"),new Cat("Tom"),new Dog("jack2") };

            for (int i = 0; i < pets.Length; i++)
            {
                pets[i].PrintName();
                pets[i].Speak();
            }

            Cat c = new Cat("Tom2");
            IClimbTree climb = (IClimbTree)c;
            c.ClimbTree();
            climb.ClimbTree();
            ICatchMice catchM = (ICatchMice)c;
            c.CatchMice();
            catchM.CatchMice();

            Dog.ShowNum();

            Dog dog = new Dog("jack3");
            dog.HowToFeedDog();

            {
                int i = 3;
                object oi = i;  //装箱
                Console.WriteLine("i="+i+"oi="+oi.ToString());
                oi = 10;   //存储在堆中
                i = 7;   //存储在栈中
                Console.WriteLine("i=" + i + "oi=" + oi.ToString());
                int j = (int)oi;   //拆箱
                Console.WriteLine("j="+j);
            }

            Console.Read();
            
        }
    }
    
}
