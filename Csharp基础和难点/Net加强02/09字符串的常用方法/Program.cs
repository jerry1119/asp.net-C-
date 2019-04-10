using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09字符串的常用方法
{
    class Program
    {
        static void Main(string[] args)
        {
            //string s = null;
            //if (string.IsNullOrEmpty(s))
            //{
            //    Console.WriteLine("是的");
            //}
            //else
            //{
            //    Console.WriteLine("不是");
            //}

            //string str = "abcdefg";
            //Console.WriteLine(str[5]);
            //char[] chs = str.ToCharArray();
            //chs[2] = 'z';
            //foreach (char item in chs)
            //{
            //    Console.WriteLine(item);
            //}
            //char数组------->字符串
            // str = new string(chs);
            //str[2] = 'z';     //字符串类型是只读的，所以会报错，要想该可以像上面那样改为char类型

            //string str = "abCDEfg";
            //Console.WriteLine(str.ToUpper());
            //Console.WriteLine(str.ToLower());

            //string s1 = "aBc";
            //string s2 = "Abc";
            //if (s1 == s2)
            //{
            //    Console.WriteLine("相等");
            //}                //对于字符串而言，“==”和“Equals”都是比较的值本身
            //else
            //{
            //    Console.WriteLine("不相等");
            //}

            //if (s1.Equals(s2))
            //{
            //    Console.WriteLine("相等");
            //}
            //else
            //{
            //    Console.WriteLine("不相等");
            //}

            //string str = "老毕吃了一顿饭，结果老毕火了";
            // int index = str.IndexOf("老",11);
            // Console.WriteLine(index);
            // int index = str.LastIndexOf("老");
            // Console.WriteLine(index);

            //string str = "老毕吃了一顿饭，结果老毕火了";
            //int index = str.IndexOf("，");
            //string strNew = str.Substring(index + 1);
            //Console.WriteLine(strNew);

            //  string str = "张三  ，，--三   ，李，，--四  a  ";
            //string[] strNew = str.Split(new char[] { ',',' ','-'},StringSplitOptions.RemoveEmptyEntries);
            //  Console.WriteLine(strNew);

            //Trim()  TrimEnd()  TrimStart()

            //string s = "         张  ,,,--    三  ,,,--     ";
            //Console.WriteLine(s.Trim(' ',',','-'));

            //string[] names = { "等我", "等我", "额外", "突然" };
            //string res = string.Empty;
            //for (int i = 0; i < names.Length - 1; i++)
            //{
            //    res += names[i] + "|";
            //}
            //Console.WriteLine(res + names[names.Length - 1]);

            //string res =  string.Join("|",100,"账单",'c',3.14,true,5000m);
            // Console.WriteLine(res);

            Console.WriteLine("请输入你要回复的内容");
            string contents = Console.ReadLine();
            //判断contents是否包含敏感词
            if (contents.Contains("傻逼"))
            {
                contents = contents.Replace("傻逼","****");
            }
            Console.WriteLine(contents);
            Console.ReadKey();
        }
    }
}
