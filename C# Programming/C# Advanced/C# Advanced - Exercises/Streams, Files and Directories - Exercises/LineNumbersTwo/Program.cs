using System;
using System.IO;
using System.Text.RegularExpressions;

namespace LineNumbersTwo
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines("text.txt");

            for (int i = 0; i < lines.Length; i++)
            {
                string currLine = lines[i];

                int words = CountWords(currLine);
                int punctions = CountPunctions(currLine);

                lines[i] = $"Line {i + 1}: {lines[i]} ({words})({punctions})";
            }

            File.WriteAllLines("output.txt", lines);

        }

        public static int CountPunctions(string line)
        {
            int count = 0;

            for (int i = 0; i < line.Length; i++)
            {
                if (char.IsPunctuation(line[i]))
                {
                    count++;
                }
            }

            return count;
        }
        public static int CountWords(string line)
        {
            int count = 0;

            for (int i = 0; i < line.Length; i++)
            {
                if (char.IsLetter(line[i]))
                {
                    count++;
                }
            }

            return count;
        }
    }
}
