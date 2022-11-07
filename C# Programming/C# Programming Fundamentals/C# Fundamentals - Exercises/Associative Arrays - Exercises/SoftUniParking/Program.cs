using System;
using System.Collections.Generic;

namespace SoftUniParking
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, string> registeredUsers = new Dictionary<string, string>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();
                string user = string.Empty;
                string plate = string.Empty;

                if (input[0] == "register")
                {
                    user = input[1];
                    plate = input[2];
                }
                else user = input[1];
                

                if (input[0] == "register")
                {
                    if (registeredUsers.ContainsKey(user))
                    {
                        Console.WriteLine($"ERROR: already registered with plate number {registeredUsers[user]}");
                    }
                    else
                    {
                        registeredUsers.Add(user, plate);
                        Console.WriteLine($"{user} registered {plate} successfully ");
                    }
                }
                else
                {
                    if (registeredUsers.ContainsKey(user))
                    {
                        registeredUsers.Remove(user);
                        Console.WriteLine($"{user} unregistered successfully");
                    }
                    else
                    {
                        Console.WriteLine($"ERROR: user {user} not found");
                    }
                }
            }

            foreach (var item in registeredUsers)
            {
                Console.WriteLine($"{item.Key} => {item.Value}");
            }
        }
    }
}
