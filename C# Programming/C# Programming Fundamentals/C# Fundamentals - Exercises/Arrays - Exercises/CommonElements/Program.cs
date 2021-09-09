using System;

namespace CommonElements
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] arrayOne = Console.ReadLine().Split();
            string[] arrayTwo = Console.ReadLine().Split();

            string result = "";

            for (int i = 0; i < arrayTwo.Length; i++)
            {
                for (int a = 0; a < arrayOne.Length; a++)
                {
                    if (arrayTwo[i] == arrayOne[a]) result += arrayOne[a] + " ";
                }
            }

            Console.WriteLine(result);
        }
    }
}
