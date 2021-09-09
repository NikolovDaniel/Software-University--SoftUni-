using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StadiumIncome
{
    class Program
    {
        static void Main(string[] args)
        {
            double  SectorsNumber = double.Parse(Console.ReadLine());
            double StadiumCapacity = double.Parse(Console.ReadLine());
            double PriceTicket = double.Parse(Console.ReadLine());

            double SectorsIncome = (StadiumCapacity * PriceTicket) / SectorsNumber;
            double Income = SectorsIncome * SectorsNumber;
            double CharityMoney = (Income - (SectorsIncome * 0.75)) / 8;

            Console.WriteLine("Total income - {0:F2} BGN", Income);
            Console.WriteLine("Money for charity - {0:F2} BGN", CharityMoney);

            
        }
    }
}
