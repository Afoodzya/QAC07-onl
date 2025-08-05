using BookStoreApp.Classes;

namespace BookStoreApp.Interfaces;

public interface IShoppingCart
{
    public List<Book> BooksInCartList { get; set; }
    public List<Book> PurchasedBooks { get; set; }
    void AddBookToCart();
    void ViewTheCart();
    void BuyBook();
}