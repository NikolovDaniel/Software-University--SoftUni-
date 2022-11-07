using System;
using System.Collections.Generic;
using System.Text;

namespace GenericSwapMethodIntegers
{
    public class Box<T>
    {
        public List<T> Elements { get; }
        public Box(List<T> list)
        {
            this.Elements = list;
        }
        public void SwapElements(List<T> elements, int indexOne, int indexTwo)
        {
            T elementOne = Elements[indexOne];
            T elementTwo = Elements[indexTwo];
            Elements[indexOne] = elementTwo;
            Elements[indexTwo] = elementOne;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (T element in Elements)
            {
                sb.AppendLine($"{element.GetType()}: {element}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
