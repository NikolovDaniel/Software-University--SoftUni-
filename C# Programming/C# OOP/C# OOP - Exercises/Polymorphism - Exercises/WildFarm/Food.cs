using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public abstract class Food
    {
        public int Quantity { get; private set; }

        public Food(int quantity)
        {
            this.Quantity = quantity; 
        }
    }
}
