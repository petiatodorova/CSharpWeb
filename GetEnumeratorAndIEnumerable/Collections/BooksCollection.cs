using System;
using System.Collections;
using System.Collections.Generic;

namespace Collections
{
    public class BooksCollection : IEnumerable<Book>
    {
        private readonly List<Book> books;

        public BooksCollection()
        {
            this.books = new List<Book>();
        }

        public void Add(Book book)
        {
            this.books.Add(book);
        }

        public IEnumerator<Book> GetEnumerator()
        {
            return new BooksEnumerator(this.books);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new BooksEnumerator(this.books);
        }

        private class BooksEnumerator : IEnumerator<Book>
        {
            private int currentIndex = -1;
            private readonly List<Book> books;

            public BooksEnumerator(List<Book> books)
            {
                this.Reset();
                this.books = books;
            }

            public Book Current => this.books[this.currentIndex];

            object IEnumerator.Current => this.Current;

            public void Dispose()
            {
                
            }

            public bool MoveNext()
            {
                return ++this.currentIndex < books.Count;
            }

            public void Reset()
            {
                this.currentIndex = -1;
            }
        }
    }
}
