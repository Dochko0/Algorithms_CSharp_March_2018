using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace d_Generating0_1Vectors
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            var vector = new int[num];
            GenerateVectors(vector, 0);
        }

        private static void GenerateVectors(int[] vector, int index)
        {
            if (index>vector.Length-1)
            {
                Print(vector);
            }
            else
            {
                for (int i = 0; i <=1 ; i++)
                {
                    vector[index] = i;
                    GenerateVectors(vector, index + 1);
                }
            }
        }
        private static void Print(int[] vector)
        {
            Console.WriteLine(string.Join("",vector));
        }
    }
}
