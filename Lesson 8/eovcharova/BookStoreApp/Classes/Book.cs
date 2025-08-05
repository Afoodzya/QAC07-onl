using BookStoreApp.Interfaces;

namespace BookStoreApp.Classes;

public class Book : IBook
{
    public string Name { get; set; }
    public string Author { get; set; }
    public string Genre { get; set; }
    public Book(string name, string author, string genre)
    {
        Name = name;
        Author = author;
        Genre = genre;
    }
    public override string ToString()
    {
        return $"Название: {Name}, Автор: {Author}, Жанр: {Genre}";
    }
}