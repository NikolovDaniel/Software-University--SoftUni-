using System;

namespace EqualArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            //First Array
            string[] itemsArrayOne = Console.ReadLine().Split();
            int[] numbersArrayOne = new int[itemsArrayOne.Length];

            for (int i = 0; i < numbersArrayOne.Length; i++)
            {
                numbersArrayOne[i] = int.Parse(itemsArrayOne[i]);
            }

            //Second Array
            string[] itemsArrayTwo = Console.ReadLine().Split();
            int[] numbersArrayTwo = new int[itemsArrayOne.Length];

            for (int i = 0; i < numbersArrayTwo.Length; i++)
            {
                numbersArrayTwo[i] = int.Parse(itemsArrayTwo[i]);
            }

            //Comparing
            int sum = 0;           
            

            for (int i = 0; i < numbersArrayOne.Length; i++)
            {               
                if (numbersArrayOne[i] == numbersArrayTwo[i]) sum += numbersArrayOne[i];
                if (numbersArrayOne[i] != numbersArrayTwo[i])
                {
                    Console.WriteLine($"Arrays are not identical. Found difference at {i} index");
                    return;
                }              
            }
         
            Console.WriteLine($"Arrays are identical. Sum: {sum}");

        }
    }
}
