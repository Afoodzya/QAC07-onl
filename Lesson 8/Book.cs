public class Book : ConsoleApp12BookStore.IBook
{
    public string Title { get; private set; }
    public string Author { get; private set; }
    public string Genre { get; private set; }

    public Book(string title, string author, string genre)
    {
        Title = title;
        Author = author;
        Genre = genre;
    }

    public override string ToString()
    {
        return $"{Title} by {Author} [{Genre}]";
    }
}