using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Autofac;

namespace IOC容器AutoFac
{
    class Program
    {
        private static IContainer Container { get; set; }

        static void Main(string[] args)
        {
            //IOutput output = new ConsoleOutput();
            //IOutput output2 = new TxtOutput();
            ////output.Write("sdfds");
            ////
            //TodayWrite dateWrite = new TodayWrite(output2);
            //dateWrite.DateWrite();

            //使用IOC容器 AutoFac的方式更简单
            ////1.注册容器的接口
            ContainerBuilder builder = new ContainerBuilder();
            //builder.RegisterType<ConsoleOutput>().As<IOutput>();
            //builder.RegisterType<TxtOutput>().As<IOutput>().SingleInstance();//单例模式
            //builder.RegisterType<TodayWrite>().As<IDateWrite>().PropertiesAutowired();//允许属性注入
            //更简单的方法1.1直接用程序集全部注册
            var asm = Assembly.GetExecutingAssembly();
            //var asn = Assembly.Load("IOC容器AutoFac");
            builder.RegisterAssemblyTypes(asm).AsImplementedInterfaces();//只注册程序集下所有接口
            //2.创建容器，并将容器赋值给属性，好给别的方法用它
            Container = builder.Build();

            WriteDate();
            Console.ReadKey();
        }

        private static void WriteDate()
        {
            //创建一个生命周期，在生命周期内干事,using结束生命周期被释放，任何生命周期解析出的可释放对象也被释放
            using (var scope = Container.BeginLifetimeScope())
            {
                var writer = scope.Resolve<IDateWrite>();
                //容器去实例化DateWriter的时候发现构造函数需要Ioutput，因为注册了两个Ioutput,默认取后面那一个，除非设置PreserveExistingDefaults()等，所以最后是txtOutput
                writer.DateWrite();

                //可以通过这种方式把注册了的全拿到
                //var writers = scope.Resolve<IEnumerable<IOutput>>();
                //foreach (var writer in writers)
                //{
                //    writer.Write(DateTime.Now.ToString());
                //}
            }
        }
    }

    public class ConsoleOutput:IOutput
    {
        public void Write(string content)
        {
            Console.WriteLine(content);
        }
    }
    public class TxtOutput:IOutput
    {
        public void Write(string content)
        {
            using (StreamWriter streamWriter = new StreamWriter(@"C:\Users\Administrator\Desktop\如鹏\1.txt"))
            {
                streamWriter.WriteLineAsync(content);
            }
        }
    }

    public class TodayWrite:IDateWrite
    {
        //构造函数注入,默认找参数最多的那一个构造函数
        private IOutput _output;
        public TodayWrite(IOutput output)
        {
            this._output = output;
        }
        public void DateWrite()
        {
            this._output.Write(DateTime.Now.ToString());
        }
    }

    public interface IDateWrite
    {
        void DateWrite();
    }
    public interface IOutput
    {
        void Write(string content);
    }

    
}
