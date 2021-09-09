using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2D_Rectangle_Area
{
    class Program
    {
        static void Main(string[] args)
        {
            double x1 = double.Parse(Console.ReadLine());
            double y1 = double.Parse(Console.ReadLine());
            double x2 = double.Parse(Console.ReadLine());
            double y2 = double.Parse(Console.ReadLine());

            double Lenght = Math.Abs(x1 - x2);
            double Width = Math.Abs(y1 - y2);

            double Area = Lenght * Width;
            double Perimeter = 2 * (Lenght + Width);

            Console.WriteLine("{0:F2}", Area);
            Console.WriteLine("{0:F2}", Perimeter);
               




        }
    }
}
