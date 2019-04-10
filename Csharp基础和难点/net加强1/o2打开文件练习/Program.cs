using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

using System.Threading.Tasks;

namespace _02打开文件练习
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("请输入要打开的文件的路径");
            string filePath = Console.ReadLine();
            Console.WriteLine("请输入要打开的文件的名字");
            string fileName = Console.ReadLine();

            //通过简单工厂模式返回父类

            BaseFile bf = GetFile(filePath,fileName);
            if (bf != null)
            {
                bf.OpenFile();
            }
            Console.ReadKey();
        }

        static BaseFile GetFile(string filePath, string fileName)
        {
            BaseFile bf = null;
            string strExtension = Path.GetExtension(fileName); //3.txt
            switch (strExtension)
            {
                case ".txt":
                    bf = new Txtfile(filePath, fileName);
                    break;
                case ".avi":
                    bf = new AviFile(filePath,fileName);
                    break;
                case ".mp4":
                    bf = new Mp4file(filePath,fileName);
                    break;
            }
            return bf;
        }
    }

    class BaseFile
    {
        //字段、属性、构造函数、函数、索引器
        private string _filePath;//字段命名前面加下划线，第二个单词首字母大写

        public string FilePath  //封装属性的快捷键 ctrl+R+E
        {
            get
            {
                return _filePath;
            }

            set
            {
                _filePath = value;
            }
        }
        //自动属性 prop+两下tab
        public string FileName { get; set; }
        public BaseFile(string filePath, string fileName)
        {
            this.FilePath = filePath;
            this.FileName = fileName;
        }
        public BaseFile()
        {
        }
        //设计一个函数用来打开一个指定的文件
        public void OpenFile()
        {
            ProcessStartInfo psi = new ProcessStartInfo(this.FilePath + "\\"+this.FileName);
            Process pro = new Process();
            pro.StartInfo = psi;
            pro.Start();


        }
    }

    class Txtfile : BaseFile
    {
        //因为子类会默认调用父类的无参数的构造函数、

        public Txtfile(string filePath, string fileName)
            : base(filePath, fileName)
        {
        }
    }

    class Mp4file : BaseFile
    {
        public Mp4file(string filePath, string fileName)
            : base(filePath, fileName)
        { }
    }

    class AviFile : BaseFile
    {
        public AviFile(string filePath, string fileName)
            : base(filePath,fileName)
            { }
    }
}
