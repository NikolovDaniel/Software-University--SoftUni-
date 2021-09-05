using System;
using System.Collections.Generic;

namespace HouseParty
{
    class Program
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());

            List<string> guests = new List<string>(n);

            bool isThere = false;

            for (int i = 0; i < n; i++)
            {

                string[] guest = Console.ReadLine().Split();

                if (guest.Length == 3)
                {

                    for (int a = 0; a < guests.Count; a++)
                    {
                        if (guests[a] == guest[0]) isThere = true;                        
                    }
                    if (isThere) Console.WriteLine($"{guest[0]} is already in the list!");
                    else guests.Add(guest[0]);

                }

                else if (guest.Length == 4)
                {

                    for (int a = 0; a < guests.Count; a++)
                    {
                        if (guests[a] == guest[0]) isThere = true;
                    }
                    if (isThere) guests.Remove(guest[0]);
                    else Console.WriteLine($"{guest[0]} is not in the list!");

                }

                isThere = false;
            }

            for (int i = 0; i < guests.Count; i++)
            {
                Console.WriteLine(guests[i]);
            }
        }
    }
}
