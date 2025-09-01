namespace Linq;

public class ProductHelper
{
    // Задание 1
    public static List<Product> GetBooksInStock(Market market)
    {
        return market.Products
            .Where(product => product.Category == "Books" && product.IsAvailable)
            .ToList();
    }
    public static void DisplayBooksInStock(List<Product> books)
    {
        foreach (var book in books)
        {
            Console.WriteLine($"Books: Name: {book.Name}, Price: {book.Price}, Quantity: {book.QuantityInStock}, Rating: {book.Rating}");
        }
        Console.WriteLine("* * * * * * * * * * * * * * * * * * * * * * *");
    }
    // Задание 2
    public static List<string> GetProductNamesByRating(Market market)
    {
        return market.Products
            .Where(product => product.Rating >= 4.5)
            .Select(product => product.Name)
            .ToList();
    }
    public static void DisplayProductsNames(List<string> productsNames)
    {
        foreach (var productName in productsNames)
        {
            Console.WriteLine($"Product with high rating: {productName}");
        }
        Console.WriteLine("* * * * * * * * * * * * * * * * * * * * * * *");
    }
    //  Задание 3
    public static List<Product> GetProductsPriceByDescending(Market market)
    {
        return market.Products
            .OrderByDescending(product => product.Price)
            .ToList();
    }
    public static void DisplayProductsPriceByDescending(List<Product> products)
    {
        foreach (var product in products)
        {
            Console.WriteLine($"Product name: {product.Name}, price {product.Price}, category: {product.Category}, quantity {product.QuantityInStock}, rating {product.Rating} ");
        }
        Console.WriteLine("* * * * * * * * * * * * * * * * * * * * * * *");
    }
    //  Задание 4
    public static decimal GetAveragePriceOfElectronics(Market market)
    {
        var electronicsProducts = market.Products
            .Where(product => product.Category == "Electronics")
            .ToList();
        
        var averagePrice = electronicsProducts.Average(product => product.Price);
        return averagePrice;
    }
    public static void DisplayElectronicsAveragePrice(decimal productsAveragePrice)
    {
        decimal averagePrice = productsAveragePrice;
        Console.WriteLine($"Electronics average price is: {averagePrice}");
        Console.WriteLine("* * * * * * * * * * * * * * * * * * * * * * *");
    }
    public static void CalculateAndDisplayAveragePrice(Market market)
    {
        try
        {
            decimal averagePrice = GetAveragePriceOfElectronics(market);
            DisplayElectronicsAveragePrice(averagePrice);
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine($"Error: {ex.Message} . There are no electronics available.");
        }
    }
    //  Задание 5
    public static Product? GetProductWithoutStock(Market market)
    {
        return market.Products.FirstOrDefault(product => product.IsAvailable == false);
    }
    public static void ProductWithoutStockInfo(Product product)
    {
        if (product != null)
        {
            Console.WriteLine($"Product without stock info: {product.Name}, category: {product.Category}");
            Console.WriteLine("* * * * * * * * * * * * * * * * * * * * * * *");
        }
    }
    public static void DisplayProductWithoutStockInfo(Market market)
    {
        var productWithoutStockInfo = GetProductWithoutStock(market);
        if (productWithoutStockInfo != null)
        {
            ProductWithoutStockInfo(productWithoutStockInfo);
        }
        else
        {
            Console.WriteLine($"There are no products without stock.");
        }
    }
    //  Задание 6
    public static bool HasProductWithLowRating(Market market)
    {
        return market.Products.Any(product => product.Rating < 4.0);
    }
    public static void CheckProductWithLowRating(Market market)
    {
        bool isProductWithLowRating = HasProductWithLowRating(market);
        Console.WriteLine(isProductWithLowRating 
            ? "There is at least one product with a rating lower than 4.0." 
            : "There are no products with a rating lower than 4.0.");
        
        Console.WriteLine("* * * * * * * * * * * * * * * * * * * * * * *");
    }
    // Задание 7
    public static void DisplayProducts()
    {
        var anonymousObject = new List<object>
        {
            new { Name = "Necklace", Price = 100.56m, inStock = "yes" },
            new { Name = "Doll", Price = 30m, inStock = "yes" },
            new { Name = "Car", Price = 10000m, inStock = "no" }
        };
        foreach (var item in anonymousObject)
        {
            dynamic obj = item;
            Console.WriteLine($"Name: {obj.Name}, Price: {obj.Price}, inStock: {obj.inStock}");
        }
        Console.WriteLine("* * * * * * * * * * * * * * * * * * * * * * *");
    }
    // Задание 8
    // для реализации метода создаем отдельный доп класс public class ProductCategoryInfo
    public static List<ProductCategoryInfo> GetProductsByCategory(Market market)
    {
        var productsByCategory = market.Products 
            .GroupBy(product => product.Category)
            .Select(group => new ProductCategoryInfo
            {
                Category = group.Key,
                Quantity = group.Sum(product => product.QuantityInStock),
                AveragePrice = group.Average(product => product.Price)
            })
            .ToList();
        return productsByCategory;
    }
    public static void DisplayProductsByCategory(Market market)
    {
        var resultByCategory = GetProductsByCategory(market);
        foreach (var item in resultByCategory)
        {
            Console.WriteLine($"Products category: {item.Category}, products quantity {item.Quantity}, products average price {item.AveragePrice}");
        }
        Console.WriteLine("* * * * * * * * * * * * * * * * * * * * * * *");
    }
    // Задание 9
    public static List<string> GetCategoriesList(Market market)
    {
        var categoryList = market.Products
            .Select(product => product.Category) 
            .Distinct() 
            .OrderBy(category => category) 
            .ToList(); 
        return categoryList;
    }
    public static void DisplayCategoriesByAlphabet(Market market)
    {
        var categoriesList = GetCategoriesList(market);
        foreach (var item in categoriesList)
        {
            Console.WriteLine($"Category: {item}");
        }
        Console.WriteLine("* * * * * * * * * * * * * * * * * * * * * * *");
    }
    // Задание 10
    public static List<Product> GetMostExpensiveProducts(Market market)
    {
        var mostExpensiveProducts = market.Products
            .Where(product => product.IsAvailable)
            .OrderByDescending(product => product.Price)
            .Take(3) 
            .ToList();
        return mostExpensiveProducts;
    }
    public static void DisplayMostExpensiveProducts(Market market)
    {
        var mostExpensiveProductsList = GetMostExpensiveProducts(market);
        if (mostExpensiveProductsList.Count > 0)
        {
            foreach (var item in mostExpensiveProductsList)
            {
                Console.WriteLine($"Product name: {item.Name}, price: {item.Price}");
            }
        }
        Console.WriteLine("* * * * * * * * * * * * * * * * * * * * * * *");
    }
}