using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beer_and_Chips
{
    class Program
    {
        static void Main(string[] args)
        {
            // Бира = 1.20
            // Чипс = 45% от общата стойност на всички бири

            string name = Console.ReadLine();
            double budget = double.Parse(Console.ReadLine());
            int numBeers = int.Parse(Console.ReadLine());
            int numChips = int.Parse(Console.ReadLine());

            double beerSum = numBeers * 1.20;
            double priceChips = beerSum * 0.45;
            double chipsSum = Math.Ceiling(priceChips * numChips);
            double totalSum = chipsSum + beerSum;
            double moneyLeft = Math.Abs(budget - totalSum);

            if (totalSum <= budget)
            {
                Console.WriteLine($"{name} bought a snack and has {moneyLeft:f2} leva left.");
            }
            else
            {
                Console.WriteLine($"{name} needs {moneyLeft:f2} more leva!");
            }



        }
    }
}
