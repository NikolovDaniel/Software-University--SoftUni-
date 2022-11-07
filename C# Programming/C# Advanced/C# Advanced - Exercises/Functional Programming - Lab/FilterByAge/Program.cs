using System;
using System.Collections.Generic;
using System.Linq;

namespace FilterByAge
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<(string name, int age), int, bool> younger = (person, age) => person.age < age; 
            Func<(string name, int age), int, bool> older = (person, age) => person.age >= age;

            List<(string name, int age)> people = new List<(string name, int age)>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] person = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);

                people.Add((person[0], int.Parse(person[1])));
            }

            string olderOrYounger = Console.ReadLine();
            int ageFilter = int.Parse(Console.ReadLine());
            string[] filter = Console.ReadLine().Split();

            switch (olderOrYounger)
            {
                case "younger":
                    people = people
                        .Where(p => younger(p, ageFilter))
                        .ToList();
                    break;
                case "older":
                    people = people
                       .Where(p => older(p, ageFilter))
                       .ToList();
                    break;
            }

            foreach (var pers in people)
            {
                if (filter.Contains("name") && filter.Contains("age"))
                {
                    Console.WriteLine($"{pers.name} - {pers.age}");
                }
                else if (filter.Contains("name"))
                {
                    Console.WriteLine($"{pers.name}");
                }
                else
                {
                    Console.WriteLine($"{pers.age}");
                }
            }
        }
    }
}
