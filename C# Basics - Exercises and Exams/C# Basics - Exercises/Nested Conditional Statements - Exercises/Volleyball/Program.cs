using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Journey
{
    class Program
    {
        static void Main(string[] args)
        {
            string year = Console.ReadLine();
            int holidays = int.Parse(Console.ReadLine());
            int weekends = int.Parse(Console.ReadLine());

            double yearWeekends = 48;
            double homePlay = weekends;
            double holidaysPlay = holidays * 2.0 / 3;
            double sofiaPlay = 0;
            double totalDays = 0;
            double leapYear = 0;

            if (year == "normal")
            {
                yearWeekends = yearWeekends - weekends;
                sofiaPlay = yearWeekends * 3.0 / 4;
                homePlay = weekends;
                holidaysPlay = holidays * 2.0 / 3;
                totalDays = Math.Floor(sofiaPlay + homePlay + holidaysPlay);
                Console.WriteLine($"{totalDays}");

            }
            else if (year == "leap")
            {
                yearWeekends = yearWeekends - weekends;
                sofiaPlay = yearWeekends * 3.0 / 4;
                homePlay = weekends;
                holidaysPlay = holidays * 2.0 / 3;
                totalDays = sofiaPlay + homePlay + holidaysPlay;
                leapYear = Math.Floor(totalDays + (totalDays * 0.15));
                Console.WriteLine($"{leapYear}");

            }
        }
    }
}
