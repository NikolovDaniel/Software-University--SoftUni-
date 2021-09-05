using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USD_To_BGN
{
    class Program
    {
        static void Main(string[] args)
        {
            double USDCourse = 1.79549;

            double USD = double.Parse(Console.ReadLine());
            double BGN = USD * USDCourse;

            Console.WriteLine("{0:F}", BGN);
        }
    }
}
