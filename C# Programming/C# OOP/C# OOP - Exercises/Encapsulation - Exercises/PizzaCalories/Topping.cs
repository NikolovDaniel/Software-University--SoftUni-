using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Topping
    {
        private string type;
        private double grams;

        public Topping(string type, double grams)
        {
            this.Type = type;
            this.Grams = grams;
        }
        public string Type
        {
            get { return type; }
            private set
            {
                if (value.ToLower() != "meat" 
                    && value.ToLower() != "veggies"
                    && value.ToLower() != "cheese" 
                    && value.ToLower() != "sauce")
                {
                    throw new ArgumentException($"Cannot place {value} on top of your pizza.");
                }

                this.type = value;
            }
        }
        public double Grams
        {
            get { return grams; }
            private set
            {
                if (value <= 0 || value > 50)
                {
                    throw new ArgumentException($"{this.type} weight should be in the range [1..50].");
                }
                this.grams = value;
            }
        }

        public double CalculateGrams()
        {
            double toppingGrams = GetToppingGrams(this.Type.ToLower());

            return 2 * this.Grams * toppingGrams;
        }

        private double GetToppingGrams(string topping)
        {
            if (topping == "meat") return 1.2;
            if (topping == "veggies") return 0.8;
            if (topping == "cheese") return 1.1;
            if (topping == "sauce") return 0.9;

            return 0;
        }
    }
}
