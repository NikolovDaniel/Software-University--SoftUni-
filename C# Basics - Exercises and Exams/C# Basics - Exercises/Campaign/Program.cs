using System;

namespace Campaign
{
    class Program
    {
        static void Main(string[] args)
        {
            const double cakes = 45;
            const double waffles = 5.80;
            const double pancakes = 3.20;

            //INPUT 
            int daysCampaign = int.Parse(Console.ReadLine());
            int numBakers = int.Parse(Console.ReadLine());
            int numCakes = int.Parse(Console.ReadLine());
            int numWaffles = int.Parse(Console.ReadLine());
            int numPancakes = int.Parse(Console.ReadLine());

            //SOLUTION
            double sumCakes = cakes * numCakes;
            double sumWaffles = waffles * numWaffles;
            double sumPancakes = pancakes * numPancakes;
            double sumPerDay = (sumCakes + sumWaffles + sumPancakes) * 8;
            double totalSum = sumPerDay * daysCampaign;
            double productCost = totalSum / 8;
            double finalSum = totalSum - productCost;

            //OUTPUT
            Console.WriteLine(finalSum);
        }
    }
}

