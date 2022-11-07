using System;
using System.Text.RegularExpressions;

namespace SantasSecretHelper
{
    class Program
    {
        static void Main(string[] args)
        {
            int key = int.Parse(Console.ReadLine());

            string input = Console.ReadLine();

            string patternName = @"@(?<name>[A-Za-z]+)[^@\-!:>]*!(?<behavior>[GN])!";
            
            while (input != "end")
            {

                string convertedText = string.Empty;

                for (int i = 0; i < input.Length; i++)
                {
                    convertedText += (char)(input[i] - key);
                }

                Match match = Regex.Match(convertedText, patternName);

                string name = match.Groups["name"].Value;
                string behavior = match.Groups["behavior"].Value.ToUpper();

                if (behavior == "G")
                {
                    Console.WriteLine(name);
                }
                
                input = Console.ReadLine();
            }
        }
    }
}
