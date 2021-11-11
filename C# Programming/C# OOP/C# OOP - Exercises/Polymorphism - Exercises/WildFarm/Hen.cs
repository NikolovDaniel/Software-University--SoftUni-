using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public class Hen : Bird
    {
        public Hen(string name, double weight, double wingSize)
            : base(name, weight, wingSize)
        {
        }

        public void ProducingSound()
        {
            Console.WriteLine("Cluck");
        }

        public void EatFood(int quantity)
        {
            this.Weight += quantity * 0.35;
            this.FoodEaten += quantity;
        }
        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, {this.WingSize}, {this.Weight}, {this.FoodEaten}]";
        }
    }
}
