using System;

namespace ToyShop
{
    class Program
    {
        static void Main(string[] args)
        {
            //PRICE OF TOYS
            double puzzle = 2.60;
            double doll = 3;
            double bear = 4.10;
            double minion = 8.20;
            double truck = 2;

            //INPUT
            double priceTrip = double.Parse(Console.ReadLine());
            int quantityPuzzle = int.Parse(Console.ReadLine());
            int quantityDoll = int.Parse(Console.ReadLine());
            int quantityBear = int.Parse(Console.ReadLine());
            int quantityMinion = int.Parse(Console.ReadLine());
            int quantityTruck= int.Parse(Console.ReadLine());

            //SOLUTION
            double sumPuzzle = quantityPuzzle * puzzle;
            double sumDoll = quantityDoll * doll;
            double sumBear = quantityBear * bear;
            double sumMinion = quantityMinion * minion;
            double sumTruck = quantityTruck * truck;

            double totalSum = sumBear + sumDoll + sumMinion + sumPuzzle + sumTruck;
            double totalToys = quantityBear + quantityDoll + quantityMinion + quantityPuzzle + quantityTruck;
            double discount = 0.0;
          
            if (totalToys >= 50)
            {
                discount = totalSum * 0.25;
            }
            double finalSum = totalSum - discount;
            finalSum = finalSum - (finalSum * 0.10);

            if (finalSum >= priceTrip)
            {
                Console.WriteLine($"Yes! {finalSum - priceTrip:f2} lv left.");
            }
            else
            {
                Console.WriteLine($"Not enough money! {Math.Abs(finalSum - priceTrip):f2} lv needed.");
            }
        }
    }
}
