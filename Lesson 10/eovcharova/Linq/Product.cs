namespace Linq;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Category { get; set; }
    public decimal Price { get; set; }
    public int QuantityInStock { get; set; }
    public bool IsAvailable => QuantityInStock > 0;
    public double Rating { get; set; }
}