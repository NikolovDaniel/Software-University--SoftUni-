using System;
using System.Collections.Generic;
using System.Linq;

namespace BirthdayCelebrations
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            List<IBirthables> creatures = new List<IBirthables>();

            while (input != "End")
            {
                if (input.Contains("Citizen"))
                {
                    IBirthables citizen = CreateCitizen(input.Split());
                    creatures.Add(citizen);
                }
                else if (input.Contains("Robot"))
                {
                    Robot robot = CreateRobot(input.Split());
                }
                else if (input.Contains("Pet"))
                {
                    IBirthables pet = CreatePet(input.Split());
                    creatures.Add(pet);
                }

                input = Console.ReadLine();
            }

            string year = Console.ReadLine();

            if (creatures.Where(x => x.Birthdate.EndsWith(year)).ToList().Count > 0)
            {
                foreach (var item in creatures.Where(x => x.Birthdate.EndsWith(year)))
                {
                    string[] birthdate = item.Birthdate.Split(new char[] { ' ', '.', '/', '-' });

                    Console.WriteLine($"{birthdate[0]}/{birthdate[1]}/{birthdate[2]}");
                }
            }
        }

        private static Citizen CreateCitizen(string[] tokens)
        {
            return new Citizen(tokens[1], int.Parse(tokens[2]), tokens[3], tokens[4]);
        }
        private static Robot CreateRobot(string[] tokens)
        {
            return new Robot(tokens[1], tokens[2]);
        }
        private static Pet CreatePet(string[] tokens)
        {
            return new Pet(tokens[1], tokens[2]);
        }
    }
}
