using System;
using System.IO;
using System.Text;

namespace outputfileinfo
{
    class Program
    {
        static void Main(string[] args)
        {
            string filepath = Console.ReadLine();
            string [] paths = Directory.GetDirectories(filepath);
            StringBuilder sb = new StringBuilder();
            foreach (var filePath in paths)
            {
                string filename = filePath.Split("\\")[5];
                long fileinfo = FileSize(filePath);
                sb.AppendLine(filename + "," + fileinfo);
            }
            StreamWriter sw = new StreamWriter("file.csv",false,Encoding.UTF8);
            sw.Write(sb.ToString());
            sw.Flush();
            sw.Close();
            Console.ReadKey();
        }

        public static long FileSize(string filePath)
        {
            long temp = 0;
            //判断当前路径所指向的是否为文件
            if (File.Exists(filePath) == false)
            {
                string[] str1 = Directory.GetFileSystemEntries(filePath);
                foreach (string s1 in str1)
                {
                    temp += FileSize(s1);
                }
            }
            else
            {
                //定义一个FileInfo对象,使之与filePath所指向的文件向关联,
                //以获取其大小
                FileInfo fileInfo = new FileInfo(filePath);
                var size = (fileInfo.Length / 1024) / 1024;
                if (size>=1024)
                {
                    size = (size / 1024);
                }
                return size ;
            }
            return temp;
        }
    }
}
