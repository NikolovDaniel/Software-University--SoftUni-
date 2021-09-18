using System;
using System.Collections.Generic;

namespace SoftUniParty
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> guests = new HashSet<string>();
            HashSet<string> vipGuests = new HashSet<string>();

            string input = Console.ReadLine();

            while (input != "PARTY")
            {
                int num = 0;
                bool isVip = int.TryParse(input[0].ToString(), out num);

                if (isVip)
                {
                    vipGuests.Add(input);
                }
                else
                {
                    guests.Add(input);
                }
                input = Console.ReadLine();
            }

            input = Console.ReadLine();

            while (input != "END")
            {
                if (guests.Contains(input))
                {
                    guests.Remove(input);
                }
                else
                {
                    vipGuests.Remove(input);
                }

                input = Console.ReadLine();
            }

            Console.WriteLine(guests.Count + vipGuests.Count);

            foreach (var guest in vipGuests)
            {
                Console.WriteLine(guest);
            }
            foreach (var guest in guests)
            {
                Console.WriteLine(guest);
            }
        }
    }
}
