using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _312异步模式
{
    class Program
    {      
        //异步读取文件
        private const string testFile = @"C:\Users\Administrator\Desktop\AsyncReadTest.txt";
        private const int bufferSize = 1024;
        static void Main(string[] args)
        {
            if(File.Exists(testFile))
            {
                File.Delete(testFile);
            }

            using (FileStream stream = File.Create(testFile))
            {
                string fileContent = "御史大夫圣诞节钢结构";
                byte[] contentByte = Encoding.UTF8.GetBytes(fileContent);
                stream.Write(contentByte, 0, contentByte.Length);
            }
            //异步读取文件中的类容
            using (FileStream stream = new FileStream(testFile, FileMode.Open, FileAccess.Read,
                FileShare.Read, bufferSize, FileOptions.Asynchronous))
            {
                byte[] data = new byte[bufferSize];
                ReadFileClass rfc = new ReadFileClass(stream, data);// 将自定义类型对象实例作为参数
                // 开始异步读取
                stream.BeginRead(data, 0, data.Length, userCallback, rfc);
                //模拟其他操作
                Thread.Sleep(3 * 1000);
                Console.WriteLine("主线程执行完毕");
            }
            Console.ReadKey();
        }
        /// <summary>
        /// 完成异步操作后的回调方法
        /// </summary>
        /// <param name="ar">状态对象</param>
        private static void userCallback(IAsyncResult ar)
        {
            ReadFileClass rfc = ar.AsyncState as ReadFileClass;
            if(rfc != null)
            {
                // 必须的步骤：让异步读取占用的资源被释放掉
                int length = rfc.stream.EndRead(ar);
                // 获取读取到的文件内容
                byte[] fileData = new byte[length];
                Array.Copy(rfc.data, 0, fileData, 0, fileData.Length);
                string content = Encoding.UTF8.GetString(fileData);
                // 打印读取到的文件基本信息
                Console.WriteLine("读取文件结束：文件长度为[{0}]，文件内容为[{1}]", length.ToString(), content);
            }
        }
    }
    /// <summary>
    /// 传递给异步操作的回调方法,// 以便回调方法中释放异步读取的文件流
    /// </summary>
    public class ReadFileClass
    {
        public FileStream stream;
        public byte [] data;//文件内容

        public ReadFileClass(FileStream stream, byte [] data)
        {
            this.stream = stream;
            this.data = data;
        }
    }
}
