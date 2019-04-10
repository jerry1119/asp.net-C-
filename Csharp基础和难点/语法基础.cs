using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace my1
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Condition
            bool condition = true;
            int ten = 10;
            if (ten > 100)

            {
                Console.WriteLine("True Condition");
                if (true)
                {
                    Console.WriteLine("true");

                }
            }
            else if (ten > 5)
            {
                Console.WriteLine("ten>5 and ten<100");
            }
            else
            {
                Console.WriteLine("ten<=5"); 
            }

            int switchKey = 100;
            switch (switchKey)
            {
                case 10:
                    Console.WriteLine("switchkey is 10");
                    break;
                case 100:
                    Console.WriteLine("switchkey is 100");
                    break;
                default:
                    Console.WriteLine("I don't know switch key");
                    break;

            }
            #endregion
            #region loop
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine(i);
                if (i == 3)
                {
                    continue;
                }
                Console.WriteLine("after condition");
            }

            int n = 1;
            while (n++ < 6)
            {
                Console.WriteLine(" n is {0}",n);
            }

            do
            {
                Console.WriteLine("zisaoyunxingyici");
            }
            while (false);
            #endregion
            #region array
            int[] numbers = new int[5];                    //数组，长度固定的，由同一个类型的数值在里面，根据索引来排列，顺序的存储在计算机中
            string[,] names = new string[5,4];
            byte[][] scores = new byte[5][];

            for (int i = 0; i < scores.Length; i++)  //每个变量的范围就看是在哪个括号内
            {
                scores[i] = new byte[i + 3];
            }
            for (int i = 0; i < scores.Length; i++)
            {
                Console.WriteLine("Length of row{0} is {1} ", i,scores[i].Length);
            }

            int[] numbers2 = new int[5] { 1, 2, 3, 4, 5 };
            int[] numbers3 = new int[] { 1, 2, 3, 4, 5 };
            int[] numbers4 = { 1,2,3,4,5};

            string[,] names2 = { { "g","k"}, {"h","j" } };
            int[][] numberss = { new int[] { 1,2,3},new int[] { 4,5,6,7} };

            Console.WriteLine(numbers2[2]);   //索引,从0开始
            Console.WriteLine(numbers2.Length);
            // IEmunerable,IEmunerator 实现了这两个接口，可以直接用 foreach 遍历
            foreach (int i in numbers2)
            {
                Console.WriteLine(i);
            }
            #endregion
            #region ArrayList and List
            ArrayList al = new ArrayList();  //数组列表可以存储各种类型
            al.Add(5);
            al.Add(100);
            al.Remove(5);
            al.Add("jikexueyuan");

            foreach (var e in al)
            {
                Console.WriteLine(e);
            }

            Console.WriteLine(al[0]);   //索引

            List<int> intList = new List<int>();
            intList.Add(500);
            intList.AddRange(new int[] { 501,502});
            Console.WriteLine(intList.Contains(200));
            Console.WriteLine(intList.IndexOf(501));
            intList.Remove(501);
            intList.Insert(1,1001);
            #endregion
            #region  Hashtable and Dictionary
            Hashtable ht = new Hashtable();
            ht.Add("first","jike");
            ht.Add("second","xueyuan");
            ht.Add(100,1000);
            Console.WriteLine(ht["second"]);
            Console.WriteLine(ht[100]);
            Console.WriteLine(ht[90]);

            Dictionary<string, string> d = new Dictionary<string, string>();
            d.Add("first","jike");
            //d.Add(100, 1000);
            // Console.WriteLine(d["99"]);
            //ConcurrentDictionary

            SortedList<int, int> sl = new SortedList<int, int>();
            sl.Add(5,105);
            sl.Add(2,102);
            sl.Add(10,99);
            foreach (var sle in sl)
            {
                Console.WriteLine(sle.Value);
            }

            //stack, queue
            #endregion

            Console.ReadLine();
        }

    }
}
