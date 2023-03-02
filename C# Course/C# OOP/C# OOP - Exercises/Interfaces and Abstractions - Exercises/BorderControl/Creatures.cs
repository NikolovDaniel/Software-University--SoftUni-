using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl
{
    public abstract class Creatures
    {
        public string Id { get; private set; }

        public Creatures(string id)
        {
            this.Id = id;
        }
    }
}
