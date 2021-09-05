using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Going_Home
{
    class Program
    {
        static void Main(string[] args)
        {


            double distanceKM = double.Parse(Console.ReadLine()); // Дистанция в километри
            double diesel100 = double.Parse(Console.ReadLine()); // Разход на бензина 100 км
            double priceDiesel = double.Parse(Console.ReadLine()); // Цена на бензина за 1 литър
            double sumWon = double.Parse(Console.ReadLine()); // Спечелени пари от турнира
                double costDiesel = distanceKM * diesel100 / 100;
                double totalCost = costDiesel * priceDiesel;
                double enoughMoney = Math.Abs(totalCost - sumWon);

                if (sumWon >= totalCost)
                {
                    Console.WriteLine("You can go home. {0:f2} money left.", enoughMoney);

                }
                else
                {
                    double divideMoney = sumWon / 5;
                    Console.WriteLine("Sorry, you cannot go home. Each will receive {0:f2} money.", divideMoney);
                }

            
        }
    }

}
    

