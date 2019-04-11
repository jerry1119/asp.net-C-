using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _20190411异步委托
{
    delegate  int AddDel(int a, int b); //定义一个委托类型
    class Program
    {
        static void Main(string[] args)
        {
            AddDel del = new AddDel(AddStaticMethod);
            //int result = del(3, 4);//同步调用
            IAsyncResult result = del.BeginInvoke(3, 4, new AsyncCallback(callback), "传给回调函数的信息");
            //如果想拿到异步委托的结果
            //result.IsCompleted //标志是否完成
            //这样就能拿到结果，但是写在这里主线程会等待子线程的结果，阻塞线程，所以写到回调函数里面
            //int addResult = del.EndInvoke(result);
            Console.WriteLine("主线程执行了："+Thread.CurrentThread.ManagedThreadId);
            Console.ReadKey();
        }
        //异步委托执行的顺序是：主线程创建一个委托对象，往下执行发现是异步调用这个委托方法，就开启一个线程来执行这个委托方法，主线程继续在往下执行，这个委托方法执行完成之后在进入到回调函数通过回调函数来获得他的执行结果
        private static void callback(IAsyncResult ar)
        {
            Console.WriteLine("回调函数被执行了");
            Thread.Sleep(1000);
            Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
            AsyncResult demo = ar as AsyncResult;
            AddDel del = (AddDel)demo.AsyncDelegate; //就是当前的异步委托对象
            int result = del.EndInvoke(ar);

            Console.WriteLine(result);
            Console.WriteLine(demo.AsyncState);
        }

        private static int AddStaticMethod(int a, int b)
        {
            Console.WriteLine("子线程执行了: "+Thread.CurrentThread.ManagedThreadId);
            Thread.Sleep(2000);
            Console.WriteLine("子线程执行了: " + Thread.CurrentThread.ManagedThreadId);
            return a + b;
        }
    }
}
