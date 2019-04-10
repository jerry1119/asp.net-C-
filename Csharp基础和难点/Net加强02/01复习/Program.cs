using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01复习
{
    class Program
    {
        static void Main(string[] args)
        {
            //作业：定义父亲类Father(姓lastName,财产property,血型bloodType),
            //儿子Son类(玩游戏PlayGame方法),女儿Daughter类(跳舞Dance方法)，
            //调用父类构造函数(:base())给子类字段赋值

            //作业：定义汽车类Vehicle属性（brand(品牌),color（颜色））方法run，
            //子类卡车(Truck) 属性weight载重 方法拉货，轿车(Car) 属性passenger载客数量
            //方法载客

            //Truck t = new Truck("解放牌卡车", VehicleColor.Black, 1000000);
            //t.Lahuo();

            //Car c = new Car("红旗牌轿车", VehicleColor.Red, 5);
            //c.Zaike();

            //作业：计算形状Shape(圆Circle，矩形Square ，正方形Rectangle)的面积、周长

            //Shape shape =new Square(5, 8);// new Circle(5);
            //double area = shape.GetArea();
            //double perimeter = shape.GetPerimiter();
            //Console.WriteLine("面积是{0:0.00}，周长是{1:0.00}",area,perimeter);

            //作业:橡皮rubber鸭子、木wood鸭子、真实的鸭子realduck。三个鸭子都会游泳，
            //而橡皮鸭子和真实的鸭子都会叫，只是叫声不一样，橡皮鸭子“唧唧”叫，
            //真实地鸭子“嘎嘎”叫，木鸭子不会叫.

            IBark bark = new RealDuck();
            bark.Bark();
            Console.ReadKey();


        }
    }

   public class Duck
    {
        public void Swim()
        {
            Console.WriteLine("鸭子都会游泳");
        }
    }
    interface IBark
    {
        void Bark();
    }
    class RubberDuck : Duck, IBark
    {
        public void Bark()
        {
            Console.WriteLine("橡皮鸭子唧唧叫");
        }
    }
    class RealDuck : Duck, IBark
    {
        public void Bark()
        {
            Console.WriteLine("真鸭子嘎嘎叫");
        }
    }
    class WoodDuck : Duck
    { }





    abstract class Shape
    {
        public abstract double GetArea();
        public abstract double GetPerimiter();
    }

    class Circle : Shape
    {
        public double R { get; set; }
        public Circle(int r)
        {
            this.R = r;
        }
        public override double GetArea()
        {
            return Math.PI * R * R;
        }
        public override double GetPerimiter()
        {
            return 2 * Math.PI * R;
        }
    }
    class Square : Shape
    {
        public double Height { get; set; }
        public double Width { get; set; }
        public Square(double height, double width)
        {
            this.Height = height;
            this.Width = width;
        }
        public override double GetArea()
        {
            return Height * Width;

        }
        public override double GetPerimiter()
        {
            return (Height + Width) * 2;
        }
    }










    enum VehicleColor
    {
        Black,
        Red,
        Blue,
        Yellow,
        White
    }

    class Vehicle
    {
        public string Brand { get; set; }
        public VehicleColor Color { get; set; }
        public void Run()
        {
            Console.WriteLine("车都能跑");
        }
        public Vehicle(string brand, VehicleColor color)
        {
            this.Brand = brand;
            this.Color = color;
        }
    }
    class Truck : Vehicle
    {
        public double Weight { get; set; }
        public Truck(string brand, VehicleColor color, double weight) : base(brand, color)
        {
            this.Weight = weight;
        }
        public void Lahuo()
        {
            Console.WriteLine("卡车可以拉{0}KG的货", this.Weight);
        }
    }
    class Car : Vehicle
    {
        public int Passenger { get; set; }
        public Car(string brand, VehicleColor color, int passenger) : base(brand, color)
        {
            this.Passenger = passenger;
        }
        public void Zaike()
        {
            Console.WriteLine("轿车可以拉{0}个人", this.Passenger);
        }

    }














    class Father
    {
        private string _lastName;

        public string LastName
        {
            get
            {
                return _lastName;
            }

            set
            {
                _lastName = value;
            }
        }

        public double Property
        {
            get
            {
                return property;
            }

            set
            {
                property = value;
            }
        }

        public string BloodType
        {
            get
            {
                return bloodType;
            }

            set
            {
                bloodType = value;
            }
        }

        private double property;
        private string bloodType;
        public Father(string lastName, double property, string bloodType)
        {
            this.LastName = lastName;
            this.Property = property;
            this.BloodType = bloodType;
        }
    }
    class Son : Father
    {
        public Son(string lastName, double property, string bloodType) : base(lastName,
            property, bloodType)
        { }
        public void PalyGame()
        {
            Console.WriteLine("儿子可以玩游戏");
        }
    }
    class Daughter : Father
    {
        public Daughter(string lastName, double property, string bloodType) : base(lastName,
            property, bloodType)
        { }
        public void Dance()
        {
            Console.WriteLine("女儿可以跳舞");
        }
    }
}
