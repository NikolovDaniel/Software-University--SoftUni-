using System;
using System.Collections.Generic;
using System.Text;

namespace ImplementingList
{
    class CustomList
    {
        private const int InitialCapacity = 2;

        private int[] Data;
        public int Count { get; private set; }
        public int this[int index]
        {
            get
            {
                if (index >= this.Count)
                {
                    throw new ArgumentOutOfRangeException();
                }
                return Data[index];
            }
            set
            {
                if (index >= this.Count)
                {
                    throw new ArgumentOutOfRangeException();
                }
                Data[index] = value;
            }
        }

        public CustomList()
        {
            this.Data = new int[InitialCapacity];
        }

        public void Add(int element)
        {
            if (this.Count == this.Data.Length)
            {
                this.Resize();
            }

            this.Data[this.Count] = element;
            this.Count++;
        }
        public int RemoveAt(int index)
        {
            ValidateIndex(index);

            int result = this.Data[index];

            this.Shift(index);

            Count--;
            if (this.Count <= this.Data.Length / 4)
            {
                this.Shrink();
            }
            return result;
        }
        public void Insert(int index, int item)
        {
            this.ValidateIndex(index);

            if (this.Count == this.Data.Length)
            {
                this.Resize();
            }

            this.ShiftToRight(index);
            this.Data[index] = item;
            Count++;
            
        }
        public bool Contains(int element)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (element == this.Data[i])
                {
                    return true;
                }
            }

            return false;
        }
        public void Swap(int firstIndex, int secondIndex)
        {
            if (firstIndex > Count || secondIndex > Count)
            {
                throw new ArgumentNullException("No element at one of the indexes!");
            }

            int currItem = this.Data[firstIndex];
            this.Data[firstIndex] = this.Data[secondIndex];
            this.Data[secondIndex] = currItem;
        }

        private void Resize()
        {
            int[] copy = new int[this.Data.Length * 2];

            for (int i = 0; i < Data.Length; i++)
            {
                copy[i] = Data[i];
            }

            this.Data = copy;
        }

        private void Shrink()
        {
            int[] copy = new int[this.Data.Length / 2];

            for (int i = 0; i < this.Count; i++)
            {
                copy[i] = this.Data[i];
            }

            this.Data = copy;
        }

        private void Shift(int index)
        {
            for (int i = index; i < this.Count - 1; i++)
            {
                this.Data[i ] = this.Data[i + 1];
            }
        }
        private void ShiftToRight(int index)
        {
            for (int i = Count; i > index; i--)
            {
                this.Data[i] = this.Data[i - 1];
            }
        }

        private void ValidateIndex(int index)
        {
            if (index > this.Count - 1 || index < 0)
            {
                throw new ArgumentOutOfRangeException("Out of array");
            }
            else return;
        }
    }
}
