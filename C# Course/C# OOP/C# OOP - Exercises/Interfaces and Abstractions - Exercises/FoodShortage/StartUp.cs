using System;
using System.Collections.Generic;
using System.Linq;

namespace FoodShortage
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Citizen> citizenBuyers = new List<Citizen>();
            List<Rebel> rebelBuyers = new List<Rebel>();

            for (int i = 0; i < n; i++)
            {
                string[] people = Console.ReadLine().Split();

                if (people.Length == 4)
                {
                    Citizen citizen = new Citizen(people[0], int.Parse(people[1]), people[2], people[3]);
                    citizenBuyers.Add(citizen);
                }
                else
                {
                    Rebel rebel = new Rebel(people[0], int.Parse(people[1]), people[2]);
                    rebelBuyers.Add(rebel);
                }
            }

            string input = Console.ReadLine();

            while (input != "End")
            {
                foreach (var rebel in rebelBuyers)
                {
                    if (rebel.Name == input) rebel.BuyFood();
                }

                foreach (var citizen in citizenBuyers)
                {
                    if (citizen.Name == input) citizen.BuyFood();
                }

                input = Console.ReadLine();
            }

            Console.WriteLine(citizenBuyers.Sum(x => x.Food) + rebelBuyers.Sum(x => x.Food));
        }
    }
}
