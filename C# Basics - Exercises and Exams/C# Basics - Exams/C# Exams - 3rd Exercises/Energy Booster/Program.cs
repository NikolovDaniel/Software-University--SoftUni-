using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Energy_Booster
{
    class Program
    {
        static void Main(string[] args)
        {
            string fruitTaste = Console.ReadLine(); 
            string bigORsmall = Console.ReadLine();
            int numBoosters = int.Parse(Console.ReadLine());

            double smallWatermelon = (56 * 2) * numBoosters;
            double smallMango = (36.66 * 2) * numBoosters;
            double smallPineapple = (42.10 * 2) * numBoosters;
            double smallRaspberry = (20 * 2) * numBoosters;

            double bigWatermelon = (28.70 * 5) * numBoosters;
            double bigMango = (19.60 * 5) * numBoosters;
            double bigPineapple = (24.80 * 5) * numBoosters;
            double bigRaspberry = (15.20 * 5) * numBoosters;

            if (fruitTaste == "Watermelon")
            {
                if (bigORsmall == "small" && smallWatermelon >= 400 && smallWatermelon <= 1000)
                {
                    double discount = smallWatermelon - (smallWatermelon * 0.15);
                    Console.WriteLine($"{discount:f2} lv.");
                }
                else if (bigORsmall == "small" && smallWatermelon > 1000)
                {
                    double discount = smallWatermelon - (smallWatermelon * 0.50);
                    Console.WriteLine($"{discount:f2} lv.");
                }
                else if (bigORsmall == "big" && bigWatermelon >= 400 && bigWatermelon <= 1000)
                {
                    double discount = bigWatermelon - (bigWatermelon * 0.15);
                    Console.WriteLine($"{discount:f2} lv.");
                }
                else if (bigORsmall == "big" && bigWatermelon > 1000)
                {
                    double discount = bigWatermelon - (bigWatermelon * 0.50);
                    Console.WriteLine($"{discount:f2} lv.");
                }
                else if (bigORsmall == "big" && bigWatermelon < 400)
                {
                    Console.WriteLine($"{bigWatermelon:f2} lv.");
                }
                else if (bigORsmall == "small" && smallWatermelon < 400)
                {
                    Console.WriteLine($"{smallWatermelon:f2} lv.");
                }
            }
            else if (fruitTaste == "Mango")
            {
                if (bigORsmall == "small" && smallMango >= 400 && smallMango <= 1000)
                {
                    double discount = smallMango - (smallMango * 0.15);
                    Console.WriteLine($"{discount:f2} lv.");
                }
                else if (bigORsmall == "small" && smallMango > 1000)
                {
                    double discount = smallMango - (smallMango * 0.50);
                    Console.WriteLine($"{discount:f2} lv.");
                }
                else if (bigORsmall == "big" && bigMango >= 400 && bigMango <= 1000)
                {
                    double discount = bigMango - (bigMango * 0.15);
                    Console.WriteLine($"{discount:f2} lv.");
                }
                else if (bigORsmall == "big" && bigMango > 1000)
                {
                    double discount = bigMango - (bigMango * 0.50);
                    Console.WriteLine($"{discount:f2} lv.");
                }
                else if (bigORsmall == "big" && bigMango < 400)
                {
                    Console.WriteLine($"{bigMango:f2} lv.");
                }
                else if (bigORsmall == "small" && smallMango < 400)
                {
                    Console.WriteLine($"{smallMango:f2} lv.");
                }
            }
            else if (fruitTaste == "Pineapple")
            {
                if (bigORsmall == "small" && smallPineapple >= 400 && smallPineapple <= 1000)
                {
                    double discount = smallPineapple - (smallPineapple * 0.15);
                    Console.WriteLine($"{discount:f2} lv.");
                }
                else if (bigORsmall == "small" && smallPineapple > 1000)
                {
                    double discount = smallPineapple - (smallPineapple * 0.50);
                    Console.WriteLine($"{discount:f2} lv.");
                }
                else if (bigORsmall == "big" && bigPineapple >= 400 && bigPineapple <= 1000)
                {
                    double discount = bigPineapple - (bigPineapple * 0.15);
                    Console.WriteLine($"{discount:f2} lv.");
                }
                else if (bigORsmall == "big" && bigPineapple > 1000)
                {
                    double discount = bigPineapple - (bigPineapple * 0.50);
                    Console.WriteLine($"{discount:f2} lv.");
                }
                else if (bigORsmall == "big" && bigPineapple < 400)
                {
                    Console.WriteLine($"{bigPineapple:f2} lv.");
                }
                else if (bigORsmall == "small" && smallPineapple < 400)
                {
                    Console.WriteLine($"{smallPineapple:f2} lv.");
                }
            }
            else if (fruitTaste == "Raspberry")
            {
                if (bigORsmall == "small" && smallRaspberry >= 400 && smallRaspberry <= 1000)
                {
                    double discount = smallRaspberry - (smallRaspberry * 0.15);
                    Console.WriteLine($"{discount:f2} lv.");
                }
                else if (bigORsmall == "small" && smallRaspberry > 1000)
                {
                    double discount = smallRaspberry - (smallRaspberry * 0.50);
                    Console.WriteLine($"{discount:f2} lv.");
                }
                else if (bigORsmall == "big" && bigRaspberry >= 400 && bigRaspberry <= 1000)
                {
                    double discount = bigRaspberry - (bigRaspberry * 0.15);
                    Console.WriteLine($"{discount:f2} lv.");
                }
                else if (bigORsmall == "big" && bigRaspberry > 1000)
                {
                    double discount = bigRaspberry - (bigRaspberry * 0.50);
                    Console.WriteLine($"{discount:f2} lv.");
                }
                else if (bigORsmall == "big" && bigRaspberry < 400)
                {
                    Console.WriteLine($"{bigRaspberry:f2} lv.");
                }
                else if (bigORsmall == "small" && smallRaspberry < 400)
                {
                    Console.WriteLine($"{smallRaspberry:f2} lv.");
                }
            }
        }
    }
}
