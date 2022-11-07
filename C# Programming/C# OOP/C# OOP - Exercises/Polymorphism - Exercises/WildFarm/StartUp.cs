using System;
using System.Collections.Generic;
using System.Linq;

namespace WildFarm
{
    public class StartUp
    {
        static void Main(string[] args)
        {

            List<Animal> animals = new List<Animal>();

            Animal animal = null;

            string input = Console.ReadLine();
            int counter = 0;

            while (input != "End")
            {
                string[] tokens = input.Split(' ');

                if (counter % 2 == 0)
                {
                    switch (tokens[0])
                    {
                        //BIRDS
                        case "Owl":
                            animal = new Owl(tokens[1], double.Parse(tokens[2]), double.Parse(tokens[3]));
                            ((Owl)animal).ProducingSound();
                            break;
                        case "Hen":
                            animal = new Hen(tokens[1], double.Parse(tokens[2]), double.Parse(tokens[3]));
                            ((Hen)animal).ProducingSound();
                            break;
                        //MICE AND DOG 
                        case "Mouse":
                            animal = new Mouse(tokens[1], double.Parse(tokens[2]), tokens[3]);
                            ((Mouse)animal).ProducingSound();
                            break;
                        case "Dog":
                            animal = new Dog(tokens[1], double.Parse(tokens[2]), tokens[3]);
                            ((Dog)animal).ProducingSound();
                            break;
                        //FELINES
                        case "Cat":
                            animal = new Cat(tokens[1], double.Parse(tokens[2]), tokens[3], tokens[4]);
                            ((Cat)animal).ProducingSound();
                            break;
                        case "Tiger":
                            animal = new Tiger(tokens[1], double.Parse(tokens[2]), tokens[3], tokens[4]);
                            ((Tiger)animal).ProducingSound();
                            break;
                    }

                    counter++;
                }
                else
                {
                    string foodType = tokens[0];
                    int quantity = int.Parse(tokens[1]);

                    if (animal.GetType().Name == "Owl")
                    {
                        if (foodType == "Meat")
                        {
                            ((Owl)animal).EatFood(quantity);
                        }
                        else
                        {
                            Console.WriteLine($"{animal.GetType().Name} does not eat {foodType}!");
                        }
                    }
                    else if (animal.GetType().Name == "Hen")
                    {
                        ((Hen)animal).EatFood(quantity);
                    }
                    else if (animal.GetType().Name == "Mouse")
                    {
                        if (foodType == "Vegetables" || foodType == "Fruit")
                        {
                            ((Mouse)animal).EatFood(quantity);
                        }
                        else
                        {
                            Console.WriteLine($"{animal.GetType().Name} does not eat {foodType}!");
                        }
                    }
                    else if (animal.GetType().Name == "Dog")
                    {
                        if (foodType == "Meat")
                        {
                            ((Dog)animal).EatFood(quantity);
                        }
                        else
                        {
                            Console.WriteLine($"{animal.GetType().Name} does not eat {foodType}!");
                        }
                    }
                    else if (animal.GetType().Name == "Cat")
                    {
                        if (foodType == "Vegetable" || foodType == "Meat")
                        {
                            ((Cat)animal).EatFood(quantity);
                        }
                        else
                        {
                            Console.WriteLine($"{animal.GetType().Name} does not eat {foodType}!");
                        }
                    }
                    else if (animal.GetType().Name == "Tiger")
                    {
                        if (foodType == "Meat")
                        {
                            ((Tiger)animal).EatFood(quantity);
                        }
                        else
                        {
                            Console.WriteLine($"{animal.GetType().Name} does not eat {foodType}!");
                        }
                    }

                    animals.Add(animal);
                    counter++;

                }

                input = Console.ReadLine();
            }

            foreach (var item in animals)
            {
                if (item.GetType().Name == "Owl")
                {
                    Console.WriteLine(((Owl)item).ToString());
                }
                else if (item.GetType().Name == "Hen")
                {
                    Console.WriteLine(((Hen)item).ToString());
                }
                else if (item.GetType().Name == "Mouse")
                {
                    Console.WriteLine(((Mouse)item).ToString());
                }
                else if (item.GetType().Name == "Dog")
                {
                    Console.WriteLine(((Dog)item).ToString());
                }
                else if (item.GetType().Name == "Cat")
                {
                    Console.WriteLine(((Cat)item).ToString());
                }
                else if (item.GetType().Name == "Tiger")
                {
                    Console.WriteLine(((Tiger)item).ToString());
                }
            }
        }
    }
}
