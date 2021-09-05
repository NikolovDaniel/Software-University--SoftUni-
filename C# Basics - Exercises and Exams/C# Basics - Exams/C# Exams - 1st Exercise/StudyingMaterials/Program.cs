using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyingMaterials
{
    class Program
    {
        static void Main(string[] args)
        {
            double NumOfPacketsOfPencils = double.Parse(Console.ReadLine());
            double NumOfPacketsOfMarkers = double.Parse(Console.ReadLine());
            double LiterOfPreparats = double.Parse(Console.ReadLine());
            double Discount = double.Parse(Console.ReadLine());

            double PriceOfPacketsOfPencils = NumOfPacketsOfPencils * 5.80;
            double PriceOfPacketsOfMarkers = NumOfPacketsOfMarkers * 7.20;
            double PriceOfPreparats = LiterOfPreparats * 1.20;
            double SumOfAll = PriceOfPacketsOfMarkers + PriceOfPacketsOfPencils + PriceOfPreparats;
            double SumAfterDiscout = (SumOfAll - (SumOfAll * (Discount / 100)));

            Console.WriteLine("{0:F3}", SumAfterDiscout);




        }
    }
}
