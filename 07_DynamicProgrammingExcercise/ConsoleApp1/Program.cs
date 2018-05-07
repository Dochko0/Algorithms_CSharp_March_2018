using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            var dp = new int[numbers.Length, 2];
            var prev = new int[numbers.Length, 2];

            dp[0, 0] = dp[0, 1] = 1;
            prev[0, 0] = prev[0, 1] = -1;

            var maxResult = 0;
            var maxIndexRow = 0;
            var maxIndexCol = 0;

            for (int currIndex = 1; currIndex < numbers.Length; currIndex++)
            {
                for (int prevIndex = 0; prevIndex < currIndex; prevIndex++)
                {
                    var currNum = numbers[currIndex];
                    var prevNum = numbers[prevIndex];

                    if (currNum > prevNum && dp[currIndex, 0] < dp[prevIndex, 1] + 1)
                    {
                        dp[currIndex, 0] = dp[prevIndex, 1] + 1;
                        prev[currIndex, 0] = prevIndex;

                    }
                    if (currNum < prevNum && dp[currIndex, 1] < dp[prevIndex, 0] + 1)
                    {
                        dp[currIndex, 1] = dp[prevIndex, 0] + 1;
                        prev[currIndex, 1] = prevIndex;
                    }
                }
                if (dp[currIndex, 0] > maxResult)
                {
                    maxResult = dp[currIndex, 0];
                    maxIndexRow = currIndex;
                    maxIndexCol = 0;
                }
                if (dp[currIndex, 1] > maxResult)
                {
                    maxResult = dp[currIndex, 1];
                    maxIndexRow = currIndex;
                    maxIndexCol = 1;
                }
            }
            var result = new List<int>();

            while (maxIndexRow>=0)
            {
                result.Add(numbers[maxIndexRow]);
                maxIndexRow = prev[maxIndexRow, maxIndexCol];

                if (maxIndexCol==1)
                {
                    maxIndexCol = 0;
                }
                else
                {
                    maxIndexCol = 1;
                }

            }
            result.Reverse();

            Console.WriteLine(string.Join(" ", result));
        }
    }
}
