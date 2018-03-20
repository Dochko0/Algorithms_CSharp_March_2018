using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace b_RecursiveFactorial
{
    class Program
    {
        static long Factorial(int num)
        {
            if (num==0)
            {
                return 1;
            }

            return num * Factorial(num - 1);
        }

        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            var sum = Factorial(num);

            Console.WriteLine(sum);
        }
    }
}
