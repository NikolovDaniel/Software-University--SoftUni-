using System;
using System.Collections.Generic;

namespace ProductShop
{
    class Program
    {
        static void Main(string[] args)
        {

            string[] input = Console.ReadLine().Split(", ");

            SortedDictionary<string, Dictionary<string, double>> marketShops = new SortedDictionary<string, Dictionary<string, double>>();


            while (input[0] != "Revision")
            {

                string shop = input[0];
                string product = input[1];
                double price = double.Parse(input[2]);

                if (marketShops.ContainsKey(shop))
                {
                    marketShops[shop].Add(product, price);
                }
                else
                {
                    marketShops.Add(shop, new Dictionary<string, double>()
                    {
                        {product, price }
                    });
                }


                input = Console.ReadLine().Split(", ");
            }

            foreach (var shop in marketShops)
            {
                Console.WriteLine($"{shop.Key}->");
                foreach (var product in shop.Value)
                {
                    Console.WriteLine($"Product: {product.Key}, Price: {product.Value}");
                }
            }


        }
    }
}
