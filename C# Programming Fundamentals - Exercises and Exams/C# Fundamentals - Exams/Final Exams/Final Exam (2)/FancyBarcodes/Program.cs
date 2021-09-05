using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace FancyBarcodes
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"[@][#]{1,}(?<product>[A-Z][A-Za-z0-9]+[A-Z])[@][#]{1,}$";

            string patternNums = @"[0-9]";

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();

                Match products = Regex.Match(input, pattern);

                if (products.Success && products.Groups["product"].Value.Length >= 6)
                {
                    MatchCollection nums = Regex.Matches(products.Groups["product"].Value, patternNums);

                    string barcode = string.Empty;
                    
                    if (nums.Count > 0)
                    {
                        foreach (Match match in nums)
                        {
                            barcode += match.Value;
                        }
                    }
                    else
                    {
                        barcode = "00";
                    }

                    Console.WriteLine($"Product group: {barcode}");
                }
                else
                {
                    Console.WriteLine("Invalid barcode");
                }

            }
        }
    }
}
