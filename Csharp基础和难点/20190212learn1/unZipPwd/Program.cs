using System;
using System.IO;

namespace unZipPwd
{
    class Program
    {
        static void Main(string[] args)
        {
            //解压带密码的文件
            string oldPath = Console.ReadLine();
            string[] allFilePaths = Directory.GetFiles(oldPath);
            Console.WriteLine("there are {0} files\r", allFilePaths.Length);
            string unzipDrictory = Console.ReadLine();
            int i = 0;
            foreach (var filePaths in allFilePaths)
            {
                string fileName = Path.GetFileNameWithoutExtension(filePaths);
                string unZipPath = unzipDrictory + "\\";//+ fileName;
                i++;
                if (Directory.Exists(unZipPath) == false)

                {
                    Directory.CreateDirectory(unZipPath);
                }
                try
                {
                    Console.WriteLine("{0}----Start unzip {1}\r", i, fileName);
                    unZIP(filePaths, unZipPath, "Entropy");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString() + "\r");
                }
            }

            ////压缩
            //string oldPath = Console.ReadLine();
            //string[] allFilePaths = Directory.GetDirectories(oldPath);
            //Console.WriteLine("there are {0} files\r", allFilePaths.Length);
            //string zipDrictory = Console.ReadLine();
            //int i = 0;
            //foreach (var filePaths in allFilePaths)
            //{
            //    string fileName = Path.GetFileName(filePaths);
            //    string ZipPath = zipDrictory + "\\" + fileName+".zip";
            //    i++;
            //    if (Directory.Exists(zipDrictory) == false)
            //    {
            //        Directory.CreateDirectory(zipDrictory);
            //    }
            //    try
            //    {
            //        Console.WriteLine("{0}----Start zip {1}\r", i, fileName);
            //        ZIP(filePaths, ZipPath);
            //    }
            //    catch (Exception ex)
            //    {
            //        Console.WriteLine(ex.ToString() + "\r");
            //    }
            //}
            Console.WriteLine("zip Over");
            Console.ReadKey();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="unZipPath">要压缩的文件夹路径</param>
        /// <param name="zipPath">压缩后文件全路径</param>
        public static void ZIP(string unZipPath, string zipPath)
        {
            System.Diagnostics.Process Process1 = new System.Diagnostics.Process();
            Process1.StartInfo.FileName = "7z.exe";
            Process1.StartInfo.CreateNoWindow = true;
            Process1.StartInfo.Arguments = " a -tzip "+ "\"" + zipPath + "\"" + " " + "\"" + unZipPath + "\""+" -r";
            Process1.Start();
            Process1.WaitForExit();
            Process1.Close();
        }
        /// <summary>
        /// 解压带密码的压缩包（zip;rar都可）
        /// </summary>
        /// <param name="zipFilePath">压缩包路径</param>
        /// <param name="unZipPath">解压后文件夹的路径</param>
        /// <param name="password">压缩包密码</param>
        /// <returns></returns>
        public static void unZIP(string zipFilePath, string unZipPath, string password)
        {
            //    if (!isStallWinrar())
            //    {
            //        Console.WriteLine("本机并未安装WinRAR,请安装该压缩软件!", "温馨提示");
            //        Console.ReadKey();
            //        return false;
            //    }

            System.Diagnostics.Process Process1 = new System.Diagnostics.Process();
            Process1.StartInfo.FileName = "Winrar.exe";
            Process1.StartInfo.CreateNoWindow = true;
            Process1.StartInfo.Arguments = " x -p" + password + " " +"\""+ zipFilePath +"\""+ " " +"\""+ unZipPath+"\"";
            Process1.Start();
            Process1.WaitForExit();
            Process1.Close();
        }
        /// <summary>
        /// 工程压缩包操作类(利用winrar进行解压，故系统上必须安装winrar)
        /// </summary>


        /// <summary>
        /// 判断系统上是否安装winrar
        /// </summary>
        /// <returns></returns>
        //public static bool isStallWinrar()
        //{
        //    RegistryKey the_Reg =
        //        Registry.LocalMachine.OpenSubKey(
        //            @"SOFTWARE\Microsoft\Windows\CurrentVersion\App Paths\WinRAR.exe");
        //    return !string.IsNullOrEmpty(the_Reg.GetValue("").ToString());

        //}
    }
}
