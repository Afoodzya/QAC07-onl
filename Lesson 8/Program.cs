using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        var users = new List<User>
        {
            new User("Alice", 1234),
            new User("Bob", 4321),
            new User("Charlie", 1111)
        };

        Console.WriteLine("Добро пожаловать в книжный магазин!");

        User currentUser = null;
        while (currentUser == null)
        {
            Console.Write("Введите имя пользователя: ");
            string inputName = Console.ReadLine();

            Console.Write("Введите PIN-код: ");
            string pinInput = Console.ReadLine();

            if (!int.TryParse(pinInput, out int pin))
            {
                Console.WriteLine("Неверный формат PIN-кода, попробуйте снова.");
                continue;
            }

            foreach (var user in users)
            {
                if (user.Name.Equals(inputName, StringComparison.OrdinalIgnoreCase) && user.PinCode == pin)
                {
                    currentUser = user;
                    break;
                }
            }

            if (currentUser == null)
            {
                Console.WriteLine("Неверное имя пользователя или PIN. Попробуйте еще раз.");
            }
        }

        Console.WriteLine($"Вы успешно вошли, {currentUser.Name}!");

        IStore store = new Store();
        IShoppingCart cart = new ShoppingCart();

        while (true)
        {
            Console.WriteLine("\nГлавное меню:");
            Console.WriteLine("1. Просмотреть все книги");
            Console.WriteLine("2. Поиск книги по названию");
            Console.WriteLine("3. Фильтрация по жанру");
            Console.WriteLine("4. Добавить книгу в корзину");
            Console.WriteLine("5. Просмотреть корзину");
            Console.WriteLine("6. Совершить покупку");
            Console.WriteLine("7. Просмотреть историю покупок");
            Console.WriteLine("0. Выйти\n");
            Console.Write("Выберите действие: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    ShowBooks(store.GetAllBooks());
                    break;

                case "2":
                    Console.Write("Введите название книги для поиска: ");
                    string searchTitle = Console.ReadLine();
                    var foundBooks = store.FindBooksByTitle(searchTitle);
                    ShowBooks(foundBooks);
                    break;

                case "3":
                    Console.Write("Введите жанр (например Fantasy, Non-fiction): ");
                    string genre = Console.ReadLine();
                    var filteredBooks = store.FilterBooksByGenre(genre);
                    ShowBooks(filteredBooks);
                    break;

                case "4":
                    Console.Write("Введите название книги, чтобы добавить в корзину: ");
                    string bookToAddTitle = Console.ReadLine();
                    var booksToAdd = store.FindBooksByTitle(bookToAddTitle);
                    if (booksToAdd.Count == 0)
                    {
                        Console.WriteLine("Книга не найдена.");
                    }
                    else if (booksToAdd.Count == 1)
                    {
                        cart.AddToCart(booksToAdd[0]);
                    }
                    else
                    {
                        Console.WriteLine("Найдено несколько книг:");
                        for (int i = 0; i < booksToAdd.Count; i++)
                        {
                            Console.WriteLine($"{i + 1}. {booksToAdd[i]}");
                        }
                        Console.Write("Выберите номер книги: ");
                        if (int.TryParse(Console.ReadLine(), out int selectedIdx) && selectedIdx > 0 && selectedIdx <= booksToAdd.Count)
                        {
                            cart.AddToCart(booksToAdd[selectedIdx - 1]);
                        }
                        else Console.WriteLine("Неверный выбор.");
                    }
                    break;

                case "5":
                    cart.ViewCart();
                    break;

                case "6":
                    cart.Purchase(currentUser);
                    break;

                case "7":
                    currentUser.ShowPurchaseHistory();
                    break;

                case "0":
                    Console.WriteLine("Спасибо за визит. До свидания!");
                    return;

                default:
                    Console.WriteLine("Неверный выбор. Попробуйте снова.");
                    break;
            }
        }
    }

    static void ShowBooks(List<Book> books)
    {
        if (books.Count == 0)
        {
            Console.WriteLine("Книг не найдено.");
            return;
        }

        Console.WriteLine("Список книг:");
        int i = 1;
        foreach (var book in books)
        {
            Console.WriteLine($"{i}. {book}");
            i++;
        }
    }
}
