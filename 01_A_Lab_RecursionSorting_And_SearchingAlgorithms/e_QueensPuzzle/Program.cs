using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_QueensPuzzle
{
    class Program
    {
        const int Size = 8;
        static int[,] chessboard = new int[Size, Size];

        static HashSet<int> attackedRows = new HashSet<int>();
        static HashSet<int> attackedCols = new HashSet<int>();

        static void Main(string[] args)
        {
            PutQueens(0);
        }

        private static void PutQueens(int row)
        {
            if (row==Size)
            {
                PrintSolution();
               // return;
            }
            else
            {
                for (int col = 0; col < Size; col++)
                {
                    if (CanPlaceQueen(row,col))
                    {
                        MarkAllAttackedPositions(row, col);
                        PutQueens(row + 1);
                        UnmarkAllAttackedPositions(row, col);
                    }
                }
            }
        }

        private static void UnmarkAllAttackedPositions(int row, int col)
        {
            chessboard[row, col] = 0;
            attackedRows.Remove(row);
            attackedCols.Remove(col);           
        }

        private static void MarkAllAttackedPositions(int row, int col)
        {
            chessboard[row, col] = 1;
            attackedRows.Add(row);
            attackedCols.Add(col);
        }

        private static bool CanPlaceQueen(int row, int col)
        {
            //if (attackedRows.Contains(row))
            //{
            //    return false;
            //}
            //if (attackedCols.Contains(col))
            //{
            //    return false;
            //}
            //left up
            for (int i = 0; i < Size; i++)
            {
                int currRow = row - i;
                int currCol = col - i;

                if (currRow<0 || currRow>=Size || currCol<0 || currCol>=Size)
                {
                    break;
                }
                if (chessboard[currRow,currCol]==1)
                {
                    return false;
                }
            }
            // right up
            for (int i = 0; i < Size; i++)
            {
                int currRow = row - i;
                int currCol = col + i;

                if (currRow < 0 || currRow >= Size || currCol < 0 || currCol >= Size)
                {
                    break;
                }
                if (chessboard[currRow, currCol] == 1)
                {
                    return false;
                }
            }
            // left down
            for (int i = 0; i < Size; i++)
            {
                int currRow = row + i;
                int currCol = col - i;

                if (currRow < 0 || currRow >= Size || currCol < 0 || currCol >= Size)
                {
                    break;
                }
                if (chessboard[currRow, currCol] == 1)
                {
                    return false;
                }
            }
            //right up
            for (int i = 0; i < Size; i++)
            {
                int currRow = row + i;
                int currCol = col + i;

                if (currRow < 0 || currRow >= Size || currCol < 0 || currCol >= Size)
                {
                    break;
                }
                if (chessboard[currRow, currCol] == 1)
                {
                    return false;
                }
            }

            return attackedRows.Contains(row) || attackedCols.Contains(col) ? false:true;
        }

        private static void PrintSolution()
        {
            for (int row = 0; row < Size; row++)
            {
                for (int col = 0; col < Size; col++)
                {
                    var printResult = chessboard[row, col] == 1 ? "* " : "- ";
                    Console.Write(printResult);
                    //if (chessboard[row,col]==1)
                    //{
                    //    Console.Write("* ");
                    //}
                    //else
                    //{
                    //    Console.Write("- ");
                    //}

                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}
