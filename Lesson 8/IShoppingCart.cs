using System.Collections.Generic;

public interface IShoppingCart
{
    void AddToCart(Book book);
    void ViewCart();
    void Purchase(User user);
    bool IsEmpty();
}
