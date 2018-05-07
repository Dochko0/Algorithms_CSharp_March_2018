using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace b_FibonacciWithoutRecursion
{
    class Program
    {
        static int[] numbers;

        static int Fib(int n)
        {
            if (numbers[n]!=0)
            {
                return numbers[n];
            }
            if (n == 1 || n == 2)
            {
                return 1;
            }

            var result = Fib(n - 1) + Fib(n - 2);
            numbers[n] = result;
            return Fib(n - 1) + Fib(n - 2);
        }

        static void Main(string[] args)
        {
            numbers = new int[100];
            Console.WriteLine(Fib(50));
        }
    }
}
