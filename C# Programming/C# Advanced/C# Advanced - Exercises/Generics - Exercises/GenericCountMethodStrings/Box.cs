using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GenericCountMethodStrings
{
    public class Box<T> where T : IComparable
    {
        public List<T> Elements { get; }
       
        public Box(List<T> elements)
        {
            this.Elements = elements;
        }
        
        public int CountGreaterElements(List<T> elements, T element) 
        {
            return elements.Where(e => e.CompareTo(element) > 0).ToList().Count;
        }


    }
}
