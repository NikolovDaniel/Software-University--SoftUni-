using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Choreography
{
    class Program
    {
        static void Main(string[] args)
        {
            double numSteps = double.Parse(Console.ReadLine());
            double numDancers = double.Parse(Console.ReadLine());
            double numDays = double.Parse(Console.ReadLine());

            double percentSteps = (numSteps / numDays) / numSteps; // (55555 / 7) / 55555 = 0.1428...
            double percentStepsReal = Math.Ceiling(percentSteps * 100); // 0.1428 * 100 = 14.28 -> 15%
            double percentStepsDancer = percentStepsReal / numDancers; // 15% / 30 = 0.50%
            double allowedPercent = 13;
            if ( percentStepsReal < allowedPercent)
            {
                Console.WriteLine($"Yes, they will succeed in that goal! {percentStepsDancer:f2}%.");
            }
            else 
            {
                Console.WriteLine($"No, they will not succeed in that goal! Required {percentStepsDancer:f2}% steps to be learned per day.");
            }
        }
    }
}
