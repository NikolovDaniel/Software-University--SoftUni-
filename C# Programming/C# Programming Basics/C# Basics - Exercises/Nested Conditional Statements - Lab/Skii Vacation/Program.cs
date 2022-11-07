using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skii_Vacation
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            string room = Console.ReadLine();
            string rate = Console.ReadLine();

            int nights = days - 1; // 14 дни = 13 нощувки
            double priceNight = 0;
            double discount = 0;

            switch (room)
            {
                case "room for one person":
                    priceNight = 18;
                    break;
                case "apartment":
                    priceNight = 25;
                    if (nights < 10)
                    {
                        discount = 0.3;
                    }
                    else if (nights >= 10 && nights < 15)
                    {
                        discount = 0.35;
                    }
                    else if (nights > 15)
                    {
                        discount = 0.50;
                    }
                    break;
                case "president apartment":
                    priceNight = 35;
                    if (nights < 10)
                    {
                        discount = 0.1;
                    }
                    else if (nights >= 10 && nights < 15)
                    {
                        discount = 0.15;
                    }
                    else if (nights > 15)
                    {
                        discount = 0.20;
                    }
                    break;
            }
            double totalSum = priceNight * nights;
            totalSum -= totalSum * discount;
            if (rate == "positive")
            {
                totalSum += totalSum * 0.25;
            }
            else if (rate == "negative")
            {
                totalSum -= totalSum * 0.10;
            }
            Console.WriteLine($"{totalSum:f2}");
        }
    }
}
