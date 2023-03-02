using System;
using System.Collections.Generic;
using System.Text;

namespace AquaShop.Models.Fish
{
    public class SaltwaterFish : Contracts.Fish
    {
        public SaltwaterFish(string name, string species, decimal price)
            :base(name, species, price)
        {
            this.Size = 5;
        }
    }
}
