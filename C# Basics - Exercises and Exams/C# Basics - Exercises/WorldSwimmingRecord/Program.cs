using System;

namespace WorldSwimmingRecord
{
    class Program
    {
        static void Main(string[] args)
        {                     
            //INPUT
            double worldRecord = double.Parse(Console.ReadLine());
            double distanceMeters = double.Parse(Console.ReadLine());
            double timeForOneMeter = double.Parse(Console.ReadLine());
            //SOLUTION
            double metersToSwim = distanceMeters * timeForOneMeter; // 3017 * 5.03 = 15175.51
            double slowDown = Math.Floor(distanceMeters / 15); // 3017 / 15 = 201
            slowDown = (slowDown * 12.5);
            double totalTime = metersToSwim + slowDown;     
            if (totalTime >= worldRecord)
            {
                Console.WriteLine($"No, he failed! He was {(totalTime - worldRecord):f2} seconds slower.");
            }
            else 
            {          
                Console.WriteLine($"Yes, he succeeded! The new world record is {totalTime:f2} seconds.");
            }
        }
    }
}
