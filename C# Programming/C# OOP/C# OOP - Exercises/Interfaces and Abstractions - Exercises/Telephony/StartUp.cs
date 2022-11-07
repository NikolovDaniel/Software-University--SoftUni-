using System;

namespace Telephony
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] numbers = Console.ReadLine().Split();
            string[] websites = Console.ReadLine().Split();

            Smartphone smartphone = new Smartphone();

            for (int i = 0; i < numbers.Length; i++)
            {
                smartphone.Call(numbers[i]);
            }

            for (int i = 0; i < websites.Length; i++)
            {
                smartphone.Browse(websites[i]);
            }
        }
    }
}
