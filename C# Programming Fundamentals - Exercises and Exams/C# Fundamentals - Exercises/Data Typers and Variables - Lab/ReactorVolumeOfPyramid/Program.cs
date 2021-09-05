using System;

namespace ReactorVolumeOfPyramid
{
    class Program
    {
        static void Main(string[] args)
        {
            double result = 0;
            double length, width, height = 0;

            Console.Write("Length: ");
            length = double.Parse(Console.ReadLine());

            Console.Write("Width: ");
            width = double.Parse(Console.ReadLine());

            Console.Write("Height: ");
            height = double.Parse(Console.ReadLine());

            result = (length * width * height) / 3;
            Console.WriteLine($"Pyramid Volume: {result:f2}");
        }
    }
}
