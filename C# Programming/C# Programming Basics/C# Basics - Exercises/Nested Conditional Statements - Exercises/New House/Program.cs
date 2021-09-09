using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace New_House
{
    class Program
    {
        static void Main(string[] args)
        {
            string flowerType = Console.ReadLine();
            int numFlowers = int.Parse(Console.ReadLine());
            int budget = int.Parse(Console.ReadLine());
            double totalSum = 0;
            double discount = 0;

            if (flowerType == "Roses")
            {
                totalSum = numFlowers * 5;
                if (numFlowers > 80)
                {
                    discount = 0.1;
                    totalSum -= totalSum * discount;
                }
            }
            else if (flowerType == "Dahlias")
            {
                totalSum = numFlowers * 3.80;
                if (numFlowers > 90)
                {
                    discount = 0.15;
                    totalSum -= totalSum * 0.15;
                }
            }
            else if (flowerType == "Tulips")
            {
                totalSum = numFlowers * 2.80;
                if (numFlowers > 80)
                {
                    discount = 0.15;
                    totalSum -= totalSum * 0.15;
                }
            }
            else if (flowerType == "Narcissus")
            {
                totalSum = numFlowers * 3;
                if (numFlowers < 120)
                {
                    discount = 0.15;
                    totalSum += totalSum * 0.15;
                }
            }
            else if (flowerType == "Gladiolus")
            {
                totalSum = numFlowers * 2.50;
                if (numFlowers < 80)
                {
                    discount = 0.2;
                    totalSum += totalSum * 0.2;
                }
            }
            if (totalSum > budget)
            {
                Console.WriteLine("Not enough money, you need {0:f2} leva more.", Math.Abs(totalSum - budget));
            }
            else if (budget >= totalSum)
            {
                Console.WriteLine($"Hey, you have a great garden with {numFlowers} {flowerType} and {Math.Abs(totalSum - budget):f2} leva left.");
            }
        }
    }
}
