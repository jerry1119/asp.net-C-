using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02求数组的最大值
{
    public delegate int DelCompare(object o1,object o2 );
    class Program
    {
        static void Main(string[] args)
        {
            object[] nums = { 1,2,3,4,5,6,7,8,9};
            object[] names = { "zhangsan","李四","王五","fdsfsdf的冯绍峰"};
            //把函数直接赋值给委托
            //object max = GetMax(nums, C1);  
            //object max2 = GetMax(names,C2);
            //匿名函数
            // object max = GetMax(nums, delegate (object o1, object o2) { return (int)o1 - (int)o2; });
            // object max2 = GetMax(names, delegate (object o1, object o2) { return ((string)o1).Length - ((string)o2).Length; });
            //Lambda表达式
            object max = GetMax(nums, (o1, o2) => { return (int)o1 - (int)o2; });
            object max2 = GetMax(names, (o1, o2) => { return ((string)o1).Length - ((string)o2).Length; });
            Console.WriteLine(max2);
            Console.WriteLine(max);
            

            object[] pers = { new Person() {Name = "张三",Age = 19 },new Person() { Name = "李四", Age = 29 } };
            //object max3 = GetMax(pers, delegate (object o1, object o2) { return ((Person)o1).Age - ((Person)o2).Age; });
            object max3 = GetMax(pers, (o1, o2) => { return ((Person)o1).Age - ((Person)o2).Age; });
            Console.WriteLine(((Person)max3).Name);
            Console.ReadKey();
        }

        static object GetMax(object[] nums, DelCompare del)
        {
            object max = nums[0];
            for (int i = 0; i < nums.Length; i++)
            {
                if (del(max, nums[i]) < 0)
                {
                    max = nums[i];
                }
            }
            return max;
        }
        static int C1(object o1, object o2)
        {
            int n1 = (int)o1;
            int n2 = (int)o2;
            return n1-n2;
        }
        static int C2(object o1, object o2)
        {
            string s1 = (string)o1;
            string s2 = (string)o2;
            return s1.Length - s2.Length;
        }
    }
    class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
