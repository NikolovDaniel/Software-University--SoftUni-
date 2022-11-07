using System;
using System.Linq;
using System.Collections.Generic;
using System.Numerics;
using System.Diagnostics;
using System.Text;

namespace _08._Anonymous_Threat
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<double>> products = new Dictionary<string, List<double>>();


            string[] input = Console.ReadLine().Split();

            while (input[0] != "buy")
            {
                string product = input[0];
                double price = double.Parse(input[1]);
                double quantity = double.Parse(input[2]);

                if (products.ContainsKey(product))
                {
                    if (products[product][0] != price) products[product][0] = price;

                    products[product][1] += quantity;

                }
                else
                {
                    products.Add(product, new List<double>() { price, quantity });
                }

                input = Console.ReadLine().Split();
            }

            foreach (var product in products)
            {
                double price = product.Value[0] * product.Value[1];
                Console.WriteLine($"{product.Key} -> {price:f2}");
            }
        }
    }
}