using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _311多线程
{
    #region 线程的状态
    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        Console.WriteLine("开始测试线程1");
    //        // 初始化一个线程 thread1
    //        Thread thread1 = new Thread(Work1);
    //        // 这时状态：UnStarted
    //        PrintState(thread1);
    //        // 启动线程
    //        Console.WriteLine("现在启动线程");
    //        thread1.Start();
    //        // 这时状态：Running
    //        PrintState(thread1);
    //        // 让线程飞一会 3s
    //        Thread.Sleep(3 * 1000);
    //        // 让线程挂起
    //        Console.WriteLine("现在挂起线程");
    //        thread1.Suspend();
    //        // 给线程足够的时间来挂起，否则状态可能是SuspendRequested
    //        Thread.Sleep(1000);
    //        // 这时状态：Suspend
    //        PrintState(thread1);
    //        // 继续线程
    //        Console.WriteLine("现在继续线程");
    //        thread1.Resume();
    //        // 这时状态：Running
    //        PrintState(thread1);
    //        // 停止线程
    //        Console.WriteLine("现在停止线程");
    //        thread1.Abort();
    //        // 给线程足够的时间来终止，否则的话可能是AbortRequested
    //        Thread.Sleep(1000);
    //        // 这时状态：Stopped
    //        PrintState(thread1);
    //        Console.WriteLine("------------------------------");
    //        Console.WriteLine("开始测试线程2");
    //        // 初始化一个线程 thread2
    //        Thread thread2 = new Thread(Work2);
    //        // 这时状态：UnStarted
    //        PrintState(thread2);
    //        // 启动线程
    //        thread2.Start();
    //        Thread.Sleep(2 * 1000);
    //        // 这时状态：WaitSleepJoin
    //        PrintState(thread2);
    //        // 给线程足够的时间结束
    //        Thread.Sleep(10 * 1000);
    //        // 这时状态：Stopped
    //        PrintState(thread2);

    //        Console.ReadKey();
    //    }

    //    // 普通线程方法：一直在运行从未被超越
    //    private static void Work1()
    //    {
    //        Console.WriteLine("线程运行中...");
    //        // 模拟线程运行，但不改变线程状态
    //        // 采用忙等状态
    //        while (true) { }
    //    }

    //    // 文艺线程方法：运行10s就结束
    //    private static void Work2()
    //    {
    //        Console.WriteLine("线程开始睡眠：");
    //        // 睡眠10s
    //        Thread.Sleep(10 * 1000);
    //        Console.WriteLine("线程恢复运行");
    //    }

    //    // 打印线程的状态
    //    private static void PrintState(Thread thread)
    //    {
    //        Console.WriteLine("线程的状态是：{0}", thread.ThreadState.ToString());
    //    }
    //} 
    #endregion

    class program
    {
        #region 使用线程池创建一个线程
        //static void Main(string[] args)
        //{
        //    string taskinfo = "运行10s";  //相当于这个是带参数的线程的参数
        //   bool result =  ThreadPool.QueueUserWorkItem(func, taskinfo);
        //    if(!result)
        //    {
        //        Console.WriteLine("分配线程失败");
        //    }
        //    else
        //    {
        //        Console.WriteLine("按回车结束");
        //    }

        //    Console.ReadKey();
        //}

        //private static void func(object state)
        //{
        //    for (int i = 0; i < 10; i++)
        //    {
        //        Console.WriteLine("线程运行的任务是{0}",state);
        //        Thread.Sleep(1000);
        //    }

        //} 
        #endregion

        #region 线程的阈值和可用数量
        //static void Main(string [] args)
        //{
        //    // 打印阈值和可用数量
        //    GetLimitation();
        //    GetAvailable();

        //    // 使用掉其中三个线程
        //    Console.WriteLine("此处申请使用3个线程...");
        //    ThreadPool.QueueUserWorkItem(Work);
        //    ThreadPool.QueueUserWorkItem(Work);
        //    ThreadPool.QueueUserWorkItem(Work);

        //    Thread.Sleep(1000);
        //    GetAvailable();
        //    ThreadPool.SetMinThreads(10, 10);
        //    GetLimitation();
        //    Console.ReadKey();
        //}

        //private static void Work(object state)
        //{
        //    Thread.Sleep(10 * 1000);
        //}

        //private static void GetAvailable()
        //{
        //    int avThread; int avIO;
        //    ThreadPool.GetAvailableThreads(out avThread, out avIO);
        //    Console.WriteLine("可用工作线程数为{0}，IO线程数为{1}", avThread,avIO);
        //}

        //private static void GetLimitation()
        //{


        //    int maxThread; int minThread; int maxIO; int minIO;
        //    ThreadPool.GetMaxThreads(out maxThread, out maxIO);
        //    ThreadPool.GetMinThreads(out minThread, out minIO);
        //    Console.WriteLine("最大工作线程数为{0}，最大IO线程数为{2},最小工作线程数为{1}，最小IO线程数为{3}"
        //        , maxThread, minThread,maxIO,minIO);
        //} 
        #endregion

        //线程内共享的变量 使用ThreadStatic 特性
        static void Main(string [] args)
        {
            for (int i = 0; i < 6; i++)
            {
                Thread thread = new Thread(ThredStatic.work);
                thread.Start();
            }

            Console.ReadKey();
        }
    }

    internal class ThredStatic
    {
        [ThreadStatic]
        private static int threadID = 0;  //值类型的线程静态数据

        private static Ref refThreadID = new Ref(); //引用类型的线程静态数据

        public static void work()
        {
            // 存储线程ID，一个应用程序域内线程ID不会重复
            threadID = Thread.CurrentThread.ManagedThreadId;
            refThreadID.id = Thread.CurrentThread.ManagedThreadId;
            Console.WriteLine("线程{0}：静态线程数据为{1}:动态线程数据为{2}", Thread.CurrentThread.ManagedThreadId.ToString(), threadID, refThreadID.id.ToString());
            Thread.Sleep(1000);
            Console.WriteLine("线程{0}：静态线程数据为{1}:动态线程数据为{2}", Thread.CurrentThread.ManagedThreadId.ToString(), threadID, refThreadID.id.ToString());
        }
    }
    public class Ref
    {
        public int id { get; set; }
    }
        
}
