using System;

namespace add
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = new int[] { 1, 23, 4, 567, 834, 3 };
            int[] result = TwoSum(nums, 7);
            Console.WriteLine(result.ToString());
            Console.ReadKey();
        }

        public static int[] TwoSum(int[] nums, int target)
        {
            for (int i = 0; i < nums.Length - 1; i++)
            {
                for (int j = i + 1; j < nums.Length; j++)
                {
                    if (nums[i] + nums[j] == target)
                    {
                        return new int[] { i, j };
                    }
                }
            }
            return null;
        }

    }
}
