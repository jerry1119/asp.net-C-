﻿using System;
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
            //List<Person> list = new List<Person>();
            //list.Add(new Person() { ID = 1, Name = "hnags", Age = 5 }); //直接在实例化对象的时候后面写个大括号给属性赋值，叫做对象初始化器
            //list.Add(new Person() { ID = 1, Name = "Big Yellow", Age = 10 } );
            //list.Add(new Person() { ID = 2, Name = "Little White", Age = 15 });
            //// 扩展方法是为了对类进行扩展, 这里的where就是List的一个 扩展方法
            ////var datas = list.Where(delegate (Person p) { return p.Age > 1; });
            //var datas = list.Where((Person p)=> p.Age > 5);  //用 lambda表达式简写
            //foreach (Person data in datas)
            //{
            //    Console.WriteLine(data.FormatOutput());
            //}
            var s0 = new Person { Name = "tom", Age = 3, Gender = true, Salary = 6000 };
            var s1 = new Person { Name = "jerry", Age = 8, Gender = true, Salary = 5000 };
            var s2 = new Person { Name = "jim", Age = 3, Gender = true, Salary = 3000 };
            var s3 = new Person { Name = "lily", Age = 5, Gender = false, Salary = 9000 };
            var s4 = new Person { Name = "lucy", Age = 6, Gender = false, Salary = 2000 };
            var s5 = new Person { Name = "kimi", Age = 5, Gender = true, Salary = 1000 };

            List<Person> list = new List<Person>();
            list.Add(s0);
            list.Add(s1);
            list.Add(s2);
            list.Add(s3);
            list.Add(s4);
            list.Add(s5);
            // Any() 是否存在至少一个 ， Max()  Min() 最大最小 First() FirstOrDefault Single()
            Console.WriteLine(list.Any(p=>p.Age>10));
            //等价于
            Console.WriteLine(list.Where(p=>p.Age>10).Any());
            //升序排序
            //var datas = list.OrderBy(p => p.Age);
            //降序排序,多个排序
            //var datas = list.OrderByDescending(p=>p.Age).ThenBy(p=>p.Salary);
            //Skip(n)  Take(n) 常用来分页
            var datas =  list.Skip(1).Take(2);
            //分组,下列为：统计各年龄的平均工资,最高工资
            var Groupdatas = list.GroupBy(p => p.Age);
            foreach (var item in Groupdatas)
            {
                Console.WriteLine(item.Key+":AVG:"+item.Average(p=>p.Salary)+":Max:"+item.Max(p=>p.Salary));
            }
            list.Select(p => new { p.Name, p.Salary });
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
        public bool Gender { get; set; }
        public int Salary { get; set; }
    }
}
