using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practice
{
    class Program
    {
        /* static void Main(string[] args)
         {
             string[,] nscore = new string[4,2] {
                 {"张三","98" }, {"李四","88" }, {"王五","96" }, {"何杰","92" }
             };
             int i = 0;
             for (i = 0; i < nscore.GetLongLength(0) - 1; i++)
             {
                 int temp1 = int.Parse(nscore[i, 1]);
                 int temp2 = int.Parse(nscore[i + 1, 1]);
                 String str = null;
                 if (temp1 > temp2)
                 {
                     str =nscore [i];
                     nscore[i, 1] = nscore[i + 1, 1];//中间这里
                     nscore[i + 1, 1] = str;
                 }
             }
             Console.WriteLine(nscore[i,0]+nscore[i,1]);
             Console.Read();
         }
         //暂时得出结论，C#中不能直接在二维数组中直接引用一维数组，中间这里只能交换分数
         不能直接交换一维数组，但是java中可以
         
       
        
         */

        /*
         static void Main(string[] args)
         {
             //分别定义两个一维数组的方法。
             string[] name = new string[] {
                 "吴松","钱东宇","胡晨","程璐"
             };
             int[] score = new int[] {89,90,98,56 };
             int max = score[0];
             int n = 0;

             for (int i = 1; i < score.Length; i++)
             {


                 if (score[i] > max)
                 {
                     max = score[i];
                     n = i;
                 }
             }
             Console.WriteLine("分数最高的是{0},分数是{1}",name[n],max);
             Console.Read();


             //用二维数组来解决的正确方法
             string[,] info = new string[,] {
                 {"吴松","89" }, {"钱东宇","90" }, {"胡晨","98" }, {"程璐","56" }
             };
             string name1 = " ";
             int max1 = int.Parse(info[0,1]);
             for (int j = 1; j < info.GetLongLength(0); j++)
             {
                 if (int.Parse(info[j, 1]) > max1)
                 {
                     max1 = int.Parse(info[j, 1]);
                     name1 = info[j, 0];
                 }
             }
             Console.WriteLine("分数最高的是{0}，分数是{1}",name1,max1);
             Console.Read();
         }
         */
        /*static void Main(string[] args)
        {
            string[] name = new string[] {

                "景珍","林惠洋","成蓉","洪南昌","龙玉民","单江开","田武山","王三明"
            };
            int[] score = new int[] {
                90,65,88,70,46,81,100,68
            };
            int sum = 0;
            for (int i = 0; i < score.Length; i++)
            {
                sum += score[i];
            }
            int avg = sum / score.Length;
            Console.WriteLine("平均分是"+avg+",高于平均分的有：");
            
            for (int i = 0; i < score.Length; i++)
            {
                if (score[i] > avg)
                {
                    Console.Write(name[i] + " ");
                }
            }
            Console.Read();
        }
        */
        static void Main(string[] args)
        {
            string[] name = new string[8];
            int[] num = new int[8];
            for (int x = 0; x < name.Length; x++)
            {
                Console.WriteLine("请输入要记录的同学姓名：");
                name[x] = Console.ReadLine();
                Console.WriteLine("请输入要记录的同学分数：");
                num[x] = int.Parse(Console.ReadLine());

            }
            int sum = 0, avg;
            for (int i = 0; i < num.Length; i++)
            {
                sum += num[i];

            }
            avg = sum / num.Length;
            Console.WriteLine("平均分为：" + avg);
            for (int y = 0; y < num.Length; y++)
            {
                if (num[y] > avg)
                    Console.WriteLine("高于平均分的有：" + name[y] + " ");
            }
        }
    }
    
}
