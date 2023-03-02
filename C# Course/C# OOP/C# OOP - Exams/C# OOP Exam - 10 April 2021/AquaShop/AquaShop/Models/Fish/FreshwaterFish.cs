using System;
using System.Collections.Generic;
using System.Text;

namespace AquaShop.Models.Fish
{
    public class FreshwaterFish : Contracts.Fish
    {
        public FreshwaterFish(string name, string species, decimal price)
            :base(name, species, price)
        {
            this.Size = 3;
        }
    }
}
