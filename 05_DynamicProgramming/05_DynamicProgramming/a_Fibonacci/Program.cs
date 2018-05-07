using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace a_Fibonacci
{
    class Program
    {
        static int Fib(int n)
        {
            if (n==1 || n==2)
            {
                return 1;
            }
            return Fib(n - 1) + Fib(n - 2);
        }



        static void Main(string[] args)
        {
            Console.WriteLine(Fib(45));
        }
    }
}
