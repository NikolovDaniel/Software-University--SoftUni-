using System;

namespace BlackFlag
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            int dailyPlunder = int.Parse(Console.ReadLine());
            double expectedPlunder = double.Parse(Console.ReadLine());

            int counter = 0;
            int counterBattle = 0;
            double totalPlunder = 0;


            for (int i = 0; i < days; i++)
            {

                counter++;
                counterBattle++;

                if (counter == 3)
                {
                    totalPlunder += dailyPlunder + (dailyPlunder * 0.50);
                    counter = 0;
                }
                else
                {
                    totalPlunder += dailyPlunder;
                }

                if (counterBattle == 5)
                {
                    totalPlunder -= totalPlunder * 0.30;
                    counterBattle = 0;
                }

            }

            if (totalPlunder >= expectedPlunder)
            {
                Console.WriteLine($"Ahoy! {totalPlunder:f2} plunder gained.");
            }
            else
            {
                double percentCollected = (totalPlunder / expectedPlunder) * 100;
                Console.WriteLine($"Collected only {percentCollected:f2}% of the plunder.");
            }
        }
    }
}
