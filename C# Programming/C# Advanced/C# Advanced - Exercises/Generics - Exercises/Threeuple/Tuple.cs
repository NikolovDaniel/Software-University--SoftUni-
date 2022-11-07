using System;
using System.Collections.Generic;
using System.Text;

namespace Threeuple
{
    public class Tuple<TFirst, TSecond, TThird>
    {

        public TFirst ElementOne { get; private set; }
        public TSecond ElementTwo { get; private set; }
        public TThird ElementThree { get; private set; }

        public Tuple(TFirst elementOne, TSecond elementTwo, TThird elementThree)
        {
            this.ElementOne = elementOne;
            this.ElementTwo = elementTwo;
            this.ElementThree = elementThree;
        }

        public override string ToString()
        {
            return $"{ElementOne} -> {ElementTwo} -> {ElementThree}";
        }
    }
}
