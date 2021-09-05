using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace SoftUniBarIncome
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"%(?<name>[A-Z][a-z]+)%[^|$%.]*<(?<product>\w+)>[^|$%.]*\|(?<quantity>\d+)[^|$%.]*\|[^|$%.0-9]*?(?<price>[0-9][0-9]*\.*[0-9]*)\$";

            Regex regex = new Regex(pattern);
            double totalSum = 0;

            string input = Console.ReadLine();

            while (input != "end of shift")
            {
                
                MatchCollection matches = regex.Matches(input);

                if (regex.IsMatch(input))
                {
                    Match match = regex.Match(input);
                    var name = match.Groups["name"].Value;
                    int quantity = int.Parse(match.Groups["quantity"].Value);
                    double price = double.Parse(match.Groups["price"].Value);
                    string product = match.Groups["product"].Value;

                    totalSum += price * quantity;
                    Console.WriteLine($"{name}: {product} - {quantity * price:f2}");
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"Total income: {totalSum:f2}");

        }
    }
}
