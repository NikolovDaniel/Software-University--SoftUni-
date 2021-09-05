using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training
{
    class Program
    {
        static void Main(string[] args)
        {
            int dayStay = int.Parse(Console.ReadLine());
            string typeRoom = Console.ReadLine();
            string rate = Console.ReadLine();

            double roomPrice = 0;
            double totalSum = 0;
            dayStay = dayStay - 1;

            if (typeRoom == "room for one person")
            {
                roomPrice = 18.00;
                totalSum = roomPrice * dayStay;

                if (rate == "positive")
                {
                    totalSum += totalSum * 0.25;
                    Console.WriteLine($"{totalSum:f2}");
                }
                else if (rate == "negative")
                {
                    totalSum -= totalSum * 0.1;
                    Console.WriteLine($"{totalSum:f2}");
                }
            }
            if (typeRoom == "apartment")
            {
                roomPrice = 25.00;
                totalSum = roomPrice * dayStay;
                if (dayStay < 10 && rate == "positive")
                {
                    totalSum -= totalSum * 0.3;
                    totalSum += totalSum * 0.25;
                    Console.WriteLine($"{totalSum:f2}");
                }
                else if (dayStay < 10 && rate == "negative")
                {
                    totalSum -= totalSum * 0.3;
                    totalSum -= totalSum * 0.1;
                    Console.WriteLine($"{totalSum:f2}");
                }
                else if (dayStay >= 10 && dayStay <= 15 && rate == "positive")
                {
                    totalSum -= totalSum * 0.35;
                    totalSum += totalSum * 0.25;
                    Console.WriteLine($"{totalSum:f2}");
                }
                else if (dayStay >= 10 && dayStay <= 15 && rate == "negative")
                {
                    totalSum -= totalSum * 0.35;
                    totalSum -= totalSum * 0.1;
                    Console.WriteLine($"{totalSum:f2}");
                }
                else if (dayStay > 15 && rate == "positive")
                {
                    totalSum -= totalSum * 0.5;
                    totalSum += totalSum * 0.25;
                    Console.WriteLine($"{totalSum:f2}");
                }
                else if (dayStay > 15 && rate == "negative")
                {
                    totalSum -= totalSum * 0.5;
                    totalSum -= totalSum * 0.1;
                    Console.WriteLine($"{totalSum:f2}");
                }
            }
            if (typeRoom == "president apartment")
            {
                roomPrice = 35.00;
                totalSum = roomPrice * dayStay;
                if (dayStay < 10 && rate == "positive")
                {
                    totalSum -= totalSum * 0.1;
                    totalSum += totalSum * 0.25;
                    Console.WriteLine($"{totalSum:f2}");
                }
                else if (dayStay < 10 && rate == "negative")
                {
                    totalSum -= totalSum * 0.1;
                    totalSum -= totalSum * 0.1;
                    Console.WriteLine($"{totalSum:f2}");
                }
                else if (dayStay >= 10 && dayStay <= 15 && rate == "positive")
                {
                    totalSum -= totalSum * 0.15;
                    totalSum += totalSum * 0.25;
                    Console.WriteLine($"{totalSum:f2}");
                }
                else if (dayStay >= 10 && dayStay <= 15 && rate == "negative")
                {
                    totalSum -= totalSum * 0.15;
                    totalSum -= totalSum * 0.1;
                    Console.WriteLine($"{totalSum:f2}");
                }
                else if (dayStay > 15 && rate == "positive")
                {
                    totalSum -= totalSum * 0.2;
                    totalSum += totalSum * 0.25;
                    Console.WriteLine($"{totalSum:f2}");
                }
                else if (dayStay > 15 && rate == "negative")
                {
                    totalSum -= totalSum * 0.2;
                    totalSum -= totalSum * 0.1;
                    Console.WriteLine($"{totalSum:f2}");
                }
            }
        }
    }
}
