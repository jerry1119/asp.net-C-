using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01File类练习
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\Users\hejie\Desktop\工资.txt";
            string[] contens = File.ReadAllLines(path,Encoding.Default);
            for (int i = 0; i < contens.Length; i++)
            {
               string [] temp =  contens[i].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                contens[i] = temp[0] +" "+ int.Parse(temp [1])*2;
            }
            File.WriteAllLines(path, contens);
            Console.WriteLine("操作成功");
            Console.ReadKey();
            
        }
    }
}
