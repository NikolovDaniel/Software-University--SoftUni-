using System;
using System.Numerics;

namespace Snowballs
{
    class Program
    {
        static void Main(string[] args)
        {
            int madeSnowballs = int.Parse(Console.ReadLine());

           
            int bestSnowballSnow = 0;
            int bestSnowballTime = 0;
            int bestBallQuality = 0;            
            BigInteger bestSnowball = 0;

            for (int i = 0; i < madeSnowballs; i++)
            {

                int snowballSnow = int.Parse(Console.ReadLine());
                int snowballTime = int.Parse(Console.ReadLine());
                int snowballQuality = int.Parse(Console.ReadLine());

                BigInteger snowballValue = BigInteger.Pow((snowballSnow / snowballTime), snowballQuality);

                if (snowballValue >= bestSnowball)
                {
                    bestSnowball = snowballValue;
                    bestSnowballSnow = snowballSnow;
                    bestSnowballTime = snowballTime;
                    bestBallQuality = snowballQuality;
                }
            }

            Console.WriteLine($"{bestSnowballSnow} : {bestSnowballTime} = {bestSnowball} ({bestBallQuality})");
        }
    }
}
