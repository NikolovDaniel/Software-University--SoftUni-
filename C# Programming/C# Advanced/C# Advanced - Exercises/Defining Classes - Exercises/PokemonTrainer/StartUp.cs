using System;
using System.Collections.Generic;
using System.Linq;

namespace PokemonTrainer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            List<Trainer> listOfTrainers = new List<Trainer>();

            while (input != "Tournament")
            {
                string[] tokens = input.Split();

                string trainerName = tokens[0];
                string pokemonName = tokens[1];
                string pokemonElement = tokens[2];
                int pokemonHealth = int.Parse(tokens[3]);

                Pokemon pokemon = new Pokemon(pokemonName, pokemonElement, pokemonHealth);

                Trainer trainer = new Trainer()
                {
                    Name = trainerName,
                    NumberBadges = 0,
                    Pokemons = new List<Pokemon>() { pokemon }
                };

                bool isThere = false;

                foreach (var pkmTrainer in listOfTrainers)
                {
                    if (pkmTrainer.Name == trainer.Name)
                    {
                        pkmTrainer.Pokemons.Add(pokemon);
                        isThere = true;
                        break;
                    }
                }

                if (!isThere)
                {
                    listOfTrainers.Add(trainer);
                }

                input = Console.ReadLine();
            }

            input = Console.ReadLine();

            while (input != "End")
            {

                foreach (var trainer in listOfTrainers)
                {
                    bool isThere = false;
                    foreach (var pokemon in trainer.Pokemons)
                    {
                        if (pokemon.Element == input)
                        {
                            trainer.NumberBadges++;
                            isThere = true;
                            break;
                        }
                    }
                    if (!isThere)
                    {
                        for (int i = 0; i < trainer.Pokemons.Count; i++)
                        {
                            trainer.Pokemons[i].Health -= 10;
                            if (trainer.Pokemons[i].Health <= 0)
                            {
                                trainer.Pokemons.Remove(trainer.Pokemons[i]);
                            }
                        }
                    }
                }

                input = Console.ReadLine();
            }

            foreach (var trainer in listOfTrainers.OrderByDescending(t => t.NumberBadges))
            {
                Console.WriteLine($"{trainer.Name} {trainer.NumberBadges} {trainer.Pokemons.Count}");
            }
        }
    }
}
