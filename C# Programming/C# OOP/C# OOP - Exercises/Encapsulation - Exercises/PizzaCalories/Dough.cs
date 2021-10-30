using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Dough
    {
        private const double White = 1.5;
        private const double Wholegrain = 1.0;

        private double grams;
        private string flour;
        private string bakingTechnique;

        public Dough(string flour, string bakingTechnique, double grams)
        {
            this.Flour = flour;
            this.BakingTechnique = bakingTechnique;
            this.Grams = grams;
        }

        public double Grams
        {
            get { return grams; }
            private set
            {
                if (value <= 0 || value > 200)
                {
                    throw new ArgumentException("Dough weight should be in the range [1..200].");
                }

                this.grams = value;
            }
        }

        public string Flour
        {
            get { return flour; }
            private set
            {
                if (value.ToLower() != "white" 
                    && value.ToLower() != "wholegrain")
                {
                    throw new ArgumentException("Invalid type of dough.");
                }

                this.flour = value;
            }
        }
        public string BakingTechnique
        {
            get { return bakingTechnique; }
            private set
            {
                if (value.ToLower() != "crispy" 
                    && value.ToLower() != "chewy" 
                    && value.ToLower() != "homemade")
                {
                    throw new ArgumentException("Invalid type of dough.");
                }

                this.bakingTechnique = value;
            }
        }

        public double CalculateCalories()
        {
            double techGrams = GetTechnique(this.BakingTechnique.ToLower());

            if (this.Flour.ToLower() == "white")
            {
                return (2 * Grams) * White * techGrams;
            }
            else if (this.Flour.ToLower() == "wholegrain")
            {
                return (2 * Grams) * Wholegrain * techGrams;
            }

            return 0;
        }
        private double GetTechnique(string technique)
        {
            if (technique == "crispy")
            {
                return 0.9;
            }
            else if (technique == "chewy")
            {
                return 1.1;
            }
            else if (technique == "homemade")
            {
                return 1.0;
            }

            return 0;
        }
    }
}
