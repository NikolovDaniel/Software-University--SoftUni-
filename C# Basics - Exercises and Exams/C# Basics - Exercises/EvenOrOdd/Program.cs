using System;

namespace EvenOrOdd
{
    class Program
    {
        static void Main(string[] args)
        {
            //INPUT
            int number = int.Parse(Console.ReadLine());

            //OUTPUT
            if (number % 2 == 0)
            {
                Console.WriteLine("even");
            }
            else
            {
                Console.WriteLine("odd");
            }
        }
    }
}
