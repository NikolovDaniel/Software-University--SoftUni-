using System;

namespace FruitMarket
{
    class Program
    {
        static void Main(string[] args)
        {
            //INPUT
            double priceStrawberries = double.Parse(Console.ReadLine());
            double quantityBananas = double.Parse(Console.ReadLine());
            double quantityOranges = double.Parse(Console.ReadLine());
            double quantityRaspberries = double.Parse(Console.ReadLine());
            double quantityStrawberries = double.Parse(Console.ReadLine());

            //SOLUTION
            double priceRaspberries = priceStrawberries / 2;
            double priceOranges = priceRaspberries - (priceRaspberries * 0.40);
            double priceBananas = priceRaspberries - (priceRaspberries * 0.80);
            double endPriceStrawberries = priceStrawberries * quantityStrawberries;
            double endPriceOranges = priceOranges * quantityOranges;
            double endPriceRaspberries = priceRaspberries * quantityRaspberries;
            double endPriceBananas = priceBananas * quantityBananas;
            double totalSum = endPriceBananas + endPriceOranges + endPriceRaspberries + endPriceStrawberries;

            //OUTPUT
            Console.WriteLine(totalSum);

        }
    }
}
