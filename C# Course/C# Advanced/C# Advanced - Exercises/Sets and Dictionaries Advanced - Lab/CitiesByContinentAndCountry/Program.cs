using System;
using System.Collections.Generic;

namespace CitiesByContinentAndCountry
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, Dictionary<string, List<string>>> continentAndCountries = new Dictionary<string, Dictionary<string, List<string>>>();


            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();

                string continent = input[0];
                string country = input[1];
                string town = input[2];

                if (continentAndCountries.ContainsKey(continent))
                {
                    if (continentAndCountries[continent].ContainsKey(country))
                    {
                        continentAndCountries[continent][country].Add(town);
                    }
                    else
                    {
                        continentAndCountries[continent].Add(country, new List<string>() { town });
                    }
                }
                else
                {
                    continentAndCountries.Add(continent, new Dictionary<string, List<string>>()
                    {
                        {country, new List<string>() { town } }
                    });
                }
            }

            foreach (var continent in continentAndCountries)
            {
                Console.WriteLine($"{continent.Key}:");
                foreach (var country in continent.Value)
                {
                    Console.WriteLine($"  {country.Key} -> {string.Join(", ", country.Value)}");
                }
            }

        }
    }
}
