using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace f_FindAllPathsInALabyrinth
{
    class Program
    {
        static List<char> path = new List<char>();


        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int cols = int.Parse(Console.ReadLine());
            char[,] labyrinth = ReadLabyrinth(rows, cols);
            FindAllPaths(labyrinth);
        }

        private static void FindAllPaths(char[,] labyrinth, int currRow = 0, int currCol = 0, string currPath = "")
        {
            if (InInvalidPlace(labyrinth, currRow, currCol))
            {
                return;
            }

            if (labyrinth[currRow, currCol] == 'e')
            {
                Console.WriteLine(currPath);
            }
            else
            {
                labyrinth[currRow, currCol] = 'v';
                FindAllPaths(labyrinth, currRow - 1, currCol, currPath + "U");
                FindAllPaths(labyrinth, currRow, currCol + 1, currPath + "R");
                FindAllPaths(labyrinth, currRow + 1, currCol, currPath + "D");
                FindAllPaths(labyrinth, currRow, currCol - 1, currPath + "L");
            }
        }

        private static bool InInvalidPlace(char[,] labyrinth, int row, int col)
        {
            return row < 0 || row >= labyrinth.GetLength(0) || col < 0 || col >= labyrinth.GetLength(1) ||
                labyrinth[row, col] == '*' || labyrinth[row, col] == 'v';
        }

        private static char[,] ReadLabyrinth(int rows, int cols)
        {
            char[,] labyrinth = new char[rows, cols];
            for (int row = 0; row < rows; row++)
            {
                string currRow = Console.ReadLine();
                for (int col = 0; col < cols; col++)
                {
                    labyrinth[row, col] = currRow[col];
                }
            }
            return labyrinth;
        }
    }
}
