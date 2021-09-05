using System;

namespace Time_15Minutes
{
    class Program
    {
        static void Main(string[] args)
        {
            //INPUT 
            int hour = int.Parse(Console.ReadLine());
            int minutes = int.Parse(Console.ReadLine());
            //VARIABLES
            int timeInMinutes = hour * 60 + minutes; // 1 * 60 + 46 = 106; / 23 * 60 + 59 = 1439
            int timePlus15 = timeInMinutes + 15; // 106 + 121; / 1439 + 15 = 1454
            int finalHour = timePlus15 / 60; // 121 / 60 = 2 / 1454 / 60 = 24
            int finalMinutes = timePlus15 % 60; // 121 % 60 = 1 / 1454 % 60 = 14
            //OUTPUT
            if (finalHour >= 24)
            {
                finalHour -= 24;
            }
            if (finalMinutes <= 9)
            {
                Console.WriteLine($"{finalHour}:0{finalMinutes}");
            }
            else
            {
                Console.WriteLine($"{finalHour}:{finalMinutes}");
            }                 
        }
    }
}
