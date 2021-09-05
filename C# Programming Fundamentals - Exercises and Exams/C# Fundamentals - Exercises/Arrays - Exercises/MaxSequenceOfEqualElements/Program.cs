using System;

namespace MaxSequenceOfEqualElements
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] array = Console.ReadLine()
                                    .Split();

            int counter = 1;
            int max = 0;
            string elements = " ";        

            for (int i = 0; i < array.Length; i++)
            {

                for (int a = i + 1; a < array.Length; a++)
                {
                    if (array[i] == array[a]) counter++;

                    else
                    {
                        break;
                    }
                }

                if (counter > max)
                {
                    max = counter;
                    elements = array[i];
                }
                counter = 1;
            }

            for (int i = 0; i < max; i++)
            {
                Console.Write(elements + " ");
            }
        }
    }
}
