using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tailor_Workshop
{
    class Program
    {
        static void Main(string[] args)
        {

            double USD = 1.85;
            double AdditionalCM = 0.30;
            double SquareMeterForKare = 9;
            double SquareMeterForBlankets = 7;


            double NumberRectangleTables = double.Parse(Console.ReadLine());
            double LengthRectangleTablesInM = double.Parse(Console.ReadLine());
            double WidthRectangleTablesInM = double.Parse(Console.ReadLine());

            double AreaBlankets = NumberRectangleTables * (LengthRectangleTablesInM + 2 * AdditionalCM) * (WidthRectangleTablesInM + 2 * AdditionalCM);
            double AreaKare = NumberRectangleTables * (LengthRectangleTablesInM / 2) * (LengthRectangleTablesInM / 2);
            double PriceInUSD = (AreaBlankets * SquareMeterForBlankets) + (AreaKare * 9);
            double PriceInBGN = PriceInUSD * USD;

            Console.WriteLine("{0:F2} USD", PriceInUSD);
            Console.WriteLine("{0:F2} BGN", PriceInBGN);

        }
    }
}
