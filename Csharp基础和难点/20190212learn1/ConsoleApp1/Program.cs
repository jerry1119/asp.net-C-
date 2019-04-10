using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


delegate void NumberChanger(int n);
namespace ConsoleApp1
{
    class Program
    {
        static int num = 10;
        public static void AddNum(int p)
        {
            num += p;
            Console.WriteLine("Named Method: {0}", num);
        }

        public static void MultNum(int q)
        {
            num *= q;
            Console.WriteLine("Named Method: {0}", num);
        }
        static void Main(string[] args)
        {
            #region MyRegion
            //string ss = "abcdefg 某某某";
            //int a = System.Text.Encoding.Default.GetBytes(ss).Length;
            //int b = ss.Length;
            //Console.WriteLine(a.ToString() + "aa" + b.ToString());
            //Console.ReadKey();

            //List<int> nums = new List<int>();
            //Random r = new Random();
            //for (int i = 0; i < 100; i++)
            //{
            //    int a = r.Next(1,101);
            //    if(nums.Contains(a))
            //    {
            //        i--;
            //    }
            //    else
            //    {
            //        nums.Add(a);
            //        //Console.WriteLine(i+"    "+a.ToString());
            //    }
            //}
            //Console.WriteLine("ssss");
            //for (int j = 0; j < nums.Count; j++)
            //{
            //    Console.WriteLine(nums[j].ToString());
            //}
            //Console.WriteLine(nums.ToString());

            //正确解法
            //List<int> nums = new List<int>();
            //List<int> values = new List<int>();
            //Random r = new Random();
            //for (int i = 1; i < 101; i++)
            //{
            //    nums.Add(i);
            //}
            //for (int j = 101; j >1 ; j--)
            //{
            //    int a = r.Next(1, j);
            //    values.Add(nums[a-1]);
            //    nums.RemoveAt(a-1);
            //}
            //for (int k = 0; k < values.Count; k++)
            //{
            //    Console.WriteLine(k+1 + "sssss" + values[k].ToString());
            //}

            //Console.ReadKey(); 
            #endregion

           // 使用匿名方法创建委托实例
            NumberChanger nc = delegate(int x)
            {
               Console.WriteLine("Anonymous Method: {0}", x);
            };
            
            // 使用匿名方法调用委托
            nc(10);

            // 使用命名方法实例化委托
            nc =  new NumberChanger(AddNum);
            
            // 使用命名方法调用委托
            nc(5);

            // 使用另一个命名方法实例化委托
            nc =  new NumberChanger(MultNum);
            
            // 使用命名方法调用委托
            nc(2);
            Console.ReadKey();
        }
    }
}
