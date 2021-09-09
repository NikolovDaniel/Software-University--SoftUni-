using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItsWeddingTime
{
    class Program
    {
        static void Main(string[] args)
        {
            double PriceOfWhiskey = double.Parse(Console.ReadLine());
            double WaterInLiters = double.Parse(Console.ReadLine());
            double WineInLiters = double.Parse(Console.ReadLine());
            double ChampagneInLiters = double.Parse(Console.ReadLine());
            double WhiskeyInLiters = double.Parse(Console.ReadLine());

            double PriceOfChampagne = PriceOfWhiskey * 0.50;
            double PriceOfWine = PriceOfChampagne * 0.4;
            double PriceOfWater = PriceOfChampagne * 0.1;
            double SumForChamapgne = ChampagneInLiters * PriceOfChampagne;
            double SumForWine = WineInLiters * PriceOfWine;
            double SumForWater = WaterInLiters * PriceOfWater;
            double SumForWhiskey = WhiskeyInLiters * PriceOfWhiskey;
            double TotalSum = SumForChamapgne + SumForWater + SumForWhiskey + SumForWine;

            Console.WriteLine("{0:F2}", TotalSum);

        }
    }
}
