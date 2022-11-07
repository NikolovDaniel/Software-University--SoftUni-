using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema
{
    class Program
    {
        static void Main(string[] args)
        {
            string typeCinema = Console.ReadLine();
            double row = double.Parse(Console.ReadLine());
            double columns = double.Parse(Console.ReadLine());
            double ticketPrice = 0;
            double totalSum = 0;

            switch (typeCinema)
            {
                case "Premiere":
                    ticketPrice = 12.00;
                    totalSum = (ticketPrice * row) * columns;
                    Console.WriteLine($"{totalSum:f2}");
                    break;
                case "Normal":
                    ticketPrice = 7.50;
                    totalSum = (ticketPrice * row) * columns;
                    Console.WriteLine($"{totalSum:f2}");
                    break;
                case "Discount":
                    ticketPrice = 5.00;
                    totalSum = (ticketPrice * row) * columns;
                    Console.WriteLine($"{totalSum:f2}");
                    break;
            }
        }
    }
}
