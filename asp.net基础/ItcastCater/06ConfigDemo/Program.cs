using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;


namespace _06ConfigDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //获取配置文件中的Appsetting和connectionstring中的数据
            Console.WriteLine(ConfigurationManager.AppSettings["Version"]);
            Console.WriteLine(ConfigurationManager.ConnectionStrings["sql2"].ConnectionString);
            Console.ReadKey();
        }
    }
}
