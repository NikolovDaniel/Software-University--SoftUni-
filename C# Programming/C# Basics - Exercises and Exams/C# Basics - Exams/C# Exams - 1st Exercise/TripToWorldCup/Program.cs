using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripToWorldCup
{
    class Program
    {
        static void Main(string[] args)
        {
            double PlaneTicketToGo = double.Parse(Console.ReadLine());
            double PlaneTicketBack = double.Parse(Console.ReadLine());
            double PricePerTicket = double.Parse(Console.ReadLine());
            double NumberOfMatches = double.Parse(Console.ReadLine());
            double DiscountPercent = double.Parse(Console.ReadLine());

            double PlanePrice = 6 * (PlaneTicketToGo + PlaneTicketBack);
            double PlaneTicketsAfterDiscount = (PlanePrice - (PlanePrice * (DiscountPercent / 100)));
            double FinalPriceMatchesTickets = 6 * NumberOfMatches * PricePerTicket;
            double FinalPriceToBePaid = PlaneTicketsAfterDiscount + FinalPriceMatchesTickets;
            double PricePerPerson = FinalPriceToBePaid / 6;

            Console.WriteLine("Total sum: {0:F2} lv.", FinalPriceToBePaid);
            Console.WriteLine("Each friend has to pay {0:F2} lv.", PricePerPerson);




        }
    }
}

