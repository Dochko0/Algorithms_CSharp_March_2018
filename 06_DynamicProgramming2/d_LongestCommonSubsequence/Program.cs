using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace d_LongestCommonSubsequence
{
    class Program
    {
        static void Main(string[] args)
        {
            var first = "GCGCAATG";
            var second = "GCCCTAGCG";

            var lcs = new int[first.Length + 1,second.Length+1];

            for (int row = 1; row <= first.Length; row++)
            {
                for (int col = 1; col <= second.Length; col++)
                {
                    var up = lcs[row - 1, col];
                    var left = lcs[row , col - 1];

                    var res = Math.Max(up, left);

                    if (first[row-1]==second[col-1])
                    {
                        res = Math.Max(1+ lcs[row - 1, col - 1], res);
                    }

                    lcs[row, col] = res;
                }
            }
            Console.WriteLine(lcs[first.Length,second.Length]);

            var currRow = first.Length;
            var currCol = second.Length;

            var result = new List<char>();

            while (currCol>0 && currRow>0)
            {
                if (first[currRow-1]==second[currCol-1])
                {
                    result.Add(first[currRow - 1]);
                    currRow--;
                    currCol--;
                }
                else if (lcs[currRow - 1, currCol] == lcs[currRow, currCol - 1])
                {
                    currRow--;
                }
                else
                {
                    currCol--;
                }
            }
            result.Reverse();

            Console.WriteLine(string.Join(" ", result));

        }
    }
}
