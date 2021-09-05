using System;

namespace MiddleCharacters
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            string result = PrintMiddleLetters(text);

            Console.WriteLine(result);
        }


        static string PrintMiddleLetters(string text)
        {

            string result = " ";
            int evenOrOdd = text.Length;

            for (int i = 0; i < text.Length; i++)
            {

                if (evenOrOdd % 2 == 1 && i == evenOrOdd / 2)
                {
                    result = text[i].ToString();
                }

                if (evenOrOdd % 2 == 0 && i + 1 == evenOrOdd / 2)
                {
                    result = text[i].ToString() + text[i + 1].ToString();
                }

            }

            return result;

        }
    }
}
