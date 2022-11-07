using System;
using System.Collections.Generic;
using System.Linq;

namespace ManOWar
{
    class Program
    {
        static void Main(string[] args)
        {

            List<int> pirateShip = Console.ReadLine()
                                          .Split(">", StringSplitOptions.RemoveEmptyEntries)
                                          .Select(int.Parse)
                                          .ToList();
            List<int> warShip = Console.ReadLine()
                                       .Split(">", StringSplitOptions.RemoveEmptyEntries)
                                       .Select(int.Parse)
                                       .ToList();

            int maximumHealth = int.Parse(Console.ReadLine());

            string input = Console.ReadLine();
            string[] command = input.Split();

            while (input != "Retire")
            {

                string cmd = command[0];

                if (cmd == "Fire")
                {

                    int index = int.Parse(command[1]);
                    int damage = int.Parse(command[2]);

                    bool isValid = index >= 0 && index <= warShip.Count - 1;

                    if (isValid)
                    {

                        if (warShip[index] - damage <= 0)
                        {

                            Console.WriteLine("You won! The enemy ship has sunken.");
                            return;

                        }

                        else
                        {

                            warShip[index] -= damage;

                        }

                    }

                }

                else if (cmd == "Defend")
                {

                    int startIndex = int.Parse(command[1]);
                    int endIndex = int.Parse(command[2]);
                    int damage = int.Parse(command[3]);

                    bool isValid = startIndex >= 0 && startIndex <= pirateShip.Count - 1 && endIndex >= 0 && endIndex <= pirateShip.Count - 1;

                    if (isValid)
                    {

                        for (int i = startIndex; i <= endIndex; i++)
                        {

                            if (pirateShip[i] - damage <= 0)
                            {

                                Console.WriteLine("You lost! The pirate ship has sunken.");
                                return;

                            }
                            else
                            {

                                pirateShip[i] -= damage;

                            }

                        }

                    }

                }

                else if (cmd == "Repair")
                {

                    int index = int.Parse(command[1]);
                    int health = int.Parse(command[2]);

                    bool isValid = index >= 0 && index <= pirateShip.Count - 1;

                    if (isValid)
                    {

                        if (pirateShip[index] + health > maximumHealth)
                        {

                            pirateShip[index] = maximumHealth;

                        }

                        else
                        {

                            pirateShip[index] += health;

                        }

                    }
                }

                else if (cmd == "Status")
                {

                    double percentage = 0.2 * maximumHealth;

                    int count = 0;

                    foreach (var item in pirateShip)
                    {

                        if (item < percentage) count++;

                    }

                    Console.WriteLine($"{count} sections need repair.");

                }

                input = Console.ReadLine();
                command = input.Split();

            }

            int pirateSum = 0;

            foreach (var item in pirateShip)
            {

                pirateSum += item;

            }

            int warshipSum = 0;

            foreach (var item in warShip)
            {

                warshipSum += item;

            }

            Console.WriteLine($"Pirate ship status: {pirateSum}");
            Console.WriteLine($"Warship status: {warshipSum}");

        }
    }
}
