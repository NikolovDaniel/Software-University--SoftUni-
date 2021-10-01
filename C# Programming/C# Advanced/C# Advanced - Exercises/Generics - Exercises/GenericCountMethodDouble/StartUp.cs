using System;
using System.Collections.Generic;

namespace GenericCountMethodDouble
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<double> list = new List<double>();

            for (int i = 0; i < n; i++)
            {
                double input = double.Parse(Console.ReadLine());
                list.Add(input);
            }

            Box<double> listElements = new Box<double>(list);

            double inpt = double.Parse(Console.ReadLine());

            Console.WriteLine(listElements.CountGreaterElements(list, inpt));
        }
    }
}
