using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wedding_Investment
{
    class Program
    {
        static void Main(string[] args)
        {
            string periodContract = Console.ReadLine();
            string typeContract = Console.ReadLine();
            string desert = Console.ReadLine();
            int payMonths = int.Parse(Console.ReadLine());

            double contractPrice = 0;
            double totalSum = 0;

            if (periodContract == "one")
            {
                switch (typeContract)
                {
                    case "Small":
                        contractPrice = 9.98;
                        break;
                    case "Middle":
                        contractPrice = 18.99;
                        break;
                    case "Large":
                        contractPrice = 25.98;
                        break;
                    case "ExtraLarge":
                        contractPrice = 35.99;
                        break;
                }
                if (desert == "yes")
                {
                    if (contractPrice <= 10)
                    {
                        totalSum += 5.50;
                    }
                    else if (contractPrice <= 30)
                    {
                        totalSum += 4.35;
                    }
                    else if (contractPrice > 30)
                    {
                        totalSum += 3.85;
                    }
                }
                totalSum += contractPrice;
                totalSum *= payMonths;
                Console.WriteLine($"{totalSum:f2} lv.");
            }
            if (periodContract == "two")
            {
                switch (typeContract)
                {
                    case "Small":
                        contractPrice = 8.58;
                        break;
                    case "Middle":
                        contractPrice = 17.09;
                        break;
                    case "Large":
                        contractPrice = 23.59;
                        break;
                    case "ExtraLarge":
                        contractPrice = 31.79;
                        break;
                }
                if (desert == "yes")
                {
                    if (contractPrice <= 10)
                    {
                        totalSum += 5.50;
                    }
                    else if (contractPrice <= 30)
                    {
                        totalSum += 4.35;
                    }
                    else if (contractPrice > 30)
                    {
                        totalSum += 3.85;
                    }
                }
                totalSum += contractPrice;
                totalSum *= payMonths;
                if (periodContract == "two")
                {
                    totalSum -= totalSum * 0.0375;
                }
                Console.WriteLine($"{totalSum:f2} lv.");
            }
        }
    }
}



