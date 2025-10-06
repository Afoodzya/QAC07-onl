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

class Program
{
    static void Main()
    {
        var items = new List<Product>
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

        // 1) Книги, которые есть на складе
        var availableBooks = from p in items
                             where p.Category == "Books" && p.QuantityInStock > 0
                             select p;

        // 2) Названия товаров с рейтингом выше 4.5
        var topRatedNames = items
            .Where(x => x.Rating > 4.5)
            .Select(x => x.Name);

        // 3) Сортировка всех товаров по цене (от дорогих к дешёвым)
        var priceDesc = from p in items
                        orderby p.Price descending
                        select p;

        // 4) Средняя цена для категории Electronics
        var avgElectronics = items
            .Where(x => x.Category == "Electronics")
            .Select(x => x.Price)
            .DefaultIfEmpty(0)
            .Average();

        // 5) Первый товар без остатков
        var outOfStock = items.FirstOrDefault(x => x.QuantityInStock == 0);

        // 6) Проверка, есть ли товары с рейтингом < 4.0
        bool hasLowRating = items.Any(x => x.Rating < 4.0);

        // 7) Новый список анонимных объектов
        var shortList = items
            .Select(x => new
            {
                x.Name,
                x.Price,
                InStock = x.QuantityInStock > 0 ? "Yes" : "No"
            });

        // 8) Группировка по категориям
        var grouped = from p in items
                      group p by p.Category into g
                      select new
                      {
                          Category = g.Key,
                          Count = g.Count(),
                          AvgPrice = g.Average(x => x.Price)
                      };

        // 9) Все категории без повторений, отсортированные по алфавиту
        var categories = items
            .Select(x => x.Category)
            .Distinct()
            .OrderBy(x => x);

        // 10) Топ 3 самых дорогих товаров, которые есть в наличии
        var top3 = items
            .Where(x => x.QuantityInStock > 0)
            .OrderByDescending(x => x.Price)
            .Take(3)
            .Select(x => new { x.Name, x.Price });

        // ===== Вывод результатов =====

        Console.WriteLine("1) Книги в наличии:");
        foreach (var b in availableBooks)
            Console.WriteLine($"   {b.Name}");

        Console.WriteLine("\n2) Товары с рейтингом > 4.5:");
        foreach (var n in topRatedNames)
            Console.WriteLine($"   {n}");

        Console.WriteLine("\n3) Все товары по цене (убывание):");
        foreach (var p in priceDesc)
            Console.WriteLine($"   {p.Name} - {p.Price:C}");

        Console.WriteLine($"\n4) Средняя цена Electronics: {avgElectronics:C}");

        Console.WriteLine($"\n5) Первый без остатков: {outOfStock?.Name}");

        Console.WriteLine($"\n6) Есть ли рейтинг < 4.0: {(hasLowRating ? "Да" : "Нет")}");

        Console.WriteLine("\n7) Краткий список:");
        foreach (var p in shortList)
            Console.WriteLine($"   {p.Name} - {p.Price:C} - In stock: {p.InStock}");

        Console.WriteLine("\n8) Группы по категориям:");
        foreach (var g in grouped)
            Console.WriteLine($"   {g.Category}: {g.Count} товаров, средняя цена {g.AvgPrice:C}");

        Console.WriteLine("\n9) Категории (уникальные):");
        foreach (var c in categories)
            Console.WriteLine($"   {c}");

        Console.WriteLine("\n10) Топ-3 дорогих в наличии:");
        foreach (var p in top3)
            Console.WriteLine($"   {p.Name} - {p.Price:C}");
    }
}
