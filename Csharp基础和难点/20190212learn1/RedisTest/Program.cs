using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack.Redis;

namespace RedisTest
{
    class Program
    {
        static void Main(string[] args)
        {
            PooledRedisClientManager redisMgr = new PooledRedisClientManager("127.0.0.1");
            using (IRedisClient redisClient = redisMgr.GetClient())
            {
                var p = new Person
                {
                    Age = 3, Name = "hejie" 

                };
                redisClient.Set("p", p); 
                var p1 = redisClient.Get<Person>("p");
                Console.WriteLine(p1.Name);
                Console.ReadKey();
            }
        }
    }
}
