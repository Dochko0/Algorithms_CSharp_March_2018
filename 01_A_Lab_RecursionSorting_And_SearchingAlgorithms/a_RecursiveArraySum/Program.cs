using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace a_RecursiveArraySum
{  
    class Program
    {
        static int Sum(int[] arr, int index)
        {
            if (index == arr.Length)
            {
                return 0;
            }
            var currSum = arr[index] + Sum(arr, index + 1);

            return currSum;
        }
        static void Main(string[] args)
        {
            var nums = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var sum = Sum(nums, 0);
            Console.WriteLine(sum);
        }
    }
}
