﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace a_Permutation
{
    class Program
    {
        static int[] elements;
        static bool[] used;
        static int[] permutations;

        static void Permute(int index) //index - current cell to fill
        {
            if (index>= elements.Length)
            {
                Console.WriteLine(string.Join(" ",permutations));
            }
            else
            {
                for (int i = 0; i < elements.Length; i++)
                {
                    if (!used[i])
                    {
                        var currNumber = elements[i];
                        used[i] = true;
                        permutations[index] = currNumber;
                        Permute(index + 1);

                        used[i] = false;
                    }
                    
                }
            }
        }
        static void Main(string[] args)
        {
            elements = new[] { 1, 2, 3, 4 ,5};
            used = new bool[elements.Length];
            permutations = new int[elements.Length];
            Permute(0);
        }
    }
}
