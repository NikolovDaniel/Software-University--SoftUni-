using System;
using System.Collections.Generic;

namespace AMinerTask
{
    class Program
    {
        static void Main(string[] args)
        {

            Dictionary<string, int> resources = new Dictionary<string, int>();

            string resource = Console.ReadLine();
            int quantity = int.Parse(Console.ReadLine());

            while (true)
            {

                if (resources.ContainsKey(resource))
                {
                    resources[resource] += quantity;
                }
                else
                {
                    resources.Add(resource, quantity);
                }

                resource = Console.ReadLine();
                if (resource == "stop") break;
                quantity = int.Parse(Console.ReadLine());
            }

            foreach (var item in resources)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }

        }
    }
}
