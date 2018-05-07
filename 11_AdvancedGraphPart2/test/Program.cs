using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            int volume = int.Parse(Console.ReadLine());
            int energy = int.Parse(Console.ReadLine());
            var sugar = double.Parse(Console.ReadLine());

            var calories = energy * ((double) volume / 100);
            var sugarsInProduct =  sugar * ((double)volume / 100);

            Console.WriteLine($"{volume}ml {name}:");
            Console.Write($"{calories}kcal, {sugarsInProduct}g sugars");
        }
    }
}
