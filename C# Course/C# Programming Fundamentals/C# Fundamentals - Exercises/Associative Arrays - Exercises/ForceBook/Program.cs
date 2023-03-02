using System;
using System.Collections.Generic;
using System.Linq;

namespace ForceBook
{
    class Program
    {
        static void Main(string[] args)
        {

            Dictionary<string, List<string>> forceUsers = new Dictionary<string, List<string>>();

            string input = Console.ReadLine();

            while (input != "Lumpawaroo")
            {

                if (input.Contains(" | "))
                {
                    string[] commands = input.Split(" | ", StringSplitOptions.RemoveEmptyEntries);

                    string forceSide = commands[0];
                    string forceUser = commands[1];
                    bool isThere = false;

                    foreach (var side in forceUsers)
                    {
                        foreach (var user in side.Value)
                        {
                            if (forceUser == user)
                            {
                                isThere = true;
                                break;
                            }
                        }
                        if (isThere) break;
                    }

                    if (!isThere)
                    {
                        if (forceUsers.ContainsKey(forceSide))
                        {
                            forceUsers[forceSide].Add(forceUser);
                        }
                        else
                        {
                            forceUsers.Add(forceSide, new List<string>() { forceUser });
                        }
                    }



                }
                else if (input.Contains(" -> "))
                {
                    string[] commands = input.Split(" -> ", StringSplitOptions.RemoveEmptyEntries);

                    string forceUser = commands[0];
                    string forceSide = commands[1];
                    bool isThere = false;

                    foreach (var side in forceUsers)
                    {

                        foreach (var user in side.Value)
                        {
                            if (forceUser == user)
                            {
                                isThere = true;
                                forceUsers[side.Key].Remove(forceUser);
                                break;
                            }
                        }
                        if (isThere) break;
                    }

                    if (isThere)
                    {
                        if (forceUsers.ContainsKey(forceSide))
                        {
                            forceUsers[forceSide].Add(forceUser);
                        }
                        else
                        {
                            forceUsers.Add(forceSide, new List<string>() { forceUser });
                        }
                    }
                    else
                    {
                        if (forceUsers.ContainsKey(forceSide))
                        {
                            forceUsers[forceSide].Add(forceUser);
                        }
                        else
                        {
                            forceUsers.Add(forceSide, new List<string>() { forceUser });
                        }
                    }

                    Console.WriteLine($"{forceUser} joins the {forceSide} side!");

                }

                input = Console.ReadLine();

            }

            foreach (var side in forceUsers.OrderByDescending(x => x.Value.Count).ThenBy(x => x.Key).Where(x => x.Value.Count > 0))
            {
                Console.WriteLine($"Side: {side.Key}, Members: {side.Value.Count}");

                foreach (var users in side.Value.OrderBy(x => x))
                {
                    Console.WriteLine($"! {users}");
                }
            }
        }
    }
}
