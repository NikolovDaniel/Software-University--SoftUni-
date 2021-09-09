using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Room
{
    class Program
    {
        static void Main(string[] args)
        {
            string season = Console.ReadLine();
            int days = int.Parse(Console.ReadLine());

            double apartPrice = 0;
            double studioPrice = 0;
            double apartSum = 0;
            double studioSum = 0;
            double discount = 0;
            double discountAp = 0;
            double finalPrice = 0;

            if (season == "May" || season == "October")
            {
                studioPrice = 50;
                apartPrice = 65;
                apartSum = days * apartPrice;
                studioSum = days * studioPrice;
                if (days > 14)
                {
                    discount = 0.3;
                    discountAp = 0.1;
                    studioSum -= studioSum * discount;
                    apartSum -= apartSum * discountAp;
                }
                else if (days > 7)
                {
                    discount = 0.05;
                    studioSum -= studioSum * discount;
                }
                Console.WriteLine($"Apartment: {apartSum:f2} lv.");
                Console.WriteLine($"Studio: {studioSum:f2} lv.");
            }
            else if (season == "June" || season == "September")
            {
                studioPrice = 75.20;
                apartPrice = 68.70;
                studioSum = studioPrice * days;
                apartSum = apartPrice * days;
                if (days > 14)
                {
                    discount = 0.2;
                    discountAp = 0.1;
                    studioSum -= studioSum * discount;
                    apartSum -= apartSum * discountAp;
                }
                Console.WriteLine($"Apartment: {apartSum:f2} lv.");
                Console.WriteLine($"Studio: {studioSum:f2} lv.");
            }
            else if (season == "July" || season == "August")
            {
                studioPrice = 76;
                apartPrice = 77;
                studioSum = studioPrice * days;
                apartSum = apartPrice * days;
                if (days > 14)
                {
                    discountAp = 0.1;
                    apartSum -= apartSum * discountAp;
                }
                Console.WriteLine($"Apartment: {apartSum:f2} lv.");
                Console.WriteLine($"Studio: {studioSum:f2} lv.");
            }
        }
    }
}
