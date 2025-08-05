using BookStoreApp.Classes;
using BookStoreApp.Interfaces;

namespace BookStoreApp; 

class Program
{
    static void Main(string[] args) 
    {
        UsersDataBase usersDataBase = new UsersDataBase();
        User? user = usersDataBase.AuthorizeUser();
        if (user == null)
        {
            Console.WriteLine("Авторизация не удалась. Завершение работы.");
            return; 
        }
        Console.WriteLine($"Приветствуем, {user.Username}!");
        
        Store store = new Store();
        ShoppingCart shoppingCart = new ShoppingCart(store, user);
        
        store.ShowMenu();
        
        ChooseActionStep(store, shoppingCart, user);
    }
    static void ChooseActionStep(Store store, ShoppingCart shoppingCart, User? user)
    {
        int actionStep = 0;
        do
        {
            string? input = Console.ReadLine();
            if (!int.TryParse(input, out int userInput))
            {
                Console.WriteLine("Введите корректный номер пункта меню.");
                continue;
            }
            
            actionStep = userInput;
            if (actionStep != 8)
            {
                switch (actionStep)
                {
                    case 1:
                        Console.Clear();
                        store.ViewAllBooksInStore();
                        store.ShowMenu();
                        break;
                    case 2:
                        Console.Clear();
                        store.DisplayFoundBooksByName();
                        store.ShowMenu();
                        break;
                    case 3:
                        Console.Clear();
                        store.DisplayFoundBooksByGenre();
                        store.ShowMenu();
                        break;
                    case 4:
                        Console.Clear();
                        shoppingCart.AddBookToCart();
                        store.ShowMenu();
                        break;
                    case 5:
                        Console.Clear();
                        shoppingCart.ViewTheCart();
                        store.ShowMenu();
                        break;
                    case 6:
                        Console.Clear();
                        shoppingCart.BuyBook();
                        store.ShowMenu();
                        break;
                    case 7:
                        Console.Clear();
                        user.ShowPurchaseHistory();
                        store.ShowMenu();
                        break;
                    default:
                        Console.WriteLine("Указанный пункт меню не существует!");
                        break;
                }
            }
        } while (actionStep != 8);
    }
}