using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace b_SubsetSumWithRepeat
{
    class Program
    {




        static void Main(string[] args)
        {
            var nums = new[] { 3, 5, 2 };

            var targetSum = 17;

            var possibleSums = new bool[targetSum + 1];
            possibleSums[0] = true;

            for (int sum = 0; sum < possibleSums.Length; sum++)
            {
                if (possibleSums[sum])
                {
                    for (int i = 0; i < nums.Length; i++)
                    {
                        var newSum = sum + nums[i];
                        if (newSum <= targetSum)
                        {
                            possibleSums[newSum] = true;
                        }
                    }
                }
            }

            while (targetSum != 0)
            {
                for (int i = 0; i < nums.Length; i++)
                {
                    var sum = targetSum - nums[i];
                    if (sum >= 0 && possibleSums[sum])
                    {
                        Console.WriteLine(nums[i] + " ");
                        targetSum = sum;
                    }
                }
            }

            Console.WriteLine(possibleSums[targetSum]);
        }
    }
}
