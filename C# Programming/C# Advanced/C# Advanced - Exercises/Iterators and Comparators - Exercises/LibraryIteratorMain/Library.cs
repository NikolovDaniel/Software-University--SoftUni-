using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace LibraryIteratorMain
{
    public class Library : IEnumerable<Book>
    {
        public List<Book> books { get; private set; }

        public Library(params Book[] _books)
        {
            this.books = new List<Book>(_books);
        }

        public IEnumerator<Book> GetEnumerator()
        {
            return new LibraryIterator(this.books);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    public class LibraryIterator : IEnumerator<Book>
    {
        private readonly List<Book> books;
        private int currentIndex;

        public LibraryIterator(IEnumerable<Book> books)
        {
            this.Reset();
            this.books = new List<Book>(books);
        }

        public Book Current => books[currentIndex];
        object IEnumerator.Current => Current;
        public void Dispose() { }
        public bool MoveNext() => ++currentIndex < books.Count;
        public void Reset() => currentIndex = -1;
        
    }
}
