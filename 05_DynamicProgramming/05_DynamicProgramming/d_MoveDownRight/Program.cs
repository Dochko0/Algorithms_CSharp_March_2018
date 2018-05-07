using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace d_MoveDownRight
{
    class Program
    {
        static void Main(string[] args)
        {
            var rows = int.Parse(Console.ReadLine());
            var cols = int.Parse(Console.ReadLine());

            var numbers = new int[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                var line = Console.ReadLine().Split(' ');

                for (int j = 0; j < cols; j++)
                {
                    numbers[i, j] = int.Parse(line[j]);

                }
            }
            var sums = new int[rows, cols];

            sums[0, 0] = numbers[0, 0];

            for (int row = 1; row < rows; row++)
            {
                sums[row, 0] = sums[row - 1, 0] + numbers[row, 0];
            }
            for (int col = 1; col < cols; col++)
            {
                sums[0, col] = sums[0, col - 1] + numbers[0, col];
            }

            for (int row = 1; row < rows; row++)
            {
                for (int col = 1; col < cols; col++)
                {
                    var res = Math.Max(sums[row - 1, col], sums[row, col - 1]) + numbers[row, col];

                    sums[row, col] = res;
                }
            }

            Console.WriteLine(sums[rows-1,cols-1]);


            var result = new List<string>();

            result.Add($"[{rows - 1}, {cols - 1}]");

            var currRow = rows - 1;
            var currCol = cols - 1;


            while (currRow!=0 || currCol!=0)
            {
                var top = -1;
                if (currRow-1 >= 0)
                {
                    top = sums[currRow - 1, currCol];
                }
                
                var left = -1;
                if (currCol-1>=0)
                {
                    left = sums[currRow, currCol - 1];
                }

                if (top>left)
                {
                    result.Add($"[{currRow - 1}, {currCol}]");
                    currRow -= 1;
                    //if (currRow<0)
                    //{
                    //    currRow = 0;
                    //}
                }
                else
                {
                    result.Add($"[{currRow}, {currCol - 1}]");
                    currCol -= 1;
                    //if (currCol<0)
                    //{
                    //    currCol = 0;
                    //}
                }
            }
            result.Reverse();
            Console.WriteLine(string.Join(" ",result));
        }
    }
}
