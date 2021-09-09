
using System;

namespace SoftuniReception
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstEmployee = int.Parse(Console.ReadLine());
            int secondEmployee = int.Parse(Console.ReadLine());
            int thirdEmployee = int.Parse(Console.ReadLine());
            int people = int.Parse(Console.ReadLine());

            int pplPerHour = firstEmployee + secondEmployee + thirdEmployee;
            int hour = 0;
            int endHour = 0;

            while (people > 0)
            {
                hour++;
                if (hour == 4)
                {
                    hour = 0;
                    endHour++;
                }
                else
                {
                    people -= pplPerHour;
                    endHour++;
                }
            }

            Console.WriteLine($"Time needed: {endHour}h.");

        }
    }
}
