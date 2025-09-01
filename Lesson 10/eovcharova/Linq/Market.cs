namespace Linq;

public class Market
{
    public List<Product> Products { get; set; }

    public Market()
    {
        Products = new List<Product>
        {
            new Product { Id = 1, Name = "C# in Depth", Category = "Books", Price = 45.5m, QuantityInStock = 5, Rating = 4.8 },
            new Product { Id = 2, Name = "Smartphone", Category = "Electronics", Price = 699.99m, QuantityInStock = 0, Rating = 4.3 },
            new Product { Id = 3, Name = "T-shirt", Category = "Clothes", Price = 19.99m, QuantityInStock = 20, Rating = 4.1 },
            new Product { Id = 4, Name = "Laptop", Category = "Electronics", Price = 1200m, QuantityInStock = 7, Rating = 4.7 },
            new Product { Id = 5, Name = "Blender", Category = "Electronics", Price = 85m, QuantityInStock = 12, Rating = 4.0 },
            new Product { Id = 6, Name = "Novel", Category = "Books", Price = 15m, QuantityInStock = 0, Rating = 4.6 },
            new Product { Id = 7, Name = "Jeans", Category = "Clothes", Price = 49.99m, QuantityInStock = 15, Rating = 3.8 },
            new Product { Id = 8, Name = "Monitor", Category = "Electronics", Price = 250m, QuantityInStock = 3, Rating = 4.4 },
            new Product { Id = 9, Name = "Sneakers", Category = "Clothes", Price = 89.99m, QuantityInStock = 10, Rating = 4.2 },
            new Product { Id = 10, Name = "Dictionary", Category = "Books", Price = 29.99m, QuantityInStock = 8, Rating = 4.9 }
        };
    }
}