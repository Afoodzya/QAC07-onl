namespace BookStoreApp.Interfaces;

public interface IBook
{ 
    string Name { get; set; }
    string Author { get; set; }
    string Genre { get; set; }
}