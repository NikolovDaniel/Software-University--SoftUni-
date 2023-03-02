using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharityCampaign
{
    class Program
    {
        static void Main(string[] args)
        {
            double Cake = 45;
            double Waffle = 5.80;
            double Pancake = 3.20;

            double DaysOfCampaign = double.Parse(Console.ReadLine());
            double NumOfWorkers = double.Parse(Console.ReadLine());
            double NumOfCakes = double.Parse(Console.ReadLine());
            double NumOfWaffles = double.Parse(Console.ReadLine());
            double NumOfPancakes = double.Parse(Console.ReadLine());

            double CakesSum = NumOfCakes * Cake;
            double WafflesSum = NumOfWaffles * Waffle;
            double PancakesSum = NumOfPancakes * Pancake;

            double TotalSumForADay = (CakesSum + WafflesSum + PancakesSum) * NumOfWorkers;
            double TotalSumForTheCampaing = DaysOfCampaign * TotalSumForADay;
            double TotalSumAfterCost = TotalSumForTheCampaing - (TotalSumForTheCampaing / 8);

            Console.WriteLine("{0:F2}", TotalSumAfterCost);


        }
    }
}
