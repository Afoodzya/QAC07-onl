using BookStoreApp.Interfaces;

namespace BookStoreApp.Classes;

public class ShoppingCart : IShoppingCart
{
    public List<Book> BooksInCartList { get; set; } = new List<Book>(); 
    public List<Book> PurchasedBooks { get; set; } = new List<Book>();
    
    private readonly Store _store;
    
    private readonly User _user;
    public ShoppingCart(Store store, User user)
    {
        _store = store;
        _user = user;
    }
    public void AddBookToCart()
    {
        Console.Write("Введите название книги которую хотите добавить в корзину: ");
        
        string bookName = Console.ReadLine() ?? string.Empty;
        if (string.IsNullOrWhiteSpace(bookName))
        {
            Console.WriteLine("Название не может быть пустым!");
            return;
        }
        
        var foundBooks = _store.GetBookByName(bookName);

        if (foundBooks.Count > 0)
        {
            BooksInCartList.AddRange(foundBooks);
            string bookNames = string.Join(", ", foundBooks.Select(book => book.Name));
            Console.WriteLine($"Добавлены книги: * {bookNames} * в корзину");
        }
        else
        {
            Console.WriteLine("Книга не найдена.");
        }
    }
    public void ViewTheCart()
    {
        Console.WriteLine("--- Содержимое корзины ---");
        if (BooksInCartList.Count > 0)
        {
            foreach (var item in BooksInCartList)
            {
                Console.WriteLine(item);
            }
        }
        else
        {
            Console.WriteLine("Ваша корзина пуста!");
        }
    }

    public void BuyBook()
    {
        if (BooksInCartList.Count == 0)
        {
            Console.WriteLine("Корзина пуста! Добавьте книги перед покупкой.");
            return;
        }
        
        Console.Write("Введите название книги которую хотите купить: ");
        string bookNameToBuy = Console.ReadLine() ?? string.Empty;
        if (string.IsNullOrWhiteSpace(bookNameToBuy))
        {
            Console.WriteLine("Название не может быть пустым!");
            return;
        }
        var bookInCart = BooksInCartList.FirstOrDefault(b => 
            b.Name.Contains(bookNameToBuy, StringComparison.OrdinalIgnoreCase));
        if (bookInCart != null)
        {
            PurchasedBooks.Add(bookInCart);
            BooksInCartList.Remove(bookInCart);
            _user.PurchasedBooksByUser.Add(bookInCart);
            Console.WriteLine($"Куплена книга: {bookInCart.Name}");
        }
        else
        {
            Console.WriteLine("Книга не найдена в корзине.");
        }
    }
}