using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toy_Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            double Puzzle = 2.60;
            double Doll = 3;
            double PlushBear = 4.10;
            double Minion = 8.20;
            double Truck = 2;
            // 50 Toys > 25% Discount, Rent = Total Sum - 10%

            double SumTrip = double.Parse(Console.ReadLine());
            int NumPuzzles = int.Parse(Console.ReadLine());
            int NumDolls = int.Parse(Console.ReadLine());
            int NumBears = int.Parse(Console.ReadLine());
            int NumMinions = int.Parse(Console.ReadLine());
            int NumTrucks = int.Parse(Console.ReadLine());

            double Sum = NumTrucks * Truck + NumMinions * Minion + NumBears * PlushBear + NumDolls * Doll + NumPuzzles * Puzzle;
            double NumofToys = NumTrucks + NumPuzzles + NumBears + NumDolls + NumMinions;
            double discount = 0.0;
            if (NumofToys >= 50)
            {
                discount = Sum * 0.25;
            }
            double FinalPrice = Sum - discount;
            FinalPrice = FinalPrice - (FinalPrice * 0.10);

            if(FinalPrice >= SumTrip)
            {
                Console.WriteLine("Yes! {0:F2} lv left.", FinalPrice - SumTrip);
            }
            else
            {
                Console.WriteLine("Not enough money! {0:F2} lv needed.", Math.Abs(FinalPrice - SumTrip));
            }

        
        }
    }
}
