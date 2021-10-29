using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingSpree
{
    public class StartUp
    {
        static void Main(string[] args)
        {
           
            List<Person> personCollection = new List<Person>();
            List<Product> productsCollection = new List<Product>();

            try
            {
                string[] people = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);
                string[] products = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);

                for (int i = 0; i < people.Length; i++)
                {
                    string[] tokens = people[i].Split("=");
                    string name = tokens[0];
                    decimal money = decimal.Parse(tokens[1]);

                    Person person = new Person(name, money);
                    personCollection.Add(person);
                }

                for (int i = 0; i < products.Length; i++)
                {
                    string[] tokens = products[i].Split("=");
                    string name = tokens[0];
                    decimal price = decimal.Parse(tokens[1]);

                    Product product = new Product(name, price);
                    productsCollection.Add(product);
                }

                string input = Console.ReadLine();

                while (input != "END")
                {
                    string[] tokens = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    string name = tokens[0];
                    string productName = tokens[1];

                    Person person = personCollection.FirstOrDefault(p => p.Name == name);
                    Product product = productsCollection.FirstOrDefault(p => p.Name == productName);

                    person.BuyProduct(product);

                    input = Console.ReadLine();
                }

                foreach (var person in personCollection)
                {
                    Console.WriteLine(person);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
