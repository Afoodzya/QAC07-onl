using BookStoreApp.Interfaces; // подключение интерфейса

namespace BookStoreApp.Classes;

public class Store : IStore
{
    public List<Book> BooksInStockList { get; set; }
    public List<string> storeMenu { get; set; }
    public Store()
    {
        storeMenu = new List<string>
        {
            "1. список доступных книг",
            "2. найти книгу по названию",
            "3. найти книгу по жанру",
            "4. добавить книгу в корзину",
            "5. корзина",
            "6. купить книгу",
            "7. история покупок",
            "8. выйти из приложения",
        };
        BooksInStockList = new List<Book>
        {
            new Book("Мастер и Маргарита","Михаил Булгаков","Классика, Мистика"),
            new Book("1984","Джордж Оруэлл","Антиутопия"),
            new Book("Гарри Поттер и Философский камень","Дж. К. Роулинг","Фэнтези")
        };
    }
    public void ShowMenu()
    {
        Console.WriteLine();
        Console.WriteLine("Выберите пункт меню для продолжения: ");
        Console.WriteLine(" *** Книжный магазин *** ");
        foreach (var action in storeMenu)
        {
            Console.WriteLine(action);
        }
    }
    public void ViewAllBooksInStore()
    {
        Console.WriteLine(" *** Книги в наличии: *** ");
        foreach (var book in BooksInStockList)
        {
            Console.WriteLine(book);
        }
    }
    public void DisplayFoundBooksByName()
    {
        Console.Write("Введите название книги: ");
        string bookName = Console.ReadLine() ?? string.Empty;
            
        if (string.IsNullOrWhiteSpace(bookName))
        {
            Console.WriteLine("Название не может быть пустым!");
            return;
        }
        List<Book> foundBooksByName = GetBookByName(bookName);
        PrintFoundBooksInfo(foundBooksByName);
    }
    public void DisplayFoundBooksByGenre()
    {
        Console.Write("Введите жанр книги: ");
        string bookGenre = Console.ReadLine() ?? string.Empty;
            
        if (string.IsNullOrWhiteSpace(bookGenre))
        {
            Console.WriteLine("Название не может быть пустым!");
            return;
        }

        List<Book> foundBooksByGenre = GetBookByGenre(bookGenre);
        PrintFoundBooksInfo(foundBooksByGenre);
    }
    public List<Book> GetBookByName(string name) 
    {
        return BooksInStockList
            .FindAll(b => b.Name.Contains(name, StringComparison.OrdinalIgnoreCase));
    }
    public List<Book> GetBookByGenre(string genre)
    {
        return BooksInStockList
            .FindAll(b =>b.Genre.Contains(genre, StringComparison.OrdinalIgnoreCase));
    }
    public void PrintFoundBooksInfo(List<Book> books)
    {
        if (books.Count > 0)
        {
            Console.WriteLine("Найдены книги: ");
            foreach (Book book in books)
            {
                Console.WriteLine(book);
            }
        }
        else
        {
            Console.WriteLine("Книги не найдены.");
        }
    }
}