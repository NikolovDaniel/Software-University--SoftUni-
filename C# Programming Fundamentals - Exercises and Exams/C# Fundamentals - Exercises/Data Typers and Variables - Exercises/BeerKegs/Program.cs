using System;

namespace BeerKegs
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            double biggestSum = 0;
            string model = "";
            string bestModel = " ";
            double result = 0;

            for (int i = 0; i < n; i++)
            {
                for (int a = 0; a < 1; a++)
                {
                    model = Console.ReadLine();
                    double radius = double.Parse(Console.ReadLine());
                    int height = int.Parse(Console.ReadLine());                   
                    result = Math.PI * radius * radius * height;
                }
                if (result > biggestSum)
                {
                    biggestSum = result;
                    bestModel = model;
                }
            }
            Console.WriteLine(bestModel);
        }
    }
}
