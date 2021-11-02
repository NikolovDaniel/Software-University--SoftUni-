using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl
{
    public class Robot : Creatures
    {
        public string Model { get; private set; }
        public Robot(string model, string id)
            : base(id)
        {
            this.Model = model;
        }
    }
}
