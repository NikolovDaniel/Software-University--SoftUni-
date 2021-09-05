using System;

namespace Aquarium
{
    class Program
    {
        static void Main(string[] args)
        {
            //INPUT
            int lengthCm = int.Parse(Console.ReadLine());
            int widthCm = int.Parse(Console.ReadLine());
            int heigthCm = int.Parse(Console.ReadLine());
            double percent = double.Parse(Console.ReadLine());

            //SOLUTION
            double capacity = lengthCm * widthCm * heigthCm;
            double litres = capacity * 0.001; // 299625 cm3 convert to dm3 = 299.625
            double percentFilled = percent * 0.01;
            double litresNeeded = litres * (1 - percentFilled);

            //OUTPUT
            Console.WriteLine(litresNeeded);




        }
    }
}
