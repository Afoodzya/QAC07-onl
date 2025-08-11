using System.Collections.Generic;

public interface IStore
{
    List<Book> GetAllBooks();
    List<Book> FindBooksByTitle(string title);
    List<Book> FilterBooksByGenre(string genre);
}
