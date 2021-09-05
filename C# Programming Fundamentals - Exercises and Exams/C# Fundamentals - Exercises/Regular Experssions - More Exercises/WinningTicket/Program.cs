using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace WinningTicket
{
    class Program
    {
        static void Main(string[] args)
        {

            string[] input = Console.ReadLine().Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);

            string pattern = @"([@]{6,10})|([\^]{6,10})|([$]{6,10})|([#]{6,10})";

            Regex regex = new Regex(pattern);

            for (int i = 0; i < input.Length; i++)
            {

                if (input[i].Length == 20)
                {
                    string leftHalf = input[i].Substring(0, input[i].Length / 2);
                    string rightHalf = input[i].Substring(input[i].Length / 2);

                    var matchOne = regex.Match(leftHalf);
                    var matchTwo = regex.Match(rightHalf);

                    string winningSymbol = string.Empty;

                    if (matchOne.Length >= 6 && matchTwo.Length >= 6)
                    {
                        winningSymbol = matchOne.ToString().Substring(0, 1);
                    }


                    int smallestLength = Math.Min(matchOne.Length, matchTwo.Length);

                    if (smallestLength == 10)
                    {
                        Console.WriteLine($"ticket \"{input[i]}\" - {smallestLength}{winningSymbol} Jackpot!");
                    }
                    else if (smallestLength >= 6 && smallestLength <= 9)
                    {
                        Console.WriteLine($"ticket \"{input[i]}\" - {smallestLength}{winningSymbol}");
                    }
                    else if (matchOne.Length < 6 || matchTwo.Length < 6)
                    {
                        Console.WriteLine($"ticket \"{input[i]}\" - no match");
                    }
                }
                else
                {
                    Console.WriteLine("invalid ticket");
                }
            }
        }
    }
}

