using System;
using System.Collections.Generic;
using System.Linq;

namespace PartyReservationFilderModule
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> names = Console.ReadLine().Split().ToList();

            List<string> filters = new List<string>();

            string[] input = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);

            while (input[0] != "Print")
            {
                if (input[0] == "Add filter")
                {
                    filters.Add($"{input[1]} {input[2]}");
                }
                else if (input[0] == "Remove filter")
                {
                    filters.Remove($"{input[1]} {input[2]}");
                }

                input = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);
            }

            foreach (var filter in filters)
            {
                string[] filt = filter.Split();

                if (filt[0] == "Starts")
                {
                    names = names.Where(p => !p.StartsWith(filt[2])).ToList();
                }
                else if (filt[0] == "Ends")
                {
                    names = names.Where(p => !p.EndsWith(filt[2])).ToList();
                }
                else if (filt[0] == "Length")
                {
                    names = names.Where(p => p.Length != int.Parse(filt[1])).ToList();
                }
                else if (filt[0] == "Contains")
                {
                    names = names.Where(p => !p.Contains(filt[1])).ToList();
                }
            }   

            Console.WriteLine(string.Join(" ", names));
        }
    }
}
