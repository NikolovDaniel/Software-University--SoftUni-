using System;

namespace SpeedInfo
{
    class Program
    {
        static void Main(string[] args)
        {
            //INPUT
            double speed = double.Parse(Console.ReadLine());

            //SOLUTION
            if (speed <= 10)
            {
                Console.WriteLine("slow");
            }
            else if (speed <= 50)
            {
                Console.WriteLine("average");
            }
            else if (speed <= 150)
            {
                Console.WriteLine("fast");
            }
            else if (speed <= 1000)
            {
                Console.WriteLine("ultra fast");
            }
            else
            {
                Console.WriteLine("extremely fast");
            }
        }
    }
}
