using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Time__15_Minutes
{
    class Program
    {
        static void Main(string[] args)
        {
            int startHour = int.Parse(Console.ReadLine());
            int startMinutes = int.Parse(Console.ReadLine());
            int timeInMinutes = startHour * 60 + startMinutes;
            int timePlus15 = timeInMinutes + 15;
            int finalHour = timePlus15 / 60;
            int finalMinutes = timePlus15 % 60;

            if (finalHour >= 24)
            {
                finalHour -= 24;
            }

            if (finalMinutes <= 9)
            {
                Console.WriteLine("{0}:0{1}", finalHour,finalMinutes);
            }
            else
            {
                Console.WriteLine("{0}:{1}", finalHour, finalMinutes);
            }
            


            
        }
    }
}
