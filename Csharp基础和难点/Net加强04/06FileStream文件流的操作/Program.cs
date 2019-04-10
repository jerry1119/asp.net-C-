using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _06FileStream文件流的操作
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = string.Empty;
            using (FileStream fsRead = new FileStream(@"C:\Users\hejie\Desktop\工资.txt",
                 FileMode.OpenOrCreate, FileAccess.Read))
            {
                byte[] buffer = new byte[1024*1014*5];
                //实际读取到的字节
                int r = fsRead.Read(buffer, 0, buffer.Length);
                str = Encoding.UTF8.GetString(buffer,0,r);
            }
            Console.WriteLine(str);
            Console.ReadKey();
        }
    }
}
