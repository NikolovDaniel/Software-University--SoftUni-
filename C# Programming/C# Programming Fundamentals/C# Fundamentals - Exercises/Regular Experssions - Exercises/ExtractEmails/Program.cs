using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace ExtractEmails
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"\s(?<user>[A-Za-z0-9]+(?:[.\-_][A-Za-z0-9]+)?)@(?<host>[A-Za-z\-]+\.[A-Za-z\-]+(?:\.[A-Za-z\-]+)?)\b";

            Regex regex = new Regex(pattern);

            List<string> validEmails = new List<string>();

            string input = Console.ReadLine();

            MatchCollection emails = regex.Matches(input);

            foreach (Match match in emails)
            {
                validEmails.Add(match.ToString());
            }

            foreach (var email in validEmails)
            {
                Console.WriteLine(email);
            }


        }
    }
}
