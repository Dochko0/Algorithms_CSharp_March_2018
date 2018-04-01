using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Variation
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int counter = 0;
            while(true)
            {
                if (counter>4)
                {
                    break;
                }
                List<int> num = new List<int> { 1, 2, 3, 4, 5 };
                //int n = random.Next(1, 5);
                //int n1 = random.Next(1, 5);
                //int n2 = random.Next(1, 5);
                //int n3 = random.Next(1, 5);
                //int n4 = random.Next(1, 5);
                HashSet<int> numbers = new HashSet<int>();
                // if (n != n1 && n != n2 && n !=n3 && n != n4 && n1 != n2 && n1 != n3 && n1 != n4 && n2 != n3 && n2 != n4 && n3 != n4){
                num
                    //numbers.Add(n);
                    //numbers.Add(n1);
                    //numbers.Add(n2);
                    //numbers.Add(n3);
                    //numbers.Add(n4);
                    counter++;
                    foreach (var m in numbers)
                    {
                        Console.Write(m);
                    }
                    Console.WriteLine();
                // }

                //Console.Write("Input String>");
                string inputLine = "12345";

                Recursion rec = new Recursion();
                rec.InputSet = rec.MakeCharArray(inputLine);
                rec.CalcPermutation(0);

                Console.Write("# of Permutations: " + rec.PermutationCount);

            }
        }
    }
}