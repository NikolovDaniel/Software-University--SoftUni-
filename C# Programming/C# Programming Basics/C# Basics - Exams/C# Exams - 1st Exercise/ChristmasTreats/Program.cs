using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChristmasTreats
{
    class Program
    {
        static void Main(string[] args)
        {
            double PricePerKgBaklava = double.Parse(Console.ReadLine());
            double PricePerKgMuffins = double.Parse(Console.ReadLine());
            double KgScholen = double.Parse(Console.ReadLine());
            double KgCandy = double.Parse(Console.ReadLine());
            double KgBiscuits = double.Parse(Console.ReadLine());

            double PriceOfScholen = PricePerKgBaklava + PricePerKgBaklava * 0.60;
            double SumScholen = KgScholen * PriceOfScholen;
            double PriceOfCandy = PricePerKgMuffins + PricePerKgMuffins * 0.80;
            double SumCandy = KgCandy * PriceOfCandy;
            double SumBiscuits = KgBiscuits * 7.50;
            double SumTotal = SumScholen + SumCandy + SumBiscuits;

            Console.WriteLine("{0:F2}", SumTotal);

        



        }
    }
}
