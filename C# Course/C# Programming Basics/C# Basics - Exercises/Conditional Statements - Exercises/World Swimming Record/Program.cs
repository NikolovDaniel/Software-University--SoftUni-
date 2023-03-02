using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace World_Swimming_Record
{
    class Program
    {
        static void Main(string[] args)
        {
            double recordSeconds = double.Parse(Console.ReadLine());
            double distanceMeters = double.Parse(Console.ReadLine());
            double secondsForMeter = double.Parse(Console.ReadLine());

            double metersSwimming = distanceMeters * secondsForMeter;
            double slowedTime = Math.Floor(distanceMeters / 15);
            double slowedTime1 = slowedTime * 12.5;
            double TotalTime = metersSwimming + slowedTime1;

            if (TotalTime < recordSeconds)
            {
                Console.WriteLine("Yes, he succeeded! The new world record is {0:F2} seconds.", TotalTime);               
            }
            else
            {
                Console.WriteLine("No, he failed! He was {0:F2} seconds slower.", TotalTime - recordSeconds);
            }

            


        }
    }
}
