using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comissions
{
    class Program
    {
        static void Main(string[] args)
        {
            string town = Console.ReadLine();
            double sales = double.Parse(Console.ReadLine());
          
            if (town == "Sofia")
            {
                if ( sales < 0)
                {
                    Console.WriteLine("error");
                }
                else if (sales >= 0 && sales <= 500 )
                {
                    double comission = sales * 0.05;
                    Console.WriteLine($"{comission:f2}");
                }
                else if (sales > 500 && sales <= 1000)
                {
                    double comission = sales * 0.07;
                    Console.WriteLine($"{comission:f2}");
                }
                else if (sales > 1000 && sales <= 10000)
                {
                    double comission = sales * 0.08;
                    Console.WriteLine($"{comission:f2}");
                }
                else if (sales > 10000)
                {
                    double comission = sales * 0.12;
                    Console.WriteLine($"{comission:f2}");
                }
            }
            else if (town == "Varna")
            {
                if (sales < 0)
                {
                    Console.WriteLine("error");
                }
                else if (sales >= 0 && sales <= 500)
                {
                    double comission = sales * 0.045;
                    Console.WriteLine($"{comission:f2}");
                }
                else if (sales > 500 && sales <= 1000)
                {
                    double comission = sales * 0.075;
                    Console.WriteLine($"{comission:f2}");
                }
                else if (sales > 1000 && sales <= 10000)
                {
                    double comission = sales * 0.10;
                    Console.WriteLine($"{comission:f2}");
                }
                else if (sales > 10000)
                {
                    double comission = sales * 0.13;
                    Console.WriteLine($"{comission:f2}");
                }
            }
            else if (town == "Plovdiv")
            {
                if (sales < 0)
                {
                    Console.WriteLine("error");
                }
                else if (sales >= 0 && sales <= 500)
                {
                    double comission = sales * 0.055;
                    Console.WriteLine($"{comission:f2}");
                }
                else if (sales > 500 && sales <= 1000)
                {
                    double comission = sales * 0.08;
                    Console.WriteLine($"{comission:f2}");
                }
                else if (sales > 1000 && sales <= 10000)
                {
                    double comission = sales * 0.12;
                    Console.WriteLine($"{comission:f2}");
                }
                else if (sales > 10000)
                {
                    double comission = sales * 0.145;
                    Console.WriteLine($"{comission:f2}");
                }
            }
             else
            {
                Console.WriteLine("error");
            }
        }
    }
}
