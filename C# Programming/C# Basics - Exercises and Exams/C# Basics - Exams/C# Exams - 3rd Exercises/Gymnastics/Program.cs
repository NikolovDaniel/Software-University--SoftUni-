using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gymnastics
{
    class Program
    {
        static void Main(string[] args)
        {
            string country = Console.ReadLine();
            string instrument = Console.ReadLine();

            if (country == "Bulgaria")
            {
                if (instrument == "ribbon")
                {
                    double grade = 9.600 + 9.400;
                    double pointsLeft = ((20 - grade) / 20) * 100;
                    Console.WriteLine($"The team of {country} get {grade:f3} on {instrument}.");
                    Console.WriteLine($"{pointsLeft:f2}%");
                }
                else if (instrument == "hoop")
                {
                    double grade = 9.550 + 9.750;
                    double pointsLeft = ((20 - grade) / 20) * 100;
                    Console.WriteLine($"The team of {country} get {grade:f3} on {instrument}.");
                    Console.WriteLine($"{pointsLeft:f2}%");
                }
                else if (instrument == "rope")
                {
                    double grade = 9.500 + 9.400;
                    double pointsLeft = ((20 - grade) / 20) * 100;
                    Console.WriteLine($"The team of {country} get {grade:f3} on {instrument}.");
                    Console.WriteLine($"{pointsLeft:f2}%");
                }
            }
            else if (country == "Russia")
            {
                if (instrument == "ribbon")
                {
                    double grade = 9.100 + 9.400;
                    double pointsLeft = ((20 - grade) / 20) * 100;
                    Console.WriteLine($"The team of {country} get {grade:f3} on {instrument}.");
                    Console.WriteLine($"{pointsLeft:f2}%");
                }
                else if (instrument == "hoop")
                {
                    double grade = 9.300 + 9.800;
                    double pointsLeft = ((20 - grade) / 20) * 100;
                    Console.WriteLine($"The team of {country} get {grade:f3} on {instrument}.");
                    Console.WriteLine($"{pointsLeft:f2}%");
                }
                else if (instrument == "rope")
                {
                    double grade = 9.600 + 9.000;
                    double pointsLeft = ((20 - grade) / 20) * 100;
                    Console.WriteLine($"The team of {country} get {grade:f3} on {instrument}.");
                    Console.WriteLine($"{pointsLeft:f2}%");
                }
            }
            else if (country == "Italy")
            {
                if (instrument == "ribbon")
                {
                    double grade = 9.200 + 9.500;
                    double pointsLeft = ((20 - grade) / 20) * 100;
                    Console.WriteLine($"The team of {country} get {grade:f3} on {instrument}.");
                    Console.WriteLine($"{pointsLeft:f2}%");
                }
                else if (instrument == "hoop")
                {
                    double grade = 9.450 + 9.350;
                    double pointsLeft = ((20 - grade) / 20) * 100;
                    Console.WriteLine($"The team of {country} get {grade:f3} on {instrument}.");
                    Console.WriteLine($"{pointsLeft:f2}%");
                }
                else if (instrument == "rope")
                {
                    double grade = 9.700 + 9.150;
                    double pointsLeft = ((20 - grade) / 20) * 100;
                    Console.WriteLine($"The team of {country} get {grade:f3} on {instrument}.");
                    Console.WriteLine($"{pointsLeft:f2}%");
                }
            }
        }
    }
}

