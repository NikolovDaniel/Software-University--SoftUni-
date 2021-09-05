using System;

namespace IntegerOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            int numOne = int.Parse(Console.ReadLine());
            int numTwo = int.Parse(Console.ReadLine());
            int numThree = int.Parse(Console.ReadLine());
            int numFour = int.Parse(Console.ReadLine());

            int sum = numOne + numTwo;
            sum /= numThree;
            sum *= numFour;

            Console.WriteLine(sum);
        }
    }
}
