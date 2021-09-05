using System;

namespace _1to20
{
    class Program
    {
        static void Main(string[] args)
        {
            //INPUT
            int first = int.Parse(Console.ReadLine());
            int second = int.Parse(Console.ReadLine());
            int third = int.Parse(Console.ReadLine());
            //VARIABLES
            int totalTime = first + second + third;
            int minutes = totalTime / 60;
            int seconds = totalTime % 60;

            //SOLUTION

            if (seconds < 10)
            {
                Console.WriteLine($"{minutes}:0{seconds}");
            }
            else
            {
                Console.WriteLine($"{minutes}:{seconds}");
            }
         


        }
    }
}
