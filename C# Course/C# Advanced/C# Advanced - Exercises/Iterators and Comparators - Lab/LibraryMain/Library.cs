using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryMain
{
    public class Library
    {

        public List<Book> books { get; private set; }

        public Library(params Book[] _books)
        {
            this.books = new List<Book>(_books);
        }
    }
}
