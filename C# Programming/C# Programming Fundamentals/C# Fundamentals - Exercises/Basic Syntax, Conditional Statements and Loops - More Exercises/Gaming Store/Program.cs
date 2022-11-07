using System;

namespace SquareOfStars
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());

            string gameTime = Console.ReadLine();
            double gamePrice = 0;
            double moneySpent = 0;

            while (gameTime != "Game Time")
            {
                bool checker = gameTime != "OutFall 4" && gameTime != "CS: OG" && gameTime != "Zplinter Zell" && gameTime != "Honored 2" && gameTime != "RoverWatch" && gameTime != "RoverWatch Origins Edition";

                if (checker) Console.WriteLine("Not Found");
                if (gameTime == "OutFall 4") gamePrice = 39.99;
                if (gameTime == "CS: OG") gamePrice = 15.99;
                if (gameTime == "Zplinter Zell") gamePrice = 19.99;
                if (gameTime == "Honored 2") gamePrice = 59.99;
                if (gameTime == "RoverWatch") gamePrice = 29.99;
                if (gameTime == "RoverWatch Origins Edition") gamePrice = 39.99;

                if (gamePrice > budget) Console.WriteLine("Too Expensive");
                else if (!checker)
                {
                    Console.WriteLine($"Bought {gameTime}");
                    budget -= gamePrice;
                    moneySpent += gamePrice;
                }

                if (budget == 0)
                {
                    Console.WriteLine("Out of money!");
                    return;
                }

                gameTime = Console.ReadLine();
            }
            Console.WriteLine($"Total spent: ${moneySpent:f2}. Remaining: ${budget:f2}");
        }
    }
}
