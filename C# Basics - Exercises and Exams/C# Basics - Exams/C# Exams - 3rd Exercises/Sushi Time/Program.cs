using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sushi_Time
{
    class Program
    {
        static void Main(string[] args)
        {
            string sushiName = Console.ReadLine();
            string resName = Console.ReadLine();
            int numPortion = int.Parse(Console.ReadLine());
            char output = Console.ReadLine()[0];


            if (resName != "Sushi Time" && resName != "Sushi Zone" && resName != "Sushi Bar" && resName != "Asian Pub")
            {
                Console.WriteLine($"{resName} is invalid restaurant!");
            }
            else if (resName == "Sushi Zone")
            {
                if (sushiName == "maki")
                {
                    if (output == 'Y')
                    {
                        double foodPrice = numPortion * 5.29;
                        double takeAwayPrice = foodPrice + (foodPrice * 0.20);
                        Console.WriteLine($"Total price: {Math.Ceiling(takeAwayPrice)} lv.");
                    }
                    else if (output == 'N')
                    {
                        double foodPrice = numPortion * 5.29;
                        Console.WriteLine($"Total price: {Math.Ceiling(foodPrice)} lv.");
                    }
                }
                else if (sushiName == "sashimi")
                {
                    if (output == 'Y')
                    {
                        double foodPrice = numPortion * 4.99;
                        double takeAwayPrice = foodPrice + (foodPrice * 0.20);
                        Console.WriteLine($"Total price: {Math.Ceiling(takeAwayPrice)} lv.");
                    }
                    else if (output == 'N')
                    {
                        double foodPrice = numPortion * 4.99;
                        Console.WriteLine($"Total price: {Math.Ceiling(foodPrice)} lv.");
                    }
                }
                else if (sushiName == "uramaki")
                {
                    if (output == 'Y')
                    {
                        double foodPrice = numPortion * 5.99;
                        double takeAwayPrice = foodPrice + (foodPrice * 0.20);
                        Console.WriteLine($"Total price: {Math.Ceiling(takeAwayPrice)} lv.");
                    }
                    else if (output == 'N')
                    {
                        double foodPrice = numPortion * 5.99;
                        Console.WriteLine($"Total price: {Math.Ceiling(foodPrice)} lv.");
                    }
                }
                else if (sushiName == "temaki")
                {
                    if (output == 'Y')
                    {
                        double foodPrice = numPortion * 4.29;
                        double takeAwayPrice = foodPrice + (foodPrice * 0.20);
                        Console.WriteLine($"Total price: {Math.Ceiling(takeAwayPrice)} lv.");
                    }
                    else if (output == 'N')
                    {
                        double foodPrice = numPortion * 4.29;
                        Console.WriteLine($"Total price: {Math.Ceiling(foodPrice)} lv.");
                    }
                }
            }
            else if (resName == "Sushi Time")
            {
                if (sushiName == "maki")
                {
                    if (output == 'Y')
                    {
                        double foodPrice = numPortion * 4.69;
                        double takeAwayPrice = foodPrice + (foodPrice * 0.20);
                        Console.WriteLine($"Total price: {Math.Ceiling(takeAwayPrice)} lv.");
                    }
                    else if (output == 'N')
                    {
                        double foodPrice = numPortion * 4.69;
                        Console.WriteLine($"Total price: {Math.Ceiling(foodPrice)} lv.");
                    }
                }
                else if (sushiName == "sashimi")
                {
                    if (output == 'Y')
                    {
                        double foodPrice = numPortion * 5.49;
                        double takeAwayPrice = foodPrice + (foodPrice * 0.20);
                        Console.WriteLine($"Total price: {Math.Ceiling(takeAwayPrice)} lv.");
                    }
                    else if (output == 'N')
                    {
                        double foodPrice = numPortion * 5.49;
                        Console.WriteLine($"Total price: {Math.Ceiling(foodPrice)} lv.");
                    }
                }
                else if (sushiName == "uramaki")
                {
                    if (output == 'Y')
                    {
                        double foodPrice = numPortion * 4.49;
                        double takeAwayPrice = foodPrice + (foodPrice * 0.20);
                        Console.WriteLine($"Total price: {Math.Ceiling(takeAwayPrice)} lv.");
                    }
                    else if (output == 'N')
                    {
                        double foodPrice = numPortion * 4.49;
                        Console.WriteLine($"Total price: {Math.Ceiling(foodPrice)} lv.");
                    }
                }
                else if (sushiName == "temaki")
                {
                    if (output == 'Y')
                    {
                        double foodPrice = numPortion * 5.19;
                        double takeAwayPrice = foodPrice + (foodPrice * 0.20);
                        Console.WriteLine($"Total price: {Math.Ceiling(takeAwayPrice)} lv.");
                    }
                    else if (output == 'N')
                    {
                        double foodPrice = numPortion * 5.19;
                        Console.WriteLine($"Total price: {Math.Ceiling(foodPrice)} lv.");
                    }
                }
            }
            else if (resName == "Sushi Bar")
            {
                if (sushiName == "maki")
                {
                    if (output == 'Y')
                    {
                        double foodPrice = numPortion * 5.55;
                        double takeAwayPrice = foodPrice + (foodPrice * 0.20);
                        Console.WriteLine($"Total price: {Math.Ceiling(takeAwayPrice)} lv.");
                    }
                    else if (output == 'N')
                    {
                        double foodPrice = numPortion * 5.55;
                        Console.WriteLine($"Total price: {Math.Ceiling(foodPrice)} lv.");
                    }
                }
                else if (sushiName == "sashimi")
                {
                    if (output == 'Y')
                    {
                        double foodPrice = numPortion * 5.25;
                        double takeAwayPrice = foodPrice + (foodPrice * 0.20);
                        Console.WriteLine($"Total price: {Math.Ceiling(takeAwayPrice)} lv.");
                    }
                    else if (output == 'N')
                    {
                        double foodPrice = numPortion * 5.25;
                        Console.WriteLine($"Total price: {Math.Ceiling(foodPrice)} lv.");
                    }
                }
                else if (sushiName == "uramaki")
                {
                    if (output == 'Y')
                    {
                        double foodPrice = numPortion * 6.25;
                        double takeAwayPrice = foodPrice + (foodPrice * 0.20);
                        Console.WriteLine($"Total price: {Math.Ceiling(takeAwayPrice)} lv.");
                    }
                    else if (output == 'N')
                    {
                        double foodPrice = numPortion * 6.25;
                        Console.WriteLine($"Total price: {Math.Ceiling(foodPrice)} lv.");
                    }
                }
                else if (sushiName == "temaki")
                {
                    if (output == 'Y')
                    {
                        double foodPrice = numPortion * 4.75;
                        double takeAwayPrice = foodPrice + (foodPrice * 0.20);
                        Console.WriteLine($"Total price: {Math.Ceiling(takeAwayPrice)} lv.");
                    }
                    else if (output == 'N')
                    {
                        double foodPrice = numPortion * 4.75;
                        Console.WriteLine($"Total price: {Math.Ceiling(foodPrice)} lv.");
                    }
                }
            }
            else if (resName == "Asian Pub")
            {
                if (sushiName == "maki")
                {
                    if (output == 'Y')
                    {
                        double foodPrice = numPortion * 4.80;
                        double takeAwayPrice = foodPrice + (foodPrice * 0.20);
                        Console.WriteLine($"Total price: {Math.Ceiling(takeAwayPrice)} lv.");
                    }
                    else if (output == 'N')
                    {
                        double foodPrice = numPortion * 4.80;
                        Console.WriteLine($"Total price: {Math.Ceiling(foodPrice)} lv.");
                    }
                }
                else if (sushiName == "sashimi")
                {
                    if (output == 'Y')
                    { 
                        double foodPrice = numPortion * 4.50;
                        double takeAwayPrice = foodPrice + (foodPrice * 0.20);
                        Console.WriteLine($"Total price: {Math.Ceiling(takeAwayPrice)} lv.");
                    }
                    else if (output == 'N')
                    {
                        double foodPrice = numPortion * 4.50;
                        Console.WriteLine($"Total price: {Math.Ceiling(foodPrice)} lv.");
                    }
                }
                else if (sushiName == "uramaki")
                {
                    if (output == 'Y')
                    {
                        double foodPrice = numPortion * 5.50;
                        double takeAwayPrice = foodPrice + (foodPrice * 0.20);
                        Console.WriteLine($"Total price: {Math.Ceiling(takeAwayPrice)} lv.");
                    }
                    else if (output == 'N')
                    {
                        double foodPrice = numPortion * 5.50;
                        Console.WriteLine($"Total price: {Math.Ceiling(foodPrice)} lv.");
                    }
                }
                else if (sushiName == "temaki")
                {
                    if (output == 'Y')
                    {
                        double foodPrice = numPortion * 5.50;
                        double takeAwayPrice = foodPrice + (foodPrice * 0.20);
                        Console.WriteLine($"Total price: {Math.Ceiling(takeAwayPrice)} lv.");
                    }
                    else if (output == 'N')
                    {
                        double foodPrice = numPortion * 5.50;
                        Console.WriteLine($"Total price: {Math.Ceiling(foodPrice)} lv.");
                    }
                }
            }
        }
    }
}
                
