using System;

namespace CalculatorDeposit
{
    class Program
    {
        static void Main(string[] args)
        {
            double depositSum = double.Parse(Console.ReadLine());
            int months = int.Parse(Console.ReadLine());
            double yearInterest = double.Parse(Console.ReadLine());

            double totalInterest = depositSum * (yearInterest / 100); // 200 * (5.7 / 100)
            double monthInterest = totalInterest / 12; // 11.4 / 12 
            double totalSum = depositSum + (months * monthInterest); // 200 +  (3 * 0.95)
            Console.WriteLine(totalSum);
        }
    }
}
