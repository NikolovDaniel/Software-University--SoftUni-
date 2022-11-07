using System;
using System.Collections.Generic;
using System.Linq;

namespace Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] numbers = Console.ReadLine().Split().Select(double.Parse).ToArray();

            double average = 0;

            for (int i = 0; i < numbers.Length; i++)
            {
                average += numbers[i];
            }

            average /= numbers.Length;

            List<double> aboveAverage = new List<double>();
            

            for (int i = 0; i < numbers.Length; i++)
            {                            
                if (numbers[i] > average) aboveAverage.Add(numbers[i]);
            }

            aboveAverage.Sort();
            aboveAverage.Reverse();

            List<double> numbersToPrint = new List<double>();

            for (int i = 0; i < aboveAverage.Count; i++)
            {
                if (i == 5) break;
                else numbersToPrint.Add(aboveAverage[i]);
            }

            if(numbersToPrint.Count > 0)
            {              
                Console.WriteLine(string.Join(" ",numbersToPrint));
            }
            else Console.WriteLine("No");
        }
    }
}
