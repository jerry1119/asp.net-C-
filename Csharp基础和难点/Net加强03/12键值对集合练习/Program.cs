using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12键值对集合练习
{
    class Program
    {
        static void Main(string[] args)
        {
            //Welcome ,to Chinaworld
            string str = "Welcome ,to Chinaworld";
            Dictionary<char, int> dic = new Dictionary<char, int>();
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == ' ' || str[i] == ',')
                {
                    continue;
                }
                if (!dic.ContainsKey(str[i]))
                {
                    dic.Add(str[i], 1);
                }
                else
                {
                    dic[str[i]]++;
                }
            }
            foreach (KeyValuePair<char, int> kv in dic)
            {
                Console.WriteLine("字母{0}出现了{1}次",kv.Key,kv.Value);
            }
            Console.ReadKey();
        }
    }
}
