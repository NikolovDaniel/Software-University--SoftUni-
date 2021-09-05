using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Football_Souvenirs
{
    class Program
    {
        static void Main(string[] args)
        {
            string team = Console.ReadLine();
            string typeSouvenirs = Console.ReadLine();
            int numSouvenirs = int.Parse(Console.ReadLine());

            double priceSouvenir = 0;
            double totalSum = 0;

            if (team != "Argentina" && team != "Brazil" && team != "Croatia" && team != "Denmark")
            {
                Console.WriteLine("Invalid country!");
            }
            if (typeSouvenirs != "flags" && typeSouvenirs != "caps" && typeSouvenirs != "posters" && typeSouvenirs != "stickers")
            {
                Console.WriteLine("Invalid stock!");
            }
            if (team == "Argentina")
            {
                switch (typeSouvenirs)
                {
                    case "flags":
                        priceSouvenir = 3.25;
                        break;
                    case "caps":
                        priceSouvenir = 7.20;
                        break;
                    case "posters":
                        priceSouvenir = 5.10;
                        break;
                    case "stickers":
                        priceSouvenir = 1.25;
                        break;
                }
            }
            if (team == "Brazil")
            {
                switch (typeSouvenirs)
                {
                    case "flags":
                        priceSouvenir = 4.20;
                        break;
                    case "caps":
                        priceSouvenir = 8.50;
                        break;
                    case "posters":
                        priceSouvenir = 5.35;
                        break;
                    case "stickers":
                        priceSouvenir = 1.20;
                        break;
                }
            }
            if (team == "Croatia")
            {
                switch (typeSouvenirs)
                {
                    case "flags":
                        priceSouvenir = 2.75;
                        break;
                    case "caps":
                        priceSouvenir = 6.90;
                        break;
                    case "posters":
                        priceSouvenir = 4.95;
                        break;
                    case "stickers":
                        priceSouvenir = 1.10;
                        break;
                }
            }
            if (team == "Denmark")
            {
                switch (typeSouvenirs)
                {
                    case "flags":
                        priceSouvenir = 3.10;
                        break;
                    case "caps":
                        priceSouvenir = 6.50;
                        break;
                    case "posters":
                        priceSouvenir = 4.80;
                        break;
                    case "stickers":
                        priceSouvenir = 0.90;
                        break;
                }
            }
            totalSum += priceSouvenir * numSouvenirs;
            if (team == "Argentina" || team == "Brazil" || team == "Croatia" || team == "Denmark")
            {
                if (typeSouvenirs == "caps" || typeSouvenirs == "flags" || typeSouvenirs == "posters" || typeSouvenirs == "stickers")
                {
                    Console.WriteLine($"Pepi bought {numSouvenirs} {typeSouvenirs} of {team} for {totalSum:f2} lv.");
                }
            }
        }
    }
}
 