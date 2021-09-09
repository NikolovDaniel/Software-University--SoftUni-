using System;

namespace VowelsCount
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            int result = PrintVowelsSum(text);

            Console.WriteLine(result);
        }

        static int PrintVowelsSum(string text)
        {
            int vowelsCount = 0;

            for (int i = 0; i < text.Length; i++)
            {

                bool isVowel = text[i] == 'a'
                   || text[i] == 'A'
                   || text[i] == 'e'
                   || text[i] == 'E'
                   || text[i] == 'i'
                   || text[i] == 'I'
                   || text[i] == 'o'
                   || text[i] == 'O'
                   || text[i] == 'u'
                   || text[i] == 'U';


                if (isVowel) vowelsCount++;
            }

            return vowelsCount;
        }
    }
}
