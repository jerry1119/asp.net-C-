using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03静态和非静态
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
//静态成员都是先调用的，要尽可能少的使用静态成员，静态成员只有当项目结束时才会被释放
//调用：类名.静态成员名