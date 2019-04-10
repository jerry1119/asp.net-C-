using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03泛型委托
{
    public delegate int DelCompare<T>(T o1,T o2);
    class Program
    {
        static void Main(string[] args)
        {
            //int[] nums = { 1,2,3,4,5,6,7,8,9};
            //int max = GetMax<int>(nums, ( o1, o2) => { return o1 - o2; });
            //Console.WriteLine(max);



            List<int> list = new List<int>() { 1,2,3,4,5,6,7,8,9};

            //IEnumerable<int> items =  list.Where<int>(n => { return n > 5; });
            //  foreach (int item in items)
            //  {
            //      Console.WriteLine(item);
            //  }
            //  Console.ReadKey();

            // list.Where(n => { return n > 5; });

            list.RemoveAll(n =>  n > 5 );
            foreach (int item in list)
            {
                Console.WriteLine(item);
            }
            Console.ReadKey();

           
        }
        static T GetMax<T>(T[] nums, DelCompare<T> del)
        {
            T max = nums[0];
            for (int i = 0; i < nums.Length; i++)
            {
                if (del(max, nums[i]) < 0)
                {
                    max = nums[i];
                }
            }
            return max;
        }
    }
   
}
