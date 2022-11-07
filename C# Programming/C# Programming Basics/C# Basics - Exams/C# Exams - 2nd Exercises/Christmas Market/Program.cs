using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Christmas_Market
{
    class Program
    {
        static void Main(string[] args)
        {
            //Фентъзи – 14.90 лв.
            // Хорър – 9.80 лв.
            //Романтика – 4.30 лв

            double moneyNeeded = double.Parse(Console.ReadLine());
            int fantasy = int.Parse(Console.ReadLine());
            int horror = int.Parse(Console.ReadLine());
            int romantic = int.Parse(Console.ReadLine());

            double totalSum = fantasy * 14.90 + horror * 9.80 + romantic * 4.30; // сбор обща сума
            double sumVAT = totalSum - (totalSum * 0.20); // обща сума след ДДС
            double bonus = sumVAT - moneyNeeded; // формула за бонуса
            double bonusEmp = Math.Floor(bonus * 0.10); // сбор на бонуса на служителите
            double bonusMoney = moneyNeeded + (bonus - bonusEmp); // сбор на бонуса към дарението
            double noMoney = moneyNeeded - sumVAT;


            if ( sumVAT > moneyNeeded)
            {
                Console.WriteLine($"{bonusMoney:f2} leva donated.");
                Console.WriteLine("Sellers will receive {0} leva.", Math.Floor(bonusEmp));

            }
            else
            {
                Console.WriteLine($"{noMoney:f2} money needed.");
            }

            

        }
    }
}
