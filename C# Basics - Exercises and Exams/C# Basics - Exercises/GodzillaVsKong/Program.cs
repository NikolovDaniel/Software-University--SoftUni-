using System;

namespace GodzillaVsKong
{
    class Program
    {
        static void Main(string[] args)
        {            
            //INPUT
            double budget = double.Parse(Console.ReadLine()); // 9587.88
            int statisticians = int.Parse(Console.ReadLine()); // 222
            double priceForOne = double.Parse(Console.ReadLine()); // 55.68
            //SOLUTION         
            double decor = budget * 0.10; // 20000 * 0.10 = 958.78;
            double priceForClothes = priceForOne * statisticians; // 55.68 * 222 = 11124.86;
            double totalPriceForMovie = decor + priceForClothes; // 958.78 + 11124.86 = 12083.65;
            double moneyLeft = budget - totalPriceForMovie; // 9587.88 - 12083.65 = -2495.77;
            double discount = 0.0;
            if (statisticians > 150)
            {
                discount = priceForClothes * 0.10;
                moneyLeft += discount;
            }
            if (totalPriceForMovie <= budget) 
            {
                Console.WriteLine("Action!");
                Console.WriteLine($"Wingard starts filming with {moneyLeft:f2} leva left.");
            }
            else if (totalPriceForMovie > budget)
            {
                Console.WriteLine("Not enough money!");
                Console.WriteLine($"Wingard needs {Math.Abs(moneyLeft):f2} leva more.");
            }
        }
    }
}
