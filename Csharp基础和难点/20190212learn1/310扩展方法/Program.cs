using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _310扩展方法
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> list = new List<Person>();
            list.Add(new Person() { ID = 1, Name = "hnags", Age = 5 }); //直接在实例化对象的时候后面写个大括号给属性赋值，叫做对象初始化器
            list.Add(new Person() { ID = 1, Name = "Big Yellow", Age = 10 } );
            list.Add(new Person() { ID = 2, Name = "Little White", Age = 15 });
            // 扩展方法是为了对类进行扩展, 这里的where就是List的一个 扩展方法
            //var datas = list.Where(delegate (Person p) { return p.Age > 1; });
            var datas = list.Where((Person p)=> p.Age > 5);  //用 lambda表达式简写
            foreach (Person data in datas)
            {
                Console.WriteLine(data.FormatOutput());
            }

            Console.ReadKey();
        }
    }
    //自定义扩展方法
    //特点是静态类，静态方法，this关键字
    public static class PersonExtension
    {
        public static string FormatOutput(this Person p)
        {
            return string.Format("ID:{0},Name:{1},Age:{2}",
                p.ID, p.Name, p.Age);
        }
    }

    public class Person
    {      
        public int ID { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }
    }
}
