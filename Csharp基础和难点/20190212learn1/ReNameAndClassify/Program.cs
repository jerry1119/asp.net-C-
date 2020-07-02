using System;
using System.Collections.Generic;
using System.IO;


namespace ReNameAndClassify
{
    class Program
    {
        static void Main(string[] args)
        {
            //string filepath = Console.ReadLine();
            //string[] paths = Directory.GetDirectories(filepath);
            //for (int i = 0; i < paths.Length; i++)
            //{
            //    //string directoryName = Path.GetFileName(paths[i]);
            //    //string  newName = directoryName.Split(')',2)[1];
            //    //string newName = Path.GetFileName(paths[i]);
            //    //string directoryPath = null;
            //    //if (newName.Contains("正"))
            //    //{
            //    //    newName = newName.Split(')', 2)[1];
            //    //    directoryPath = @"Z:\漫之学院合集\无修正\" + newName;
            //    //    Console.WriteLine((i + 1).ToString() + "  " + directoryPath);
            //    //    Directory.Move(paths[i], directoryPath);
            //    //}
            //    //else
            //    //{
            //    //    directoryPath = @"Z:\漫之学院合集\修正\" + newName;
            //    //    Console.WriteLine((i + 1).ToString() + "  " + directoryPath);
            //    //    Directory.Move(paths[i], directoryPath);
            //    //}

            //    //string directoryName = Path.GetFileName(paths[i]);
            //    //if (directoryName.Contains(']'))
            //    //{
            //    //    string newDirectoryName = directoryName.Substring(0, directoryName.IndexOf(']') + 1);
            //    //    //Console.WriteLine(newDirectoryName);
            //    //    string newFileName = directoryName.Substring(directoryName.IndexOf(']') + 1);
            //    //    string newDirectoryPath = @"Z:\漫之学院合集\youxiu\" + newDirectoryName;
            //    //    if (!Directory.Exists(newDirectoryPath))
            //    //    {
            //    //        Directory.CreateDirectory(newDirectoryPath);
            //    //    }

            //    //    Console.WriteLine(i+"   "+newFileName);
            //    //    Directory.Move(paths[i],newDirectoryPath+"\\"+newFileName);
            //    //}


            //    //string[] paths2 = Directory.GetDirectories(paths[i]);
            //    //for (int j = 0; j < paths2.Length; j++)
            //    //{
            //    //    string directoryName = Path.GetFileName(paths2[j]);
            //    //    if (directoryName!=directoryName.Trim())
            //    //    {
            //    //        Directory.Move(paths2[j], paths2[j].Replace(directoryName, "") + directoryName.Trim());
            //    //    }
            //    //}

            //    //Console.WriteLine("ss");
            //}
            string directoryPath = Console.ReadLine();
            ListFiles(new DirectoryInfo(directoryPath));
            Console.WriteLine(list.Count);
            for (int i = 0; i < list.Count; i++)
            {
                //string fileName = Path.GetFileName(list[i]);
                //if (fileName.Contains(']'))
                //{
                //    if (fileName.Length - fileName.IndexOf(']') > 28)
                //    {
                //        fileName = fileName.Substring(fileName.IndexOf(']') + 1);
                //    }
                //}
                //else if (fileName.Contains("修正)"))
                //{
                //    fileName = fileName.Substring(fileName.IndexOf("修正)") + 3);
                //}
                //else if (fileName.Contains("アニメ)"))
                //{
                //    fileName = fileName.Substring(fileName.IndexOf("アニメ)") + 4);
                //}
                //else
                //{
                //    continue;
                //}

                //if (fileName.Length < 12)
                //{
                //    fileName = Path.GetFileName(list[i]);
                //}
                //if (!fileName.Contains(".jpg"))
                //{
                //    continue;
                //}
                ////if (fileName.Contains("预览"))
                ////{
                ////    fileName = fileName.Replace("预览", "thumb");
                ////}
                //else
                //{
                //    //fileName = Path.GetFileNameWithoutExtension(list[i])+"-poster.jpg";
                //    fileName = "poster.jpg";
                //}

                string fileName = Path.GetFileName(list[i]);
                string newPath = Path.GetDirectoryName(list[i]) + "\\" + fileName.Trim();
                if (fileName!=fileName.Trim())
                {
                    File.Move(list[i], newPath);
                    Console.WriteLine(i + "  " + newPath);
                }
                else
                {
                    Console.WriteLine(i+"   skip");
                }
            }
            Console.ReadKey();
        }
        public static List<string> list = new List<string>();
        public static void ListFiles(FileSystemInfo info)
        {
            if (!info.Exists) return;

            DirectoryInfo dir = info as DirectoryInfo;
            //不是目录 
            if (dir == null) return;

            FileSystemInfo[] files = dir.GetFileSystemInfos();
            for (int i = 0; i < files.Length; i++)
            {
                FileInfo file = files[i] as FileInfo;
                //是文件 
                if (file != null)
                    list.Add(file.FullName);
                //对于子目录，进行递归调用 
                else
                    ListFiles(files[i]);

            }
        }
    }
}
