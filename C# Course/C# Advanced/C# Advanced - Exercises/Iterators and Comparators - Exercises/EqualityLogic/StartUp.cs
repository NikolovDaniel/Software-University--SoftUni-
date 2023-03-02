using System;
using System.Collections.Generic;

namespace EqualityLogic
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            SortedSet<(string name, int age)> sortedPerson = new SortedSet<(string name, int age)>();
            HashSet<Person> hashPerson = new HashSet<Person>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();

                string name = input[0];
                int age = int.Parse(input[1]);

                Person person = new Person(name, age);

                bool isEqual = false;
                
                foreach (var item in hashPerson)
                {
                    if (item.Equals(person))
                    {
                        isEqual = true;
                        break;
                    }
                }

                if (!isEqual)
                {
                    hashPerson.Add(person);
                }

                isEqual = false;

                foreach (var item in sortedPerson)
                {
                    if (item.name.Equals(person.Name) && item.age.Equals(person.Age))
                    {
                        isEqual = true;
                        break;
                    }
                }

                if (!isEqual)
                {
                    sortedPerson.Add((person.Name, person.Age));
                }

            }
            Console.WriteLine(sortedPerson.Count);
            Console.WriteLine(hashPerson.Count);
        }
    }
}
