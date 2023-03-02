using System;

namespace LowerOrUpper
{
    class Program
    {
        static void Main(string[] args)
        {
            char input = char.Parse(Console.ReadLine());

            bool upperOrLower = false;

            for (int i = 'A'; i <= 'Z'; i++)
            {
                if (i == input) upperOrLower = true;
            }
            if (upperOrLower) Console.WriteLine("upper-case");
            else Console.WriteLine("lower-case");
        }
    }
}
