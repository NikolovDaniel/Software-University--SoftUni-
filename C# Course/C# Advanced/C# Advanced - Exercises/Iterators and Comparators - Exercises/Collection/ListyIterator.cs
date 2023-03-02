using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Collection
{
    public class ListyIterator<T> : IEnumerable<T>
    {
        public List<T> Elements { get; set; }
        private int Index { get; set; }
        public ListyIterator(params T[] elements)
        {
            this.Elements = new List<T>(elements);
            Index = 0;
        }

        public void PrintAll()
        {
            foreach (var item in Elements)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }
        public void Print()
        {
            if (Elements.Count == 0)
            {
                Console.WriteLine("Invalid Operation!");
            }
            else
            {
                Console.WriteLine(Elements[Index]);
            }
        }
        public bool HasNext()
        {
            if (Index + 1 < Elements.Count) return true;

            return false;
        }
        public bool Move()
        {
            if (Index >= 0 && Index + 1 < Elements.Count)
            {
                Index++;
                return true;
            }

            return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            int currIndex = 0;
            while (currIndex < Elements.Count)
            {
                yield return Elements[currIndex];
                currIndex++;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        //private class ListIterator : IEnumerator<T>
        //{
        //    private readonly List<T> Elements;
        //    private int currIndex;

        //    public ListIterator(IEnumerable<T> elements)
        //    {
        //        Reset();
        //        this.Elements = new List<T>(elements);
        //    }
        //    public T Current => this.Elements[currIndex];

        //    object IEnumerator.Current => Current;

        //    public void Dispose() { }

        //    public bool MoveNext() => ++currIndex < Elements.Count;

        //    public void Reset() => currIndex = -1;
           
        //}
    }
}
