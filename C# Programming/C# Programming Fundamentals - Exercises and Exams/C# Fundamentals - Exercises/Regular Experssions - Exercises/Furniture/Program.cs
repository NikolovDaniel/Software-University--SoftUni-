using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Furniture
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @">>(?<item>[A-Z]+[a-z]+|[A-Z]+[A-Z]+)<<(?<price>[0-9]+[\.]*[0-9]+)!(?<quantity>\d+)";

            Regex regex = new Regex(pattern);

            double totalSum = 0;
            List<string> items = new List<string>();

            string input = Console.ReadLine();

            while (input != "Purchase")
            {

                MatchCollection matches = regex.Matches(input);

                if (regex.IsMatch(input))
                {
                    matches = regex.Matches(input);
                }

                foreach (Match match in matches)
                {
                    int quantity = int.Parse(match.Groups["quantity"].Value);
                    double price = double.Parse(match.Groups["price"].Value);
                    string item = match.Groups["item"].Value;

                    totalSum += price * quantity;
                    items.Add(item);
                }

                input = Console.ReadLine();
            }

            Console.WriteLine("Bought furniture:");

            for (int i = 0; i < items.Count; i++)
            {
                Console.WriteLine(items[i]);
            }

            Console.WriteLine($"Total money spend: {totalSum:f2}");

        }
    }
}
