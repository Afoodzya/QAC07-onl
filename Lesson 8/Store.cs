using System;
using System.Collections.Generic;
using System.Linq;

public class Store : IStore
{
    private List<Book> books = new List<Book>();

    public Store()
    {
        books.Add(new Book("The Hobbit", "J.R.R. Tolkien", "Fantasy"));
        books.Add(new Book("1984", "George Orwell", "Dystopian"));
        books.Add(new Book("Sapiens", "Yuval Noah Harari", "Non-fiction"));
        books.Add(new Book("The Fellowship of the Ring", "J.R.R. Tolkien", "Fantasy"));
        books.Add(new Book("Becoming", "Michelle Obama", "Biography"));
    }

    public List<Book> GetAllBooks()
    {
        return books;
    }

    public List<Book> FindBooksByTitle(string title)
    {
        return books.Where(b => b.Title.IndexOf(title, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
    }

    public List<Book> FilterBooksByGenre(string genre)
    {
        return books.Where(b => string.Equals(b.Genre, genre, StringComparison.OrdinalIgnoreCase)).ToList();
    }
}
