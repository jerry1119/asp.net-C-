using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10键值对集合练习
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = "1壹 2贰 3叁 4肆 5伍 6陆 7柒 8捌 9玖 0零";
            Dictionary < char,char> dic = new Dictionary<char, char>();
           string[] strNew =  str.Split(new char[] { ' '},StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < strNew.Length; i++)
            {
                dic.Add(strNew[i][0],strNew[i][1]);
            }
            Console.WriteLine("请输入小写，我们将转换成大写");
            string input = Console.ReadLine();
            //123123  乱七八糟abc
            for (int i = 0; i < input.Length; i++)
            {
                if (dic.ContainsKey(input[i]))
                {
                    Console.Write(dic[input[i]]);
                }
                else
                {
                    Console.Write(input[i]);
                }
            }
            Console.ReadKey();
        }
    }
}
