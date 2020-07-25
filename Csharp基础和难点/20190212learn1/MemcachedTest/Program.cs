using System;
using System.Net;
using Enyim.Caching;
using Enyim.Caching.Configuration;
using Enyim.Caching.Memcached;

namespace MemcachedTest
{
    class Program
    {
        static void Main(string[] args)
        {
            MemcachedClientConfiguration config = new MemcachedClientConfiguration(); 
            config.Servers.Add(new IPEndPoint(IPAddress.Loopback, 11211));
            config.Protocol = MemcachedProtocol.Binary;
            MemcachedClient client = new MemcachedClient(config);
            var p = new Person {Age  = 3, Name = "HeJie" }; 
            client.Store(Enyim.Caching.Memcached.StoreMode.Set, "p", p,DateTime.Now.AddSeconds(5));//还可以指定第四个 参数指定数据的过期时间。
            Person p1 = client.Get<Person>("p");
            Console.WriteLine(p1.Name);
            Console.ReadKey();
        }
    }
}
