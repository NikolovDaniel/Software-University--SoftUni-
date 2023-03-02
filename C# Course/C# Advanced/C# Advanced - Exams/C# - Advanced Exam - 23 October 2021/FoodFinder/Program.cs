using System;
using System.Collections.Generic;
using System.Linq;

namespace FoodFinder
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] arrVowels = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(char.Parse).ToArray();
            char[] arrConsonants = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(char.Parse).ToArray();

            Queue<char> vowels = new Queue<char>(arrVowels);
            Stack<char> consonants = new Stack<char>(arrConsonants);

            List<char> letters = new List<char>();

            while (consonants.Count > 0)
            {
                if (ContainsConsonant(consonants.Peek()))
                {
                    letters.Add(consonants.Pop());
                }
                else
                {
                    consonants.Pop();
                }
                if (ContainsVowel(vowels.Peek()))
                {
                    char letterToAdd = vowels.Dequeue();
                    if (!letters.Contains(letterToAdd))
                    {
                        letters.Add(letterToAdd);
                    }
                    vowels.Enqueue(letterToAdd);
                }
                else
                {
                    vowels.Enqueue(vowels.Dequeue());
                }


            }

            PrintWordsFound(letters);
        }

        private static void PrintWordsFound(List<char> letters)
        {
            List<string> wordsFound = new List<string>();

            if (ContainsPear(letters))
            {
                wordsFound.Add("pear");
            }
            if (ContainsFlour(letters))
            {
                wordsFound.Add("flour");
            }
            if (ContainsPork(letters))
            {
                wordsFound.Add("pork");
            }
            if(ContainsOlive(letters))
            {
                wordsFound.Add("olive");
            }

            Console.WriteLine($"Words found: {wordsFound.Count}");

            foreach (var item in wordsFound)
            {
                Console.WriteLine(item);
            }
        }
        private static bool ContainsOlive(List<char> letters)
        {
            if (letters.Contains('o'))
            {
                if (letters.Contains('l'))
                {
                    if (letters.Contains('i'))
                    {
                        if (letters.Contains('v'))
                        {
                            if (letters.Contains('e'))
                            {
                                return true;
                            }
                        }
                    }
                }
            }

            return false;
        }
        private static bool ContainsFlour(List<char> letters)
        {
            if (letters.Contains('f'))
            {
                if (letters.Contains('l'))
                {
                    if (letters.Contains('o'))
                    {
                        if (letters.Contains('u'))
                        {
                            if (letters.Contains('r'))
                            {
                                return true;
                            }
                        }
                    }
                }
            }

            return false;
        }
        private static bool ContainsPear(List<char> letters)
        {
            if (letters.Contains('p'))
            {
                if (letters.Contains('e'))
                {
                    if (letters.Contains('a'))
                    {
                        if (letters.Contains('r'))
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }
        private static bool ContainsPork(List<char> letters)
        {
            if (letters.Contains('p'))
            {
                if (letters.Contains('o'))
                {
                    if (letters.Contains('r'))
                    {
                        if (letters.Contains('k'))
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }

        private static bool ContainsVowel(char currVowel)
        {
            string pear = "pear";
            string flour = "flour";
            string pork = "pork";
            string olive = "olive";

            if (pear.Contains(currVowel)) return true;
            if (flour.Contains(currVowel)) return true;
            if (pork.Contains(currVowel)) return true;
            if (olive.Contains(currVowel)) return true;

            return false;
        }

        private static bool ContainsConsonant(char currConsonant)
        {
            string pear = "pear";
            string flour = "flour";
            string pork = "pork";
            string olive = "olive";

            if (pear.Contains(currConsonant)) return true;
            if (flour.Contains(currConsonant)) return true;
            if (pork.Contains(currConsonant)) return true;
            if (olive.Contains(currConsonant)) return true;

            return false;
        }
    }
}
