using System;
using System.Collections.Generic;
using System.Text;

namespace Tuple
{
    public class Tuple<TFirst, TSecond>
    {

        public TFirst ElementOne { get; private set; }
        public TSecond ElementTwo { get; private set; }

        public Tuple(TFirst elementOne, TSecond elementTwo)
        {
            this.ElementOne = elementOne;
            this.ElementTwo = elementTwo;
        }

        public override string ToString()
        {
            return $"{ElementOne} -> {ElementTwo}";
        }
    }
}
