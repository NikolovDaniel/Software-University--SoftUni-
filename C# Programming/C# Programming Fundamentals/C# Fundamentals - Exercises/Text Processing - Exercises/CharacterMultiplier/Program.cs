using System;

namespace CharacterMultiplier
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] strings = Console.ReadLine().Split();
            string stringOne = strings[0];
            string stringTwo = strings[1];

            Console.WriteLine(CalculateChars(stringOne, stringTwo));

        }

        static int CalculateChars(string stringOne, string stringTwo)
        {

            int totalSum = 0;

            if (stringOne.Length == stringTwo.Length)
            {
                for (int i = 0; i < stringOne.Length; i++)
                {
                    totalSum += stringOne[i] * stringTwo[i];
                }
            }
            else
            {
                for (int i = 0; i < Math.Min(stringOne.Length, stringTwo.Length); i++)
                {
                    totalSum += stringOne[i] * stringTwo[i];
                }

                if (stringOne.Length > stringTwo.Length)
                {
                    for (int i = stringTwo.Length; i < stringOne.Length; i++)
                    {
                        totalSum += stringOne[i];
                    }
                }
                else
                {
                    for (int i = stringOne.Length; i < stringTwo.Length; i++)
                    {
                        totalSum += stringTwo[i];
                    }
                }
            }

            return totalSum;
        }
    }
}


  


