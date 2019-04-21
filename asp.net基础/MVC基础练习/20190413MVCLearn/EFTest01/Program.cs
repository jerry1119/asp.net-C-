using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFTest01
{
    class Program
    {
        static void Main(string[] args)
        {
            using (PersonContext ctx = new PersonContext())
            {
                ctx.Database.Delete();
                ctx.Database.Create();
                // Person p = new Person();
                //p.Name = "as";
                //p.Age = 18;
                //p.CreateDateTime = DateTime.Now;
                //Car c = new Car();
                //c.Name = "本田";
                //c.Price = 1000;
                ////p.Cars.Add(c);
                ////c.Person = p;
                ////ctx.Set<Person>().Add(p);
                //ctx.Set<Car>().Add(c);
                //ctx.SaveChanges();
            }
        }
        static void Main2(string[] args)
        {
            using (PersonContext pcx = new PersonContext())
            {
                //EF的作用相当于是帮我们把要进行的操作翻译成sql语句，去执行，这样就不用自己写sql语句了
                //查看EF生成的具体sql语句 database.log
                pcx.Database.Log = sql => { Console.WriteLine("开始执行sql*********************"+sql); };
                //添加
                //Person p = new Person();
                //p.Age = 8;
                //p.CreateDateTime = DateTime.Now;
                //p.Name = "小妹妹";
                //pcx.Persons.Add(p);
                //pcx.Set<Person>().Add(p);这个用法也可以效果同上
                //pcx.SaveChanges();
                //SaveChanges主键的值会自动更新，三层项目好像也是这样呀

                //查询
                var persons = pcx.Persons.Where(ps => ps.Age > 10);
                var cars = pcx.Cars;
                foreach (var car in cars)
                {
                    Console.WriteLine(car.Id);
                }

                foreach (var item in persons)
                {
                    Console.WriteLine(item);
                }
                //删除,先用最简单的先查询出来再删除的方法
                var person =    pcx.Persons.Where(p => p.Id == 4).SingleOrDefault();
                if (person == null)
                {
                    Console.WriteLine("数据已被删除");
                }
                else
                {
                    pcx.Persons.Remove(person);
                    pcx.SaveChanges();
                    Console.WriteLine("删除成功");
                }
                //修改,先查询出来要修改的数据，然后修改
                foreach (var item in pcx.Persons.Where(p=>p.Age>5))
                {
                    item.Age++;
                }
                pcx.SaveChanges();
                //EF调用Skip方法之前必须先调用orderBy,因为虽然默认是ID排序，但有时候可能并不是
                var persons1 = pcx.Persons.OrderBy(p => p.Id).Skip(1).Take(2);
                foreach (var item in persons1)
                {
                    Console.WriteLine(item);
                }
            }
            Console.ReadKey();
        }
    }
}
