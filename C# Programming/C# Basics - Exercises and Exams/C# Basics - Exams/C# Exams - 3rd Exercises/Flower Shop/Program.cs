using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training
{
    class Program
    {
        static void Main(string[] args)
        {
            int chrysantemum = int.Parse(Console.ReadLine());
            int roses = int.Parse(Console.ReadLine());
            int tullips = int.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            char Holiday = Console.ReadLine()[0];

            double chrysantemumPrice = 0;
            double rosesPrice = 0;
            double tullipsPrice = 0;
            int flowersNum = roses + chrysantemum + tullips;

            if (season == "Spring" || season == "Summer")
            {
                chrysantemumPrice = 2.00;
                rosesPrice = 4.10;
                tullipsPrice = 2.50;
            }

            else
            {
                chrysantemumPrice = 3.75;
                rosesPrice = 4.50;
                tullipsPrice = 4.15;
            }

            double totalSum = (chrysantemumPrice * chrysantemum) + (roses * rosesPrice) + (tullips * tullipsPrice);

            if (Holiday == 'Y')
            {
                totalSum = totalSum + (totalSum * 0.15);
            }

            if (season == "Spring" && tullips > 7)
            {
                totalSum = totalSum - (totalSum * 0.05);
            }

            if (season == "Winter" && roses >= 10)
            {
                totalSum = totalSum - (totalSum * 0.1);
            }

            if (flowersNum > 20)
            {
                totalSum = totalSum - (totalSum * 0.2);
            }
            Console.WriteLine($"{(totalSum + 2):f2}");
        }
    }
}



