using System;

namespace ComputerStore
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            double sum = 0;


            while (input != "special" && input != "regular")
            {

                double price = 0;
                double.TryParse(input, out price);

                if (price < 0) Console.WriteLine("Invalid price!");
                else sum += price;

                input = Console.ReadLine();

            }

            double taxes = 0;

            if(sum == 0)
            {
                Console.WriteLine("Invalid order!");
            }
            else if (input == "regular")
            {
                taxes = 0.2 * sum;

                Console.WriteLine("Congratulations you've just bought a new computer!");
                Console.WriteLine($"Price without taxes: {sum:f2}$");
                Console.WriteLine($"Taxes: {taxes:f2}$");
                Console.WriteLine("-----------");
                Console.WriteLine($"Total price: {taxes + sum:f2}$");
            }
            else if (input == "special")
            {
                taxes = 0.2 * sum;

                Console.WriteLine("Congratulations you've just bought a new computer!");
                Console.WriteLine($"Price without taxes: {sum:f2}$");
                Console.WriteLine($"Taxes: {taxes:f2}$");
                Console.WriteLine("-----------");
                double finalSum = (taxes + sum) - ((taxes + sum) * 0.1);
                Console.WriteLine($"Total price: {finalSum:f2}$");
            }

        }
    }
}
