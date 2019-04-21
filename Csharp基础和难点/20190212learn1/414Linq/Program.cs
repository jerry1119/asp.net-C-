using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _414Linq
{
    class Program
    {
        static void Main(string[] args)
        {
            //Linq和集合的扩展是互通的 ，这两种写法编译成IL代码是一模一样的,有的方法没有对应的Linq写法，只能用集合的扩展方法
            //一般比较简单的语句用 扩展方法就好，复杂的语句比如写Join的时候用Linq更清晰,orderBy的时候也方便一点
            Master m1 = new Master { Id = 1, Name = "yyyy" };
            Master m2 = new Master { Id = 2, Name = "比尔盖茨" };
            Master m3 = new Master { Id = 3, Name = "周星驰" };
            Master[] masters = { m1, m2, m3 };

            Dog d1 = new Dog { Id = 1, MasterId = 3, Name = "旺财" };
            Dog d2 = new Dog { Id = 2, MasterId = 3, Name = "汪汪" };
            Dog d3 = new Dog { Id = 3, MasterId = 1, Name = "京巴" };
            Dog d4 = new Dog { Id = 4, MasterId = 2, Name = "泰迪" };
            Dog d5 = new Dog { Id = 5, MasterId = 1, Name = "中华田园" };
            Dog[] dogs = { d1, d2, d3, d4, d5 };

            //扩展方法的写法
            var r1 = dogs.Where(d=>d.Id>1).Select(d=> new { DogName= d.Name,DogId=d.Id});
            //Linq的写法
            var r2 = from d in dogs
                     where d.Id > 1
                     select new { DogName=d.Name,DogId=d.Id};
            foreach (var item in r2)
            {
                Console.WriteLine(item.DogId+":11"+item.DogName);
            }
            //使用集合的扩展方法 .Jion()的用法
            var result = dogs.Where(d => d.Id > 1).Join(masters, d => d.MasterId, m => m.Id, (d, m) => new { DogName = d.Name, MasterName = m.Name });
            //Linq的写法
            var result2 = from d in dogs
                          where d.Id > 1
                          join m in masters on d.MasterId equals m.Id
                          select new {DogName = d.Name,MasterName = m.Name };
            foreach (var item in result2)
            {
                Console.WriteLine(item.DogName+":"+item.MasterName);
            }
            //OrderBy
            var r3 = from d in dogs
                     orderby d.Id descending
                     select d;
            //Group by
            var r4 = from d in dogs
                     where d.Id <5
                     group d by d.Id into result1
                     select new { result1.Key,MaxMasterId = result1.Max(d=>d.MasterId)};
            foreach (var item in r4)
            {
                Console.WriteLine(item.Key+":     "+item.MaxMasterId);
            }
            Console.ReadKey();
        }
    }
    class Master
    {
        public long Id { get; set; }
        public string Name { get; set; }
    }
    class Dog
    {
        public long Id { get; set; }
        public long MasterId { get; set; }
        public string Name { get; set; }
    }
}
