using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public class Owl : Bird
    {
        public Owl(string name, double weight, double wingSize)
            : base(name, weight, wingSize)
        {
        }

        public void ProducingSound()
        {
            Console.WriteLine("Hoot Hoot");
        }
        public void EatFood(int quantity)
        {
            this.Weight += quantity * 0.25;
            this.FoodEaten += quantity;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, {this.WingSize}, {this.Weight}, {this.FoodEaten}]";
        }
    }
}
