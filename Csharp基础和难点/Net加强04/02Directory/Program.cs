using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _02Directory
{
    class Program
    {
        static void Main(string[] args)
        {
            //CreateDirectory:创建一个新的文件夹
            //Delete：删除
            //Move：剪切
            //Exist()判断指定的文件夹是否存在
            //if(! Directory.Exists(@"C:\Users\hejie\Desktop\psw"))
            //{
            //    Directory.CreateDirectory(@"C: \Users\hejie\Desktop\psw");
            //}
            //for (int i = 0; i < 100; i++)
            //{
            //    for (int j = 0; j < 10; j++)
            //    {
            //        Directory.CreateDirectory(@"C: \Users\hejie\Desktop\psw\" + i+"\\"+j);
            //    }
            //}
            //Console.WriteLine("操作成功");

            //移动

            //Directory.Move(@"C:\Users\hejie\Desktop\psw", @"C:\Users\hejie\Desktop\pswNew");
            //Console.WriteLine("移动成功");
            //Directory.Delete(@"C:\Users\hejie\Desktop\pswNew",true);
            //Console.WriteLine("删除成功");

            //获得指定目录下的全路径
            //string [] filesNames =  Directory.GetFiles(@"E:\迅雷下载","*.mp4");
            // foreach (var items in filesNames)
            // {
            //     Console.WriteLine(items);
            // }
            //获得指定目录下的所有文件夹
            //只能获得当前第一目录下的所有的文件夹，要想获得里面所有的文件夹，可以用递归的方法
           string [] dics =  Directory.GetDirectories(@"E:\迅雷下载");
            foreach (string items in dics)
            {
                Console.WriteLine(items);
            }
            Console.ReadKey();
        }
    }
}
