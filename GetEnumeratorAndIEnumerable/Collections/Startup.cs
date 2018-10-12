namespace Collections
{
    using System;
    using System.Collections.Generic;

    public class Startup
    {
        public static void Main()
        {
            var ourBooks = new BooksCollection();
            ourBooks.Add(new Book { Title = "Summer time0" });
            ourBooks.Add(new Book { Title = "Summer time1" });
            ourBooks.Add(new Book { Title = "Summer time2" });
            ourBooks.Add(new Book { Title = "Summer time3" });
            ourBooks.Add(new Book { Title = "Summer time4" });

            foreach (var book in ourBooks)
            {
                Console.WriteLine($"{book.Title}");
            }
            
        }
    }
}
