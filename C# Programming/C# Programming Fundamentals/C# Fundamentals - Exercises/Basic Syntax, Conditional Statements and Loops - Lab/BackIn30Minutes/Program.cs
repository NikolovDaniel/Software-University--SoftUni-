using System;

namespace BackIn30Minutes
{
    class Program
    {
        static void Main(string[] args)
        {
            int hours = int.Parse(Console.ReadLine());
            int minutes = int.Parse(Console.ReadLine());

            int totalMinutes = minutes + 30;

            if (totalMinutes > 59)
            {
                hours++;
                totalMinutes -= 60;
            }
            if (hours > 23) hours -= 24;

            if (totalMinutes >= 0 && totalMinutes < 10) Console.WriteLine($"{hours}:0{totalMinutes}");
            else Console.WriteLine($"{hours}:{totalMinutes}");
        }
    }
}
