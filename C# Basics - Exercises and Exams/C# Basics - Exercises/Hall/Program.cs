using System;

namespace Hall
{
    class Program
    {
        static void Main(string[] args)
        {
            //INPUT
            double length = double.Parse(Console.ReadLine());
            double width = double.Parse(Console.ReadLine());
            length = (length * 100);
            width = (width * 100);
            //SOLUTION
            int rows = ((int)length / 120);
            int cols = (((int)width - 100) / 70);
            int totalDesks = (rows * cols - 3);
            Console.WriteLine(totalDesks);
        }
    }
}
