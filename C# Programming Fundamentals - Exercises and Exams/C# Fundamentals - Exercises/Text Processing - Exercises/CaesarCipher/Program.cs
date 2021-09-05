using System;

namespace CaesarCipher
{
    class Program
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine();
            string result = string.Empty;


            for (int i = 0; i < word.Length; i++)
            {
                int charPlusThree = word[i] + 3;
                char charToAdd = (char)charPlusThree;

                result += charToAdd.ToString();
            }

            Console.WriteLine(result);
        }
    }
}
