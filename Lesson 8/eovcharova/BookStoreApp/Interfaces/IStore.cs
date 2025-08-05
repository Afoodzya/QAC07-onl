using BookStoreApp.Classes;

namespace BookStoreApp.Interfaces;
public interface IStore
{
    public List<Book> BooksInStockList { get; set; }
    public List<string> storeMenu { get; set; }
    void ShowMenu();
    void ViewAllBooksInStore();
    List<Book> GetBookByName(string name); 
    List<Book> GetBookByGenre(string genre);
    void PrintFoundBooksInfo(List<Book> books);
}