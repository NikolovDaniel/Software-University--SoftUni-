using System;

namespace Threeuple
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string nameOne = $"{input[0]} {input[1]}";
            string adress = input[2];
            string town = input[3];

            input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string nameTwo = input[0];
            int litersOfBeer = int.Parse(input[1]);
            bool drunkOrNot = input[2].Equals("drunk");

            input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string nameThree = input[0];
            double accountBalance = double.Parse(input[1]);
            string bankName = input[2];

            Tuple<string, string, string> firstPerson = new Tuple<string, string, string>(nameOne, adress, town);
            Tuple<string, int, bool> secondPerson = new Tuple<string, int, bool>(nameTwo, litersOfBeer, drunkOrNot);
            Tuple<string, double, string> ThirdPerson = new Tuple<string, double, string>(nameThree, accountBalance, bankName);

            Console.WriteLine(firstPerson);
            Console.WriteLine(secondPerson);
            Console.WriteLine(ThirdPerson);

        }
    }
}
