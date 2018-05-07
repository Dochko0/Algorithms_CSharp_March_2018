using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_LongestIncreasingSubsequence
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = new[] { 3, 14, 5, 12, 15, 7, 8, 9, 11, 10, 1 };

            var solutions = new int[numbers.Length];
            var prev = new int[numbers.Length];
            var maxSol = 0;
            var maxSolIndex = 0;

            for (int curr = 0; curr < numbers.Length; curr++)
            {
                var solution = 1;
                var prevIndex = -1;
                var currNum = numbers[curr];

                for (int solIndex = 0; solIndex < curr; solIndex++)
                {
                    var prevNum = numbers[solIndex];
                    var prevSolution = solutions[solIndex];

                    if (currNum>prevNum && solution<=prevSolution)
                    {
                        solution = prevSolution + 1;
                        prevIndex = solIndex;
                    }
                }
                solutions[curr] = solution;
                prev[curr] = prevIndex;

                if (solution > maxSol)
                {
                    maxSol = solution;
                    maxSolIndex = curr;
                }
            }
            Console.WriteLine(maxSol);
            var index = maxSolIndex;
            var result = new List<int>();
            while (index!=-1)
            {
                var currNum = numbers[index];
                result.Add(currNum);
                index = prev[index];
            }
            result.Reverse();
            Console.WriteLine(string.Join(" ",result));
        }
    }
}
