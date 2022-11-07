using System;

namespace ThreatrePromotion
{
    class Program
    {
        static void Main(string[] args)
        {
            string day = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());

            int ticketSum = 0;

            if (age < 0 || age > 122)
            {
                Console.WriteLine("Error!");
                return;
            }

            if (age >= 0 && age <= 18)
            {
                switch (day)
                {
                    case "Weekday": ticketSum = 12; break;
                    case "Weekend": ticketSum = 15; break;
                    case "Holiday": ticketSum = 5; break;
                }
            }
            if (age > 18 && age <= 64)
            {
                switch (day)
                {
                    case "Weekday": ticketSum = 18; break;
                    case "Weekend": ticketSum = 20; break;
                    case "Holiday": ticketSum = 12; break;
                }
            }
            if (age > 64 && age <= 122)
            {
                switch (day)
                {
                    case "Weekday": ticketSum = 12; break;
                    case "Weekend": ticketSum = 15; break;
                    case "Holiday": ticketSum = 10; break;
                }
            }
            Console.WriteLine($"{ticketSum}$");
        }
    }
}
