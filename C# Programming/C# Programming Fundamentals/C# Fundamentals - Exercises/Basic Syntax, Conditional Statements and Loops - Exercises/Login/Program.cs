using System;
using System.Linq;

namespace Login
{
    class Program
    {
        static void Main(string[] args)
        {
            string username = Console.ReadLine();

            char[] reversedPassword = username.Reverse().ToArray();

            string key = string.Empty;

            for (int i = 0; i < reversedPassword.Length; i++)
            {
                key += reversedPassword[i];
            }

            string input = Console.ReadLine();
            int counter = 0;
            while (key != input)
            {
                counter++;
                if (counter == 4)
                {
                    break;
                }
                Console.WriteLine("Incorrect password. Try again.");
                input = Console.ReadLine();
            }

            if (counter == 4)
            {
                Console.WriteLine($"User {username} blocked!");
            }
            else Console.WriteLine($"User {username} logged in.");
        }
    }
}
