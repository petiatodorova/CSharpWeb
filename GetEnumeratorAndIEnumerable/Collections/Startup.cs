namespace Collections
{
    using System;
    using System.Collections.Generic;

    public class Startup
    {
        public static void Main()
        {
            var ourBooks = new BooksCollection();
            ourBooks.Add(new Book { Title = "Summer time" });
            ourBooks.Add(new Book { Title = "Summer time1" });
            ourBooks.Add(new Book { Title = "Summer time2" });

            foreach (var book in ourBooks)
            {
                Console.WriteLine($"{book.Title}");
            }
            
        }
    }
}
