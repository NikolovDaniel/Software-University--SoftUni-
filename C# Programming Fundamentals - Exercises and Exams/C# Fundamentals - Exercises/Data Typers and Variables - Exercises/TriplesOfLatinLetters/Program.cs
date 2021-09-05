using System;

namespace TriplesOfLatinLetters
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            n += 97;

            for (int a = 97; a < n; a++)
            {
                for (int b = 97; b < n; b++)
                {
                    for (int c = 97; c < n; c++)
                    {
                        char one = (char)a;
                        char two = (char)b;
                        char three = (char)c;
                        Console.WriteLine($"{one}{two}{three}");
                    }
                }
            }
        }
    }
}
