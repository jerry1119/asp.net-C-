using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace @string
{
    class Program
    {
        static void Main(string[] args)
        {
            //.net用散列表(java中称做字符串池啥的)保存字符串,当新创建一个字符串的时候,会去散列表中检测这个字符串是不是存在,
            //如果存在返回已经存在的内存地址中的字符串

            string bb = new string('s','s');
            string aa = new string('s','s');

            string cc = "ss";
            string dd = "ss";
            
            Console.WriteLine(string.ReferenceEquals(cc, dd)); 
            //输出结果为true,说明指向了堆中的同一个实例，在栈中保存的为同一个堆的实例的地址
            // 给cc赋值时，在堆中创建了‘ss’实例，cc保存着 'ss'在栈中的地址， 在给dd赋值时，发现堆中已经有了'ss'实例，
            //就直接将'ss'的地址赋值给了dd

            Console.WriteLine(string.ReferenceEquals(aa,bb));//输出结果为false，说明不是相同的实例
                                                             //也就是说 string 用new出来的话，每次回在堆上面开辟空间创建不同的实例

           

            Console.ReadKey();
        }
    }
}
