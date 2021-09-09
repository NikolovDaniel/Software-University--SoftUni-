using System;
using System.Text;

namespace RepeatString
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            int repeatNumber = int.Parse(Console.ReadLine());

            PrintTextXNumber(text, repeatNumber);          
        }

        static void PrintTextXNumber(string text, int number)
        {

            StringBuilder result = new StringBuilder();

            for (int i = 0; i < number; i++)
            {
                result.Append(text);
            }

            Console.WriteLine(result);

        }
    }
}
