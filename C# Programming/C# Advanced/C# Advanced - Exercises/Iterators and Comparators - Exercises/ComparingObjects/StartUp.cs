using System;
using System.Collections.Generic;

namespace ComparingObjects
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Person> listOfPerson = new List<Person>();

            string input = Console.ReadLine();

            while (input != "END")
            {
                string[] tokens = input.Split();

                string name = tokens[0];
                int age = int.Parse(tokens[1]);
                string town = tokens[2];

                Person person = new Person(name, age, town);

                listOfPerson.Add(person);

                input = Console.ReadLine();
            }

            int index = int.Parse(Console.ReadLine()) - 1;

            if (index < 0 || index > listOfPerson.Count - 1)
            {
                Console.WriteLine("No matches");
                return;
            }
            
            int equal = 0;
            int nonEqual = 0;

            foreach (var person in listOfPerson)
            {
                if (person.CompareTo(listOfPerson[index]) == 0)
                {
                    equal++;
                }
                else
                {
                    nonEqual++;
                }            
            }

            if (equal > 1)
            {
                Console.WriteLine($"{equal} {nonEqual} {listOfPerson.Count}");
            }
            else
            {
                Console.WriteLine("No matches");
            }
        }
    }
}
