using System;
using System.Collections.Generic;
using System.Text;

namespace GenericBoxOfString
{
    public class Box<T>
    {
        public T Element { get; }
        public Box(T element)
        {
            this.Element = element;
        }
        public override string ToString()
        {
            return $"{typeof(T)}: {Element}";
        }


    }
}
