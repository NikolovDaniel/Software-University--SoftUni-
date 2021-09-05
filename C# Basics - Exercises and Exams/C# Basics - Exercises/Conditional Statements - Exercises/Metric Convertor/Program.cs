using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metric_Convertor
{
    class Program
    {
        static void Main(string[] args)
        {
            double number = double.Parse(Console.ReadLine());
            string Input = Console.ReadLine();
            string Output = Console.ReadLine();

            double meter = 0;

            if (Input == "mm")
            {
                meter = number / 1000;
            }
            else if (Input == "cm")
            {
                meter = number / 100;
            }
            else if (Input == "m")
            {
                meter = number;
            }

            double outputNumber = 0;
            
            if (Output == "mm")
            {
                outputNumber = meter * 1000;
            }
            else if (Output == "cm")
            {
                outputNumber = meter * 100;
            }
            else if (Output == "m")
            {
                outputNumber = meter;
            }
            Console.WriteLine("{0:F3}", outputNumber);
            


        }
    }
}
