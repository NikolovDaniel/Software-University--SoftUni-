using System;
using System.Text.RegularExpressions;

namespace MatchPhoneNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"\+359([ ]|[\-])2\1\b\d{3}\b\1\b\d{4}\b";

            var regex = new Regex(pattern);

            string input = Console.ReadLine();

            MatchCollection matches = regex.Matches(input);

            Console.WriteLine(string.Join(", ", matches));
        }
    }
}
