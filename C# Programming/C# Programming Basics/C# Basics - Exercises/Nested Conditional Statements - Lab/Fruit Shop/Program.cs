using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fruit_Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            string fruit = Console.ReadLine();
            string day = Console.ReadLine();
            double quantity = double.Parse(Console.ReadLine());

            if (day == "Monday" || day == "Tuesday" || day == "Wednesday" || day == "Thursday" || day == "Friday")
            {
                if (fruit == "banana")
                {
                    double fruitPrice = quantity * 2.50;
                    Console.WriteLine($"{fruitPrice:f2}");
                }
                else if (fruit == "apple")
                {
                    double fruitPrice = quantity * 1.20;
                    Console.WriteLine($"{fruitPrice:f2}");
                }
                else if (fruit == "orange")
                {
                    double fruitPrice = quantity * 0.85;
                    Console.WriteLine($"{fruitPrice:f2}");
                }
                else if (fruit == "grapefruit")
                {
                    double fruitPrice = quantity * 1.45;
                    Console.WriteLine($"{fruitPrice:f2}");
                }
                else if (fruit == "kiwi")
                {
                    double fruitPrice = quantity * 2.70;
                    Console.WriteLine($"{fruitPrice:f2}");
                }
                else if (fruit == "pineapple")
                {
                    double fruitPrice = quantity * 5.50;
                    Console.WriteLine($"{fruitPrice:f2}");
                }
                else if (fruit == "grapes")
                {
                    double fruitPrice = quantity * 3.85;
                    Console.WriteLine($"{fruitPrice:f2}");
                }
                else
                {
                    Console.WriteLine("error");
                }
            }
            else if (day == "Saturday" || day == "Sunday")
            {
                if (fruit == "banana")
                {
                    double fruitPrice = quantity * 2.70;
                    Console.WriteLine($"{fruitPrice:f2}");
                }
                else if (fruit == "apple")
                {
                    double fruitPrice = quantity * 1.25;
                    Console.WriteLine($"{fruitPrice:f2}");
                }
                else if (fruit == "orange")
                {
                    double fruitPrice = quantity * 0.90;
                    Console.WriteLine($"{fruitPrice:f2}");
                }
                else if (fruit == "grapefruit")
                {
                    double fruitPrice = quantity * 1.60;
                    Console.WriteLine($"{fruitPrice:f2}");
                }
                else if (fruit == "kiwi")
                {
                    double fruitPrice = quantity * 3.00;
                    Console.WriteLine($"{fruitPrice:f2}");
                }
                else if (fruit == "pineapple")
                {
                    double fruitPrice = quantity * 5.60;
                    Console.WriteLine($"{fruitPrice:f2}");
                }
                else if (fruit == "grapes")
                {
                    double fruitPrice = quantity * 4.20;
                    Console.WriteLine($"{fruitPrice:f2}");
                }
                else
                {
                    Console.WriteLine("error");
                }
            }
            else
            {
                Console.WriteLine("error");
            }
        }
    }
}
           