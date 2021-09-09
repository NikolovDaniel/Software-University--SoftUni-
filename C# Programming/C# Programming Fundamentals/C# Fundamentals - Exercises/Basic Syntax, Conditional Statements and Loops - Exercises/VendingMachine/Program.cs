using System;

namespace VendingMachine
{
    class Program
    {
        static void Main(string[] args)
        {

            string coins = Console.ReadLine();
            double sumCoins = 0;

            while (coins != "Start")
            {
                double coin = double.Parse(coins);

                if (coin == 0.1 || coin == 0.2 || coin == 0.5 || coin == 1 || coin == 2)
                {
                    sumCoins += coin;
                }
                else
                {
                    Console.WriteLine($"Cannot accept {coin}");
                }

                coins = Console.ReadLine();
            }

            string product = Console.ReadLine();

            while (product != "End")
            {

                if (product == "Nuts" && sumCoins - 2 >= 0)
                {
                    Console.WriteLine("Purchased nuts");
                    sumCoins -= 2;
                }
                else if (product == "Water" && sumCoins - 0.7 >= 0)
                {
                    Console.WriteLine("Purchased water");
                    sumCoins -= 0.7;
                }
                else if (product == "Crisps" && sumCoins - 1.5 >= 0)
                {
                    Console.WriteLine("Purchased crisps");
                    sumCoins -= 1.5;
                }
                else if (product == "Soda" && sumCoins - 0.8 >= 0)
                {
                    Console.WriteLine("Purchased soda");
                    sumCoins -= 0.8;
                }
                else if (product == "Coke" && sumCoins - 1.0 >= 0)
                {
                    Console.WriteLine("Purchased coke");
                    sumCoins -= 1.0;
                }
                else if (product != "Coke" && product != "Soda" && product != "Crisps" && product != "Water" && product != "Nuts")
                {
                    Console.WriteLine("Invalid product");
                }
                else
                {
                    Console.WriteLine("Sorry, not enough money");
                }

                product = Console.ReadLine();
            }

            Console.WriteLine($"Change: {sumCoins:f2}");

        }
    }
}
