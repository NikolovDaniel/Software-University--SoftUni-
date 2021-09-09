using System;

namespace WaterOverflow
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int capacity = 255;
            int sum = 0;

            for (int i = 0; i < n; i++)
            {
                int water = int.Parse(Console.ReadLine());

                if (capacity - water < 0) Console.WriteLine("Insufficient capacity!");
                else
                {
                    capacity -= water;
                    sum += water;
                }              
            }

            Console.WriteLine(sum);
            
        }
    }
}
