using System;
using System.Collections.Generic;

namespace Tuple
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] firstInput = Console.ReadLine().Split();

            string fullName = $"{firstInput[0]} {firstInput[1]}";
            string adress = firstInput[2];

            string[] secondInput = Console.ReadLine().Split();

            string name = secondInput[0];
            int litersBeer = int.Parse(secondInput[1]);

            string[] thirdInput = Console.ReadLine().Split();

            int integer = int.Parse(thirdInput[0]);
            double numDouble = double.Parse(thirdInput[1]);

            Tuple<string, string> firstTuple = new Tuple<string, string>(fullName, adress);
            Tuple<string, int> secondTuple = new Tuple<string, int>(name, litersBeer);
            Tuple<int, double> thirdTuple = new Tuple<int, double>(integer, numDouble);

            Console.WriteLine(firstTuple);
            Console.WriteLine(secondTuple);
            Console.WriteLine(thirdTuple);
        }
    }
}
