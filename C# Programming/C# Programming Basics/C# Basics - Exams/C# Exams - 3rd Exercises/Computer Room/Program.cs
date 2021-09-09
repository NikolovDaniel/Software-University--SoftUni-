using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Computer_Room
{
    class Program
    {
        static void Main(string[] args)
        {
            string month = Console.ReadLine();
            int hoursPlayed = int.Parse(Console.ReadLine());
            int numPlayers = int.Parse(Console.ReadLine());
            string typeDay = Console.ReadLine();

            double pricePerson = 0;
            double totalSum = 0;

            if (typeDay == "day")
            {
                switch (month)
                {
                    case "march":
                    case "april":
                    case "may":
                        pricePerson = 10.50;
                        break;
                }
                switch (month)
                {
                    case "june":
                    case "july":
                    case "august":
                        pricePerson = 12.60;
                        break;
                }
            }
            if (typeDay == "night")
            {
                switch (month)
                {
                    case "march":
                    case "april":
                    case "may":
                        pricePerson = 8.4;
                        break;
                }
                switch (month)
                {
                    case "june":
                    case "july":
                    case "august":
                        pricePerson = 10.20;
                        break;
                }
            }
            if (numPlayers >= 4)
            {
                pricePerson -= pricePerson * 0.1;
            }
            if (hoursPlayed >= 5)
            {
                pricePerson -= pricePerson * 0.5;
            }
            totalSum = (pricePerson * numPlayers) * hoursPlayed;
            Console.WriteLine($"Price per person for one hour: {pricePerson:f2}");
            Console.WriteLine($"Total cost of the visit: {totalSum:f2}");
        }
    }
}
