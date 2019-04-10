using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace _01进程
{
    class Program
    {
       
        static void Main(string[] args)
        {
            //存储着当前正在运行的程序
            
            //Process[] pro =  Process.GetProcesses();//alt+shift+f10导入命名空间
            // foreach (var item in pro)
            // {

            //    Console.WriteLine(item.ProcessName);
            // }

            // Process.Start("iexplore","http://www.baidu.com");
            // Process.Start("notepad");//打开记事本
            // Process.Start("mspaint");//打开画图工具

            //使用进程来打开文件

            //封装我们要打开的文件  但是并不去打开这个文件
            ProcessStartInfo psi = new ProcessStartInfo(@"E:\qq\Bin\QQScLauncher.exe");
            //创建进程对象
            Process pro = new Process();
            //告诉进程要打开的文件信息
            pro.StartInfo = psi;
            //调用函数打开
            pro.Start();



            Console.ReadKey();

        
        }
    }
}
