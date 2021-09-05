using System;

namespace PasswordGuess
{
    class Program
    {
        static void Main(string[] args)
        {
            //INPUT
            string password = Console.ReadLine();

            //SOLUTION
            if (password == "s3cr3t!P@ssw0rd")
            {
                Console.WriteLine("Welcome");
            }
            else
                Console.WriteLine("Wrong password!");
        }
    }
}
