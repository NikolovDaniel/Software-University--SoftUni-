using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping
{
    class Program
    {
        static void Main(string[] args)
        {
            double TimeForRest = double.Parse(Console.ReadLine());
            double PricePerPeripepherical = double.Parse(Console.ReadLine());
            double PricePerProgram = double.Parse(Console.ReadLine());
            double PriceForFrappe = double.Parse(Console.ReadLine());

            double TimeAfterBuyingFrappe = TimeForRest - 5;
            double TimeForPeripherical = 3 * 2;
            double TimeForPrograms = 2 * 2;
            double TimeForRelax = TimeAfterBuyingFrappe - (6 + 4);
            double MoneySpentOnPeripherical = 3 * PricePerPeripepherical;
            double MoneySpentOnPrograms = 2 * PricePerProgram;
            double TotalSpentSum = MoneySpentOnPeripherical + MoneySpentOnPrograms + PriceForFrappe;

            Console.WriteLine("{0:F2}" , TotalSpentSum);
            Console.WriteLine(TimeForRelax);

        }
    }
}
