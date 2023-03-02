using AquaShop.Models.Decorations.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace AquaShop.Models
{
    public abstract class Decoration : IDecoration
    {
        public int Comfort { get; private set; }

        public decimal Price { get; private set; }

        public Decoration(int comfort, int price)
        {
            this.Comfort = comfort;
            this.Price = price;
        }
    }
}
