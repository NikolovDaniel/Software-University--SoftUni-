using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace New_House
{
    class Program
    {
        static void Main(string[] args)
        {
            int budget = int.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            int fisherman = int.Parse(Console.ReadLine());
            double currentPrice = 0;
            double finalcurrentPrice = 0;

            if (season == "Spring")
            {
                currentPrice = 3000;
                if (fisherman > 0 && fisherman <= 6)
                {
                    currentPrice -= currentPrice * 0.1;
                }
                else if (fisherman > 6 && fisherman <= 11)
                {
                    currentPrice -= currentPrice * 0.15;
                }
                else if (fisherman > 11)
                {
                    currentPrice -= currentPrice * 0.25;
                }
            }
            else if (season == "Winter")
            {
                currentPrice = 2600;
                if (fisherman > 0 && fisherman <= 6)
                {
                    currentPrice -= currentPrice * 0.1;
                }
                else if (fisherman > 6 && fisherman <= 11)
                {
                    currentPrice -= currentPrice * 0.15;
                }
                else if (fisherman > 11)
                {
                    currentPrice -= currentPrice * 0.25;
                }
            }
            else if (season == "Autumn")
            {
                currentPrice = 4200;
                if (fisherman > 0 && fisherman <= 6)
                {
                    currentPrice -= currentPrice * 0.1;
                }
                else if (fisherman > 6 && fisherman <= 11)
                {
                    currentPrice -= currentPrice * 0.15;
                }
                else if (fisherman > 11)
                {
                    currentPrice -= currentPrice * 0.25;
                }
            }
            else if (season == "Summer")
            {
                currentPrice = 4200;
                if (fisherman > 0 && fisherman <= 6)
                {
                    currentPrice -= currentPrice * 0.1;
                }
                else if (fisherman > 6 && fisherman <= 11)
                {
                    currentPrice -= currentPrice * 0.15;
                }
                else if (fisherman > 11)
                {
                    currentPrice -= currentPrice * 0.25;
                }
            }
            if (fisherman % 2 == 0 && season != "Autumn")
            {
                finalcurrentPrice = currentPrice - (currentPrice * 0.05);
            }
            else
            {
                finalcurrentPrice = currentPrice;
            }
            if (budget >= finalcurrentPrice)
            {
                Console.WriteLine($"Yes! You have {budget - finalcurrentPrice:f2} leva left.");
            }
            else
            {
                Console.WriteLine($"Not enough money! You need {Math.Abs(budget - finalcurrentPrice):f2} leva.");
            }
        }
    }
}
