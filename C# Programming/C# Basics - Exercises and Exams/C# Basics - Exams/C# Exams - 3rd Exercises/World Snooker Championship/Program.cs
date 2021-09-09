using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace World_Snooker_Championship
{
    class Program
    {
        static void Main(string[] args)
        {
            string round = Console.ReadLine();
            string nameTicket = Console.ReadLine();
            int numTicket = int.Parse(Console.ReadLine());
            char output = Console.ReadLine()[0];

            double QuarterFinalS = numTicket * 55.50;
            double QuarterFinalP = numTicket * 105.20;
            double QuarterFinalV = numTicket * 118.90;

            double SemiFinalS = numTicket * 75.88;
            double SemiFinalP = numTicket * 125.22;
            double SemiFinalV = numTicket * 300.40;

            double FinalS = numTicket * 110.10;
            double FinalP = numTicket * 160.66;
            double FinalV = numTicket * 400;


            if (output == 'Y' && round == "Quarter final")
            {
                if (nameTicket == "Standard" && QuarterFinalS < 2500)
                {
                    double photos = numTicket * 40;
                    double finalPrice = QuarterFinalS + photos;
                    Console.WriteLine($"{finalPrice:f2}");
                }
                else if (nameTicket == "Standard" && QuarterFinalS <= 4000)
                {
                    double photos = numTicket * 40;
                    double discount = QuarterFinalS - (QuarterFinalS * 0.10);
                    double finalPrice = photos + discount;
                    Console.WriteLine($"{finalPrice:f2}");
                }
                else if (nameTicket == "Standard" && QuarterFinalS > 4000)
                {
                    double discount = QuarterFinalS - (QuarterFinalS * 0.25);
                    Console.WriteLine($"{discount:f2}");
                }
                else if (nameTicket == "Premium" && QuarterFinalP < 2500)
                {
                    double photos = numTicket * 40;
                    double finalPrice = QuarterFinalP + photos;
                    Console.WriteLine($"{finalPrice:f2}");
                }
                else if (nameTicket == "Premium" && QuarterFinalP <= 4000)
                {
                    double photos = numTicket * 40;
                    double discount = QuarterFinalP - (QuarterFinalP * 0.10);
                    double finalPrice = photos + discount;
                    Console.WriteLine($"{finalPrice:f2}");
                }
                else if (nameTicket == "Premium" && QuarterFinalP > 4000)
                {
                    double discount = QuarterFinalP - (QuarterFinalP * 0.25);
                    Console.WriteLine($"{discount:f2}");
                }
                else if (nameTicket == "VIP" && QuarterFinalV < 2500)
                {
                    double photos = numTicket * 40;
                    double finalPrice = QuarterFinalV + photos;
                    Console.WriteLine($"{finalPrice:f2}");
                }
                else if (nameTicket == "VIP" && QuarterFinalV <= 4000)
                {
                    double photos = numTicket * 40;
                    double discount = QuarterFinalV - (QuarterFinalV * 0.10);
                    double finalPrice = photos + discount;
                    Console.WriteLine($"{finalPrice:f2}");
                }
                else if (nameTicket == "VIP" && QuarterFinalV > 4000)
                {
                    double discount = QuarterFinalV - (QuarterFinalV * 0.25);
                    Console.WriteLine($"{discount:f2}");
                }
            }
            else if (output == 'N' && round == "Quarter final")
            {
                if (nameTicket == "Standard" && QuarterFinalS < 2500)
                {
                    Console.WriteLine($"{QuarterFinalS:f2}");
                }
                else if (nameTicket == "Standard" && QuarterFinalS <= 4000)
                {
                    double discount = QuarterFinalS - (QuarterFinalS * 0.10);
                    Console.WriteLine($"{discount:f2}");
                }
                else if (nameTicket == "Standard" && QuarterFinalS > 4000)
                {
                    double discount = QuarterFinalS - (QuarterFinalS * 0.25);
                    Console.WriteLine($"{discount:f2}");
                }
                else if (nameTicket == "Premium" && QuarterFinalP < 2500)
                {
                    Console.WriteLine($"{QuarterFinalP:f2}");
                }
                else if (nameTicket == "Premium" && QuarterFinalP <= 4000)
                {
                    double discount = QuarterFinalP - (QuarterFinalP * 0.10);
                    Console.WriteLine($"{discount:f2}");
                }
                else if (nameTicket == "Premium" && QuarterFinalP > 4000)
                {
                    double discount = QuarterFinalP - (QuarterFinalP * 0.25);
                    Console.WriteLine($"{discount:f2}");
                }
                else if (nameTicket == "VIP" && QuarterFinalV < 2500)
                {
                    Console.WriteLine($"{QuarterFinalV:f2}");
                }
                else if (nameTicket == "VIP" && QuarterFinalV <= 4000)
                {
                    double discount = QuarterFinalV - (QuarterFinalV * 0.10);
                    Console.WriteLine($"{discount:f2}");
                }
                else if (nameTicket == "VIP" && QuarterFinalV > 4000)
                {
                    double discount = QuarterFinalV - (QuarterFinalV * 0.25);
                    Console.WriteLine($"{discount:f2}");
                }
            }
            else if (output == 'Y' && round == "Semi final")
            {
                if (nameTicket == "Standard" && SemiFinalS < 2500)
                {
                    double photos = numTicket * 40;
                    double finalPrice = SemiFinalS + photos;
                    Console.WriteLine($"{finalPrice:f2}");
                }
                else if (nameTicket == "Standard" && SemiFinalS <= 4000)
                {
                    double photos = numTicket * 40;
                    double discount = SemiFinalS - (SemiFinalS * 0.10);
                    double finalPrice = photos + discount;
                    Console.WriteLine($"{finalPrice:f2}");
                }
                else if (nameTicket == "Standard" && SemiFinalS > 4000)
                {
                    double discount = SemiFinalS - (SemiFinalS * 0.25);
                    Console.WriteLine($"{discount:f2}");
                }
                else if (nameTicket == "Premium" && SemiFinalP < 2500)
                {
                    double photos = numTicket * 40;
                    double finalPrice = SemiFinalP + photos;
                    Console.WriteLine($"{finalPrice:f2}");
                }
                else if (nameTicket == "Premium" && SemiFinalP <= 4000)
                {
                    double photos = numTicket * 40;
                    double discount = SemiFinalP - (SemiFinalP * 0.10);
                    double finalPrice = photos + discount;
                    Console.WriteLine($"{finalPrice:f2}");
                }
                else if (nameTicket == "Premium" && SemiFinalP > 4000)
                {
                    double discount = SemiFinalP - (SemiFinalP * 0.25);
                    Console.WriteLine($"{discount:f2}");
                }
                else if (nameTicket == "VIP" && SemiFinalV < 2500)
                {
                    double photos = numTicket * 40;
                    double finalPrice = SemiFinalV + photos;
                    Console.WriteLine($"{finalPrice:f2}");
                }
                else if (nameTicket == "VIP" && SemiFinalV <= 4000)
                {
                    double photos = numTicket * 40;
                    double discount = SemiFinalV - (SemiFinalV * 0.10);
                    double finalPrice = photos + discount;
                    Console.WriteLine($"{finalPrice:f2}");
                }
                else if (nameTicket == "VIP" && SemiFinalV > 4000)
                {
                    double discount = SemiFinalV - (SemiFinalV * 0.25);
                    Console.WriteLine($"{discount:f2}");
                }
            }
            else if (output == 'N' && round == "Semi final")
            {
                if (nameTicket == "Standard" && SemiFinalS < 2500)
                {
                    Console.WriteLine($"{SemiFinalS:f2}");
                }
                else if (nameTicket == "Standard" && SemiFinalS <= 4000)
                {
                    double discount = SemiFinalS - (SemiFinalS * 0.10);
                    Console.WriteLine($"{discount:f2}");
                }
                else if (nameTicket == "Standard" && SemiFinalS > 4000)
                {
                    double discount = SemiFinalS - (SemiFinalS * 0.25);
                    Console.WriteLine($"{discount:f2}");
                }
                else if (nameTicket == "Premium" && SemiFinalP < 2500)
                {
                    Console.WriteLine($"{SemiFinalP:f2}");
                }
                else if (nameTicket == "Premium" && SemiFinalP <= 4000)
                {
                    double discount = SemiFinalP - (SemiFinalP * 0.10);
                    Console.WriteLine($"{discount:f2}");
                }
                else if (nameTicket == "Premium" && SemiFinalP > 4000)
                {
                    double discount = SemiFinalP - (SemiFinalP * 0.25);
                    Console.WriteLine($"{discount:f2}");
                }
                else if (nameTicket == "VIP" && SemiFinalV < 2500)
                {
                    Console.WriteLine($"{SemiFinalV:f2}");
                }
                else if (nameTicket == "VIP" && SemiFinalV <= 4000)
                {
                    double discount = SemiFinalV - (SemiFinalV * 0.10);
                    Console.WriteLine($"{discount:f2}");
                }
                else if (nameTicket == "VIP" && SemiFinalV > 4000)
                {
                    double discount = SemiFinalV - (SemiFinalV * 0.25);
                    Console.WriteLine($"{discount:f2}");
                }
            }
            else if (output == 'Y' && round == "Final")
            {
                if (nameTicket == "Standard" && FinalS < 2500)
                {
                    double photos = numTicket * 40;
                    double finalPrice = FinalS + photos;
                    Console.WriteLine($"{finalPrice:f2}");
                }
                else if (nameTicket == "Standard" && FinalS <= 4000)
                {
                    double photos = numTicket * 40;
                    double discount = FinalS - (FinalS * 0.10);
                    double finalPrice = photos + discount;
                    Console.WriteLine($"{finalPrice:f2}");
                }
                else if (nameTicket == "Standard" && FinalS > 4000)
                {
                    double discount = FinalS - (FinalS * 0.25);
                    Console.WriteLine($"{discount:f2}");
                }
                else if (nameTicket == "Premium" && FinalP < 2500)
                {
                    double photos = numTicket * 40;
                    double finalPrice = FinalP + photos;
                    Console.WriteLine($"{finalPrice:f2}");
                }
                else if (nameTicket == "Premium" && FinalP <= 4000)
                {
                    double photos = numTicket * 40;
                    double discount = FinalP - (FinalP * 0.10);
                    double finalPrice = photos + discount;
                    Console.WriteLine($"{finalPrice:f2}");
                }
                else if (nameTicket == "Premium" && FinalP > 4000)
                {
                    double discount = FinalP - (FinalP * 0.25);
                    Console.WriteLine($"{discount:f2}");
                }
                else if (nameTicket == "VIP" && FinalV < 2500)
                {
                    double photos = numTicket * 40;
                    double finalPrice = FinalV + photos;
                    Console.WriteLine($"{finalPrice:f2}");
                }
                else if (nameTicket == "VIP" && FinalV <= 4000)
                {
                    double photos = numTicket * 40;
                    double discount = FinalV - (FinalV * 0.10);
                    double finalPrice = photos + discount;
                    Console.WriteLine($"{finalPrice:f2}");
                }
                else if (nameTicket == "VIP" && FinalV > 4000)
                {
                    double discount = FinalV - (FinalV * 0.25);
                    Console.WriteLine($"{discount:f2}");
                }
            }
            else if (output == 'N' && round == "Final")
            {
                if (nameTicket == "Standard" && FinalS < 2500)
                {
                    Console.WriteLine($"{FinalS:f2}");
                }
                else if (nameTicket == "Standard" && FinalS <= 4000)
                {
                    double discount = FinalS - (FinalS * 0.10);
                    Console.WriteLine($"{discount:f2}");
                }
                else if (nameTicket == "Standard" && FinalS > 4000)
                {
                    double discount = FinalS - (FinalS * 0.25);
                    Console.WriteLine($"{discount:f2}");
                }
                else if (nameTicket == "Premium" && FinalP < 2500)
                {
                    Console.WriteLine($"{FinalP:f2}");
                }
                else if (nameTicket == "Premium" && FinalP <= 4000)
                {
                    double discount = FinalP - (FinalP * 0.10);
                    Console.WriteLine($"{discount:f2}");
                }
                else if (nameTicket == "Premium" && FinalP > 4000)
                {
                    double discount = FinalP - (FinalP * 0.25);
                    Console.WriteLine($"{discount:f2}");
                }
                else if (nameTicket == "VIP" && FinalV < 2500)
                {
                    Console.WriteLine($"{FinalV:f2}");
                }
                else if (nameTicket == "VIP" && FinalV <= 4000)
                {
                    double discount = FinalV - (FinalV * 0.10);
                    Console.WriteLine($"{discount:f2}");
                }
                else if (nameTicket == "VIP" && FinalV > 4000)
                {
                    double discount = FinalV - (FinalV * 0.25);
                    Console.WriteLine($"{discount:f2}");
                }
            }
        }
    }
}
