using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bonus_Score
{
    class Program
    {
        static void Main(string[] args)
        {
            double number = double.Parse(Console.ReadLine());
            double bonus = 0;
            if (number <= 100)
            {
                bonus =  5;
            }
            else if (number > 1000)
            {
                bonus = number * 0.10;              
            }
            else if (number > 100)
            {
                bonus = number * 0.20;              
            }
            if (number % 2 == 0)
            {
                bonus = bonus + 1;
            }
            else if (number % 10 == 5)
            {
                bonus = bonus + 2;
            }
            Console.WriteLine(bonus);
            double totalNumber = bonus + number;
            Console.WriteLine(totalNumber);
        }
    }
}