using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_RecursiveDrawing
{
    class Program
    {
        static void Main(string[] args)
        {
            var num = int.Parse(Console.ReadLine());
            PrintSrarPart(num);
        }

        static void PrintSrarPart(int num)
        {
            if (num<=0)
            {
                return;
            }
            Console.WriteLine(new string('*', num));
            PrintSrarPart(num - 1);
            Console.WriteLine(new string('#', num));
        }
    }
}
