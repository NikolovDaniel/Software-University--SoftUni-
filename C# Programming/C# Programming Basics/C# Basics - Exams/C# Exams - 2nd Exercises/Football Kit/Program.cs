using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Football_Kit
{
    class Program
    {
        static void Main(string[] args)
        {
            // Цена шорти = цена тениска * 0.75;
            // Цена чорапи = цена шорти * 0.20;
            double priceShirt = double.Parse(Console.ReadLine());
            double ball = double.Parse(Console.ReadLine());

            double priceShorts = priceShirt * 0.75; // Цена гащета
            double priceSocks = priceShorts * 0.2; // Цена чорапи
            double priceBoots = (priceShorts + priceShirt) * 2; // Цена бутонки
            double totalSum = priceSocks + priceBoots + priceShorts + priceShirt; // Обща сума
            double finalSum = totalSum - (totalSum * 0.15); // Сума след отстъпка
            double neededSum = Math.Abs(ball - finalSum); // Недостиг на сумата

            if (finalSum >= ball)
            {
                Console.WriteLine("Yes, he will earn the world-cup replica ball!");
                Console.WriteLine($"His sum is {finalSum:f2} lv.");
            }
            else
            {
                Console.WriteLine("No, he will not earn the world-cup replica ball.");
                Console.WriteLine($"He needs {neededSum:f2} lv. more.");
            }

        }
    }
}
