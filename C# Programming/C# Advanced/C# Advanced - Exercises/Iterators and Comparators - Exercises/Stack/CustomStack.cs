using System;
using System.Collections;
using System.Collections.Generic;

namespace Stack
{
    public class CustomStack<T> : IEnumerable<T>
    {
        private List<T> Data;
        public int count;

        public CustomStack(params T[] data)
        {
            this.Data = new List<T>(data);
            count = 0;
        }

        public void Push(T element)
        {
            this.Data.Add(element);
            count++;
        }

        public T Pop()
        {
            if (this.Data.Count == 0)
            {
                throw new ArgumentException("No elements");
            }

            int lastIndex = this.Data.Count - 1;
            T result = this.Data[lastIndex];
            Data.RemoveAt(lastIndex);
            return result;
        }
        public IEnumerator<T> GetEnumerator()
        {
            return new Iterator(this.Data);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        private class Iterator : IEnumerator<T>
        {
            private readonly List<T> data;
            private int currIndex;

            public Iterator(List<T> arr)
            {
                this.data = new List<T>(arr);
                Reset();
            }
            public T Current => this.data[currIndex];
            object IEnumerator.Current => Current;
            public void Dispose() { }
            public bool MoveNext() => --currIndex >= 0;
            public void Reset() => currIndex = this.data.Count;
            
        }
    }
}
