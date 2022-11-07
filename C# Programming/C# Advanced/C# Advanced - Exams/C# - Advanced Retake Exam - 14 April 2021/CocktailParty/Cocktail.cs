using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CocktailParty
{
    public class Cocktail
    {
        private List<Ingredient> Ingredients;
        public string Name { get; set; }
        public int Capacity { get; set; }
        public int MaxAlcoholLevel { get; set; }
        public int CurrentAlcoholLevel { get; private set; }

        public Cocktail(string name, int capacity, int maxAlcoholLevel)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.MaxAlcoholLevel = maxAlcoholLevel;
            this.Ingredients = new List<Ingredient>();
        }

        public void Add(Ingredient ingredient)
        {
            bool isThere = false;

            foreach (var item in Ingredients)
            {
                if (item.Name == ingredient.Name)
                {
                    isThere = true;
                    break;
                }
            }

            if (!isThere)
            {
                if (Ingredients.Count < this.Capacity
                    && CurrentAlcoholLevel + ingredient.Alcohol <= MaxAlcoholLevel)
                {
                    Ingredients.Add(ingredient);
                    CurrentAlcoholLevel += ingredient.Alcohol;
                }
            }
        }

        public bool Remove(string name)
        {
            if (Ingredients.Select(x => x.Name == name).ToList().Count == 0)
            {
                return false;
            }
            else
            {
                Ingredients.Remove(Ingredients.FirstOrDefault(x => x.Name == name));
                CurrentAlcoholLevel = Ingredients.Sum(x => x.Alcohol);
                return true;
            }
        }

        public Ingredient FindIngredient(string name)
        {
            return Ingredients.FirstOrDefault(x => x.Name == name);
        }

        public Ingredient GetMostAlcoholicIngredient()
        {
            return Ingredients.OrderByDescending(x => x.Alcohol).FirstOrDefault();
        }

        public string Report()
        {
            string result = $"Cocktail: {this.Name} - Current Alcohol Level: {this.CurrentAlcoholLevel}\r\n";

            foreach (var item in Ingredients)
            {
                result += $"{item.ToString().TrimEnd()}\r\n";
            }

            return result.TrimEnd();
        }
    }
}
