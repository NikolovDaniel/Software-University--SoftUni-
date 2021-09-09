using System;

namespace CharacterInRange
{
    class Program
    {
        static void Main(string[] args)
        {

            char start = char.Parse(Console.ReadLine());
            char end = char.Parse(Console.ReadLine());
            string result = PrintCharsFromStartToEnd(start, end);

            Console.WriteLine(result);

        }

        static string PrintCharsFromStartToEnd(char start, char end)
        {

            string result = "";

            if(start < end)
            {
                for (int i = start + 1; i <= end - 1; i++)
                {
                    result += (char)i + " ";
                }
            }

            else
            {
                for (int i = end + 1; i <= start - 1; i++)
                {
                    result += (char)i + " ";
                }
            }

            return result;

        }
    }
}
