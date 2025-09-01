namespace Linq;

class Program
{
    static void Main(string[] args)
    {
        Market market = new Market();
        // Задание 1: Получите список всех товаров категории "Books", у которых есть остаток на складе.
        List<Product> booksInStock = ProductHelper.GetBooksInStock(market);
        ProductHelper.DisplayBooksInStock(booksInStock);
        // Задание 2: Получите имена всех товаров, у которых рейтинг выше 4.5
        List<string> productsRatingList = ProductHelper.GetProductNamesByRating(market);
        ProductHelper.DisplayProductsNames(productsRatingList);
        //  Задание 3: Отсортируйте все товары по цене по убыванию.
        List<Product> priceByDesc = ProductHelper.GetProductsPriceByDescending(market);
        ProductHelper.DisplayProductsPriceByDescending(priceByDesc);
        // Задание 4: Получите среднюю цену всех товаров категории "Electronics".
        ProductHelper.CalculateAndDisplayAveragePrice(market);
        // Задание 5: Выведите первый товар, у которого нет остатков на складе.
        ProductHelper.DisplayProductWithoutStockInfo(market);
        // Задание 6: Проверьте, есть ли хоть один товар, у которого рейтинг меньше 4.0.
        ProductHelper.CheckProductWithLowRating(market);
        // Задание 7: Создайте список анонимных объектов: Name, Price, InStock, где InStock — это "Yes" или "No" в зависимости от наличия товара на складе.
        ProductHelper.DisplayProducts();
        // Задание 8: Группируйте все товары по категории и для каждой группы выведите:
        // - название категории,
        // - количество товаров,
        // - среднюю цену товаров в категории.
        ProductHelper.DisplayProductsByCategory(market);
        // Задание 9: Получите список всех уникальных категорий, отсортированных по алфавиту.
        ProductHelper.DisplayCategoriesByAlphabet(market);
        // Задание 10: Найдите 3 самых дорогих товара из всех доступных (в наличии) и выведите их названия и цену.
        ProductHelper.DisplayMostExpensiveProducts(market);
    }
}