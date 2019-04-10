using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _312线程同步
{
    class Program
    {
        
        static void Main(string[] args)
        {
            
            // 多线程测试静态方法的同步
            Console.WriteLine("开始测试静态方法的同步：");
            for (int i = 0; i < 5; i++)
            {
                Thread thread = new Thread(Lock.StaticIncrement);
                thread.Start();
            }
            // 这里等待线程执行结束
            Thread.Sleep(5 * 1000);
            Console.WriteLine("-------------------------------");
            // 多线程测试实例方法的同步
            Console.WriteLine("开始测试实例方法的同步：");
            Lock l = new Lock();
            //Monitor.Enter(l);
            for (int i = 0; i < 6; i++)
            {
                Thread thread = new Thread(l.InstanceIncrement);
                thread.Start();
            }

            Console.ReadKey();
        }
    }
    public class Lock
    {
        // 静态方法同步锁
        private static object staticLocker = new object();
        // 实例方法同步锁
        private object instanceLocker = new object();
        //应该完全避免使用this对象和当前类型对象作为同步对象，而应该在类型中定义私有的同步对象，
        //同时应该使用lock而不是Monitor类型，这样可以有效地减少同步块不被释放的情况。

        // 成员变量
        private static int staticNumber = 0;
        private int instanceNumber = 0;

        // 测试静态方法的同步
        public static void StaticIncrement(object state)
        {
            lock (staticLocker)
            {
                Console.WriteLine("当前线程ID：{0}", Thread.CurrentThread.ManagedThreadId.ToString());
                Console.WriteLine("staticNumber的值为：{0}", staticNumber.ToString());
                // 这里可以制造线程并行执行的机会，来检查同步的功能
                Thread.Sleep(200);
                staticNumber++;
                Console.WriteLine("staticNumber自增后为：{0}", staticNumber.ToString());
            }
        }

        // 测试实例方法的同步
        public void InstanceIncrement(object state)
        {
            lock (instanceLocker)
            {
                Console.WriteLine("当前线程ID：{0}", Thread.CurrentThread.ManagedThreadId.ToString());
                Console.WriteLine("instanceNumber的值为：{0}", instanceNumber.ToString());
                // 这里可以制造线程并行执行的机会，来检查同步的功能
                Thread.Sleep(200);
                instanceNumber++;
                Console.WriteLine("instanceNumber自增后为：{0}", instanceNumber.ToString());
            }
        }
    }
}
