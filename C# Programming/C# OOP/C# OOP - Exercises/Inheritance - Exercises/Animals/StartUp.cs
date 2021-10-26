using System;
using System.Collections.Generic;

namespace Animals
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Animal> animals = new List<Animal>();

            while (true)
            {
                string className = Console.ReadLine();

                if (className == "Beast!") break;

                string input = Console.ReadLine();

                string[] tokens = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string name = tokens[0];
                int age = int.Parse(tokens[1]);
                string gender = tokens[2];

                switch (className)
                {
                    case "Dog":
                        Dog dog = new Dog(name, age, gender);
                        animals.Add(dog);
                        break;
                    case "Frog":
                        Frog frog = new Frog(name, age, gender);
                        animals.Add(frog);
                        break;
                    case "Cat":
                        Cat cat = new Cat(name, age, gender);
                        animals.Add(cat);
                        break;
                    case "Kittens":
                        Kitten kitten = new Kitten(name, age);
                        animals.Add(kitten);
                        break;
                    case "Tomcat":
                        Tomcat tomcat = new Tomcat(name, age);
                        animals.Add(tomcat);
                        break;
                }

            }

            foreach (var animal in animals)
            {
                Console.WriteLine(animal);
            }
        }
    }
}
