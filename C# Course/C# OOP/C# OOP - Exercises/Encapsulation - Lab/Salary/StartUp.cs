using System;
using System.Collections.Generic;
using System.Linq;

namespace Salary
{
    public class StartUp
    {
        static void Main(string[] args)
        {

            int lines = int.Parse(Console.ReadLine());
            List<Person> people = new List<Person>();

            for (int i = 0; i < lines; i++)
            {
                string[] input = Console.ReadLine().Split();

                Person person = new Person(input[0], input[1], int.Parse(input[2]), decimal.Parse(input[3]));

                people.Add(person);
            }

            decimal percentage = decimal.Parse(Console.ReadLine());

            people.ForEach(p => p.IncreaseSalary(percentage));
            people.ForEach(p => Console.WriteLine(p));

        }
    }
}
