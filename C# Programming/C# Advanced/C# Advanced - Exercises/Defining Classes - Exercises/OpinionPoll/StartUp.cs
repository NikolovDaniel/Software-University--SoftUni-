using System;
using System.Collections.Generic;
using System.Linq;

namespace OpinionPoll
{
    public class StartUp
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());

            List<Person> listOfPerson = new List<Person>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();

                Person person = new Person()
                {
                    Name = input[0],
                    Age = int.Parse(input[1])
                };

                listOfPerson.Add(person);
            }

            foreach (var person in listOfPerson.Where(p => p.Age > 30).OrderBy(p => p.Name))
            {
                Console.WriteLine($"{person.Name} - {person.Age}");
            }

        }
    }
}
