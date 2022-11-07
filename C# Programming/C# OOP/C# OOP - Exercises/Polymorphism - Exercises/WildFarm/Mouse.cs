using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public class Mouse : Mammal
    {

        public Mouse(string name, double weight, string livingRegion)
            : base(name, weight, livingRegion)
        {
        }

        public void ProducingSound()
        {
            Console.WriteLine("Squeak");
        }
        public void EatFood(int quantity)
        {
            this.Weight += quantity * 0.10;
            this.FoodEaten += quantity;
        }
        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, {this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}
