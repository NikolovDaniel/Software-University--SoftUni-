using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Honeymoon
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string town = Console.ReadLine();
            double overnight = double.Parse(Console.ReadLine());

            double pricePlane = 0;
            double priceNights = 0;
            double totalSum = 0;

            if (town == "Cairo")
            {
                priceNights = 250;
                pricePlane = 600;
                totalSum = (priceNights * 2) * overnight + pricePlane;
            }
            if (town == "Paris")
            {
                priceNights = 150;
                pricePlane = 350;
                totalSum = (priceNights * 2) * overnight + pricePlane;
            }
            if (town == "Lima")
            {
                priceNights = 400;
                pricePlane = 850;
                totalSum = (priceNights * 2) * overnight + pricePlane;
            }
            if (town == "New York")
            {
                priceNights = 300;
                pricePlane = 650;
                totalSum = (priceNights * 2) * overnight + pricePlane;
            }
            if (town == "Tokyo")
            {
                priceNights = 350;
                pricePlane = 700;
                totalSum = (priceNights * 2) * overnight + pricePlane;
            }
            if (overnight >= 1 && overnight <= 4)
            {
                if (town == "Cairo" || town == "New York")
                {
                    totalSum -= totalSum * 0.03;
                }
            }
            if (overnight >= 5 && overnight <= 9)
            {
                if (town == "Cairo" || town == "New York")
                {
                    totalSum -= totalSum * 0.05;
                }
                else if (town == "Paris")
                {
                    totalSum -= totalSum * 0.07;
                }
            }
            if (overnight >= 10 && overnight <= 24)
            {
                if (town == "Cairo")
                {
                    totalSum -= totalSum * 0.1;
                }
                else if (town == "Paris" || town == "New York" || town == "Tokyo")
                {
                    totalSum -= totalSum * 0.12;
                }
            }
            if (overnight >= 25 && overnight <= 49)
            {
                if (town == "Cairo" || town == "Tokyo")
                {
                    totalSum -= totalSum * 0.17;
                }
                else if (town == "New York" || town == "Lima")
                {
                    totalSum -= totalSum * 0.19;
                }
                else if (town == "Paris")
                {
                    totalSum -= totalSum * 0.22;
                }
            }
            if (overnight >= 50)
            {
                totalSum -= totalSum * 0.3;
            }
            if (budget >= totalSum)
            {
                Console.WriteLine($"Yes! You have {Math.Abs(totalSum - budget):f2} leva left.");
            }
            else
            {
                Console.WriteLine($"Not enough money! You need {Math.Abs(totalSum - budget):f2} leva.");
            }
        }
    }
}
