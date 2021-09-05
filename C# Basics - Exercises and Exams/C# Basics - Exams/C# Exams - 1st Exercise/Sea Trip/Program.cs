using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sea_Trip
{
    class Program
    {
        static void Main(string[] args)
        {
            // Бензин = 1.85 
            // Хотел = 1 ден ( 10 процента отстъпка ) , 2 ден ( 15 % ) , 3 ден ( 20% )
            // Път = 420 км 

            double sumFood = double.Parse(Console.ReadLine());
            double sumSouvenirs = double.Parse(Console.ReadLine());
            double sumHotel = double.Parse(Console.ReadLine());

            double Diesel100 = 420.0 / 100.0 * 7;
            double costDiesel = Diesel100 * 1.85;

            double Expenses = 3 * sumFood + 3 * sumSouvenirs;
            double hotelDay1 = sumHotel - (sumHotel * 0.10);
            double hotelDay2 = sumHotel - (sumHotel * 0.15);
            double hotelDay3 = sumHotel - (sumHotel * 0.20);

            double totalSum = costDiesel + Expenses + hotelDay1 + hotelDay2 + hotelDay3;

            Console.WriteLine($"Money needed: {totalSum:f2}");
        }
    }
}
