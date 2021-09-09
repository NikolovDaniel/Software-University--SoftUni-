using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeddingHall
{
    class Program
    {
        static void Main(string[] args)
        {
            double HallLengthMeters = double.Parse(Console.ReadLine());
            double HallWidthMeters = double.Parse(Console.ReadLine());
            double BarSideMeters = double.Parse(Console.ReadLine());

            double HallInSquareMeters = HallLengthMeters * HallWidthMeters; // 50 * 25 = 1250
            double BarSize = BarSideMeters * BarSideMeters; // 2 * 2 = 4
            double DancingSize = HallInSquareMeters * 0.19; // 1250 * 0.19 = 237.5
            double FreeSpace = HallInSquareMeters - BarSize - DancingSize; // 1250 - 4 - 237.5 = 1008.5
            double GuestsNumber = FreeSpace / 3.2; // 1008.5 / 3.2 = 315.15 >>> 316

            Console.WriteLine("{0}", Math.Ceiling(GuestsNumber));


        }
    }
}
