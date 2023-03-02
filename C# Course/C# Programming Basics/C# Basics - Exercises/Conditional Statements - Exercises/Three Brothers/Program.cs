using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Three_Brothers
{
    class Program
    {
        static void Main(string[] args)
        {
            double firstBrother = double.Parse(Console.ReadLine());
            double secondBrother = double.Parse(Console.ReadLine());
            double thirdBrother = double.Parse(Console.ReadLine());
            double fatherTime = double.Parse(Console.ReadLine());

            double totalTime = 1 / (1 / firstBrother + 1 / secondBrother + 1 / thirdBrother);
            double timeWithRest = totalTime * 1.15;
            double timeDiff = Math.Abs(fatherTime - timeWithRest);

            Console.WriteLine($"Cleaning time: {timeWithRest:f2}");

            if (fatherTime > timeWithRest )
            {
                Console.WriteLine($"Yes, there is a surprise - time left -> {Math.Floor(timeDiff)} hours.");
            }
            else
            {
                Console.WriteLine($"No, there isn't a surprise - shortage of time -> {Math.Ceiling(timeDiff)} hours.");
            }
        }
    }
}
