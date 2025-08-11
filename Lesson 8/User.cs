
using System;
using System.Collections.Generic;

public class User
{
    public string Name { get; private set; }
    public int PinCode { get; private set; }
    public List<Book> PurchasedBooks { get; private set; }

    public User(string name, int pinCode)
    {
        Name = name;
        PinCode = pinCode;
        PurchasedBooks = new List<Book>();
    }

    public void ShowPurchaseHistory()
    {
        Console.WriteLine($"История покупок пользователя {Name}:");
        if (PurchasedBooks.Count == 0)
        {
            Console.WriteLine("Покупок нет.");
        }
        else
        {
            foreach (var book in PurchasedBooks)
            {
                Console.WriteLine(book);
            }
        }
    }
}