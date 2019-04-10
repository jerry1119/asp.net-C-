using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _329面试题递归
{
    class Program
    {
        static void Main(string[] args)
        {
           int a =  getNum(0);
            Console.WriteLine(a.ToString());
            Console.WriteLine(getNums().ToString());
            Console.WriteLine(getNumUseWhile().ToString());
            Console.ReadKey();
        }
        //面试题1，斐波那契数列
        public static int getNum( int x)
        {
            if (x <= 0)
            {
                return -1;
            }
            else if (x==1||x == 2)
            {
                return 1;
            }
            else
            {
                return getNum(x - 2) + getNum(x - 1);
            }
            
        }
        //面试题2，穷举法求出1-100的质数
        public static StringBuilder getNums()
        {
            bool a = true;
            StringBuilder sb = new StringBuilder();
            for (int i = 1; i < 101; i++)
            {
                if (i == 1||i==2)
                {
                    sb.Append(i+",");
                    continue;
                }
                for (int j = 2; j < i; j++)
                {
                    if ( i % j == 0)
                    {
                        a = false;
                        break;
                    }
                }
                if (a)
                {
                    sb.Append(i+",");
                }
                else
                {
                    a = true;
                }
            }
            return sb;
        }

        public static StringBuilder getNumUseWhile()
        {
            StringBuilder sb1 = new StringBuilder();
            bool aa = true;
            int x = 1;
            while (x < 101)
            {
                int y = 2;
                while (y < x)
                {
                    if (x % y == 0)
                    {
                        aa = false;
                        break;
                    }
                    y++;
                }
                if (aa)
                {
                    sb1.Append(x+",");
                }
                else
                {
                    aa = true;
                }
                x++;
            }
            return sb1;
        }
    }
}
