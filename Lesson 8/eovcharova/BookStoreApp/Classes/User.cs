namespace BookStoreApp.Classes;

public class User
{
    public string Username { get; private set; }
    public int Pincode { get; private set; }
    public List<Book> PurchasedBooksByUser { get; private set; } = new List<Book>();
    public User(string username, int pincode)
    {
        Username = username;
        Pincode = pincode;
    }
    public override string ToString()
    {
        return $"имя: {Username}, пин: {Pincode}";
    }
    public void ShowPurchaseHistory()
    {
        Console.WriteLine($"История покупок {Username}: ");
        if (PurchasedBooksByUser.Count > 0)
        {
            foreach (var book in PurchasedBooksByUser)
            {
                Console.WriteLine(book);
            }
        }
        else
        {
            Console.WriteLine("У вас нет ни одной купленной книги");
        }
    }
}