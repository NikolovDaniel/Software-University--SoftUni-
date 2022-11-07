using System;
using System.Collections.Generic;
using System.Text;

namespace ImplementingStack
{
    public class CustomStack
    {
        private const int InitialCapacity = 4;
        private int[] Data;
        private int count;

        public CustomStack()
        {
            this.Data = new int[InitialCapacity];
            count = 0;
        }

        public int Count
        {
            get
            {
                return this.count;
            }
        }

        public void Push(int element)
        {
            //Adds element to the stack - {1, 2, 3, 4, 5} - Push(6) = {1, 2, 3, 4, 5 ,6}
            if (count == this.Data.Length)
            {
                Resize();
            }

            this.Data[this.count] = element;
            count++;
        }

        public int Pop()
        {
            //Takes the last element of the array, return it and removes it.
            if (this.Data.Length == 0)
            {
                throw new InvalidOperationException("CustomStack is empty!");
            }

            int lastIndex = this.count - 1;
            int result = this.Data[lastIndex];
            count--;
            return result;
        }
        public int Peek()
        {
            //Takes the last element of the array and return it.
            if (this.Data.Length == 0)
            {
                throw new InvalidOperationException("CustomStack is empty!");
            }

            return this.Data[count - 1];
        }

        public void ForEach(Action<object> action)
        {
            for (int i = 0; i < this.count; i++)
            {
                action(this.Data[i]);
            }
        }
        private void Resize()
        {
            //Creates a new array, twice the size of the main one and assing it.

            int[] copy = new int[this.Data.Length * 2];

            for (int i = 0; i < count; i++)
            {
                copy[i] = this.Data[i];
            }

            this.Data = copy;
        }
    }
}
