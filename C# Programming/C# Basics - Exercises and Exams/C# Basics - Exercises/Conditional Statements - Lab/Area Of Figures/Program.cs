using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Area_Of_Figures
{
    class Program
    {
        static void Main(string[] args)
        {
            string figure = Console.ReadLine();
            double area = 0;

            if (figure == "square")
            {
                double number = double.Parse(Console.ReadLine());
                area = number * number;
            }
            else if (figure == "rectangle")
            {
                double number = double.Parse(Console.ReadLine());
                double number2 = double.Parse(Console.ReadLine());
                area = number * number2;
            }
            else if (figure == "circle")
            {
                double number = double.Parse(Console.ReadLine());
                area = number * number * Math.PI;
            }
            else if (figure == "triangle")
            {
                double number = double.Parse(Console.ReadLine());
                double number2 = double.Parse(Console.ReadLine());
                area = number * number2 / 2;             
            }
            Console.WriteLine("{0:F3}", area);
        }
    }
}
