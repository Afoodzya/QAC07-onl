using System;
using System.Collections.Generic;

public class ShoppingCart : IShoppingCart
{
    private List<Book> cartItems = new List<Book>();

    public void AddToCart(Book book)
    {
        cartItems.Add(book);
        Console.WriteLine($"Книга \"{book.Title}\" добавлена в корзину.");
    }

    public void ViewCart()
    {
        Console.WriteLine("Содержимое корзины:");
        if (cartItems.Count == 0)
        {
            Console.WriteLine("Корзина пуста.");
        }
        else
        {
            int i = 1;
            foreach (var book in cartItems)
            {
                Console.WriteLine($"{i}. {book}");
                i++;
            }
        }
    }

    public void Purchase(User user)
    {
        if (cartItems.Count == 0)
        {
            Console.WriteLine("Корзина пуста. Купить нечего.");
            return;
        }

        user.PurchasedBooks.AddRange(cartItems);
        cartItems.Clear();

        Console.WriteLine("Покупка успешна! Спасибо за покупку.");
    }

    public bool IsEmpty()
    {
        return cartItems.Count == 0;
    }
}
