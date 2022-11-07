using System;

namespace GreaterOfTwoValues
{
    class Program
    {
        static void Main(string[] args)
        {
            var type = Console.ReadLine();

            if (type == "int")
            {
                int one = int.Parse(Console.ReadLine());
                int two = int.Parse(Console.ReadLine());

                int max = GetMaxValue(one, two);
                Console.WriteLine(max);
            }
            else if (type == "char")
            {
                char one = char.Parse(Console.ReadLine());
                char two = char.Parse(Console.ReadLine());

                char max = GetMaxValue(one, two);
                Console.WriteLine(max);
            }
            else
            {
                string one = Console.ReadLine();
                string two = Console.ReadLine();

                string max = GetMaxValue(one, two);
                Console.WriteLine(max);
            }
        }

        static int GetMaxValue(int one, int two)
        {
            int max = 0;
            if (one > two)
            {
                max = one;
            }
            else
            {
                max = two;
            }
            return max;
        }

        static char GetMaxValue(char one, char two)
        {
            char max = ' ';

            if (one > two)
            {
                max = one;
            }
            else
            {
                max = two;
            }

            return max;
        }

        static string GetMaxValue(string one, string two)
        {
            string max = "";
            int result = one.CompareTo(two);

            if (result > 0 || result == 0)
            {
                max = one;
            }
            else
            {
                max = two;
            }

            return max;
        }
    }
}
