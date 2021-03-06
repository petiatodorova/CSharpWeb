﻿using System;
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

        // First variant - with "yield return"
        public IEnumerator<Book> GetEnumerator()
        {
            for (int i = 0; i < this.books.Count; i++)
            {
                yield return this.books[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            for (int i = 0; i < this.books.Count; i++)
            {
                yield return this.books[i];
            }
        }

        // Second "handmade" variant
        //IEnumerator IEnumerable.GetEnumerator()
        //{
        //    return new BooksEnumerator(this.books);
        //}

        //public IEnumerator<Book> GetEnumerator()
        //{
        //    return new BooksEnumerator(this.books);
        //}

        //private class BooksEnumerator : IEnumerator<Book>
        //{
        //    private int currentIndex;
        //    private readonly List<Book> books;

        //    public BooksEnumerator(List<Book> books)
        //    {
        //        this.Reset();
        //        this.books = books;
        //    }

        //    public Book Current => this.books[this.currentIndex];

        //    object IEnumerator.Current => this.Current;

        //    public void Dispose()
        //    {
                
        //    }

        //    public bool MoveNext()
        //    {
        //        this.currentIndex += 2;
        //        if (currentIndex > this.books.Count)
        //        {
        //            return false;
        //        }
        //        return true;
        //    }

        //    public void Reset()
        //    {
        //        this.currentIndex = -2;
        //    }
        //}
    }
}
