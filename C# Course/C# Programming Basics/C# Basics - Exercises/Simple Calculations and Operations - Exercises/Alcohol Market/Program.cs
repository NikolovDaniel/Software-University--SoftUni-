using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alcohol_Market
{
    class Program
    {
        static void Main(string[] args)
        {
            double PriceWhiskey = double.Parse(Console.ReadLine());
            double QuantityBeer = double.Parse(Console.ReadLine());
            double QuantityWine = double.Parse(Console.ReadLine());
            double QuantityRakija = double.Parse(Console.ReadLine());
            double QuantityWhiskey = double.Parse(Console.ReadLine());


            double RakijaPrice = PriceWhiskey / 2;

            double PriceWine = RakijaPrice - (0.4 * RakijaPrice); // 31.72 - ( 0.4 * 31.72 ) = 19.04
            double PriceBeer = RakijaPrice - (0.8 * RakijaPrice); // 31.72 - ( 0.8 * 31.72 ) = 6.35

            double SumRakija = QuantityRakija * RakijaPrice; // 31.72 * 8.15 = 258.518
            double SumWine = QuantityWine * PriceWine; // 6.35 * 19.04 = 120.904
            double SumBeer = QuantityBeer * PriceBeer; // 3.57 * 6.35 = 22.669
            double SumWhiskey = QuantityWhiskey * PriceWhiskey; // 2.5 * 50 = 125

            double TotalSum = SumBeer + SumRakija + SumWhiskey + SumWine;

            Console.WriteLine("{0:F2}", TotalSum);

        }
    }
}
