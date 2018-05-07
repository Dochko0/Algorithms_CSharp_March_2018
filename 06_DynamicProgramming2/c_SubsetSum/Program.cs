using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_SubsetSum
{
    class Program
    {
        static Dictionary<int,int> CalcSums(int[] nums)
        {
            var result = new Dictionary<int, int>();

            result.Add(0, 0);

            for (int i = 0; i < nums.Length; i++)
            {
                var currNum = nums[i];

                var newSums = new Dictionary<int, int>();

                foreach (var item in result.Keys.ToList())
                {
                    var newSum = item + currNum;

                    if (!result.ContainsKey(newSum))
                    {
                        result.Add(newSum, currNum);
                    }

                }
            }
            return result;
        }



        static void Main(string[] args)
        {
            var nums = new int[] { 3, 5, 1, 4, 2 };

            var sums = CalcSums(nums);

            var targetSum = 9;

            if (sums.ContainsKey(targetSum))
            {
                Console.WriteLine("Yes");

                while (targetSum!=0)
                {
                    var number = sums[targetSum];

                    Console.WriteLine(number);

                    targetSum -= number;
                }


            }
            else
            {
                Console.WriteLine("No");
            }

        }
    }
}
