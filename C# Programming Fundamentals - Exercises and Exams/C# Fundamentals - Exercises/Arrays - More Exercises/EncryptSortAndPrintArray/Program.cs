using System;

namespace EncryptSortAndPrintArray
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            string[] names = new string[n];
            int[] arraySum = new int[n];

            for (int i = 0; i < names.Length; i++)
            {
                names[i] = Console.ReadLine();
            }

            for (int i = 0; i < names.Length; i++)
            {
                int sum = 0;
                string name = names[i];

                for (int a = 0; a < name.Length; a++)
                {
                    char letter = name[a];
                    bool vowels = letter == 'a' || letter == 'e' || letter == 'i' || letter == 'o' || letter == 'u' || letter == 'A' || letter == 'E' || letter == 'I' || letter == 'O' || letter == 'U';
                    if (vowels) sum += letter * name.Length;
                    else sum += letter / name.Length;                 
                }
                arraySum[i] = sum;               
            }

            Array.Sort(arraySum);

            for (int i = 0; i < arraySum.Length; i++)
            {
                Console.WriteLine(arraySum[i]);
            }
        }
    }
}
