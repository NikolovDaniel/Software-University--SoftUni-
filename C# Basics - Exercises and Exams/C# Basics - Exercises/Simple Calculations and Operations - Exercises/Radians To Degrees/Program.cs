using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Radians_To_Degrees
{
    class Program
    {
        static void Main(string[] args)
        {
            double rad = double.Parse(Console.ReadLine());

            double deg = rad * 180 / Math.PI;

            Console.WriteLine("{0}", Math.Round(deg));
        }
    }
}
