using OnlineShop.Common.Constants;
using OnlineShop.Models.Products.Components;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Models.Products
{
    public abstract class Component : Product, IComponent
    {
        public int Generation { get; private set; }

        public Component(int id, string manufacturer, string model, decimal price, double overallPerformance, int generation) 
            : base(id, manufacturer, model, price, overallPerformance)
        {
            this.Generation = generation;
        }

        public override string ToString()
        {
            return base.ToString() + string.Format(SuccessMessages.ComponentToString, Generation);
        }
    }
}
