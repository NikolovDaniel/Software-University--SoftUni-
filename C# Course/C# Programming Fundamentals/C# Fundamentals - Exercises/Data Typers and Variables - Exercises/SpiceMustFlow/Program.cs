using System;

namespace SpiceMustFlow
{
    class Program
    {
        static void Main(string[] args)
        {
            int startingYield = int.Parse(Console.ReadLine());
        
            int dayCounter = 0;           
            int yieldConsume = 26;
            int extractedYield = 0;

            while (startingYield >= 100)
            {
                extractedYield += startingYield - yieldConsume;
                startingYield -= 10;
                dayCounter++;

                if (startingYield < 100)
                {
                    extractedYield -= yieldConsume;
                    break;
                }
            }

            
            Console.WriteLine(dayCounter);
            Console.WriteLine(extractedYield);
        }
    }
}
