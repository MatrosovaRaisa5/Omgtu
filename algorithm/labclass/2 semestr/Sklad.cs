using System;
using System.Collections.Generic;
using System.Linq;

class Product
{
    public string Art { get; set; } 
    public string Name { get; set; }
    public string Category { get; set; } 
    public int Count { get; set; }
    public decimal Price { get; set; } 
    public string Sklad { get; set; }
}

class Program
{
    static void Main(string[] args)
    {
        var products = new List<Product>
        {
            new Product { Art = "001", Name = "Молоко", Category = "Молочные продукты", Count = 10, Price = 15.99m, Sklad = "Склад1" },
            new Product { Art = "002", Name = "Хлеб", Category = "Хлебобулочные изделия", Count = 20, Price = 30.99m, Sklad = "Склад2" },
            new Product { Art = "003", Name = "Колбаса", Category = "Колбасные изделия", Count = 15, Price = 10.99m, Sklad = "Склад1" },
            new Product { Art = "001", Name = "Молоко", Category = "Молочные продукты", Count = 10, Price = 15.99m, Sklad = "Склад2" },
        };

        Console.WriteLine("Запрос 1");
        var totalValuePerSklad = products.GroupBy(p => p.Sklad )
            .Select(g => new { Sklad = g.Key, TotalValue = g.Sum(p => p.Price * p.Count) });

        foreach (var sklad in totalValuePerSklad)
        {
            Console.WriteLine($"Склад: {sklad.Sklad}, Стоимость товаров: {sklad.TotalValue}");
        }

        Console.WriteLine("\nЗапрос 2");
        var maxPricePerCategory = products.GroupBy(p => p.Category)
            .Select(g => new { Category = g.Key, MaxPrice = g.Max(p => p.Price) });

        foreach (var category in maxPricePerCategory)
        {
            Console.WriteLine($"Категория: {category.Category}, Макс. цена: {category.MaxPrice}");
        }

        Console.WriteLine("\nЗапрос 3");
        var avgPricePerSklad = products.GroupBy(p => p.Sklad)
            .Select(g => new { Sklad = g.Key, AvgPrice = g.Average(p => p.Price) });
        
        foreach (var sklad in avgPricePerSklad)
        {
            Console.WriteLine($"Склад: {sklad.Sklad}, Средняя цена: {sklad.AvgPrice}");
        }

        var overallAvgPrice = products.Average(p => p.Price);
        Console.WriteLine($"Средняя цена по всем складам: {overallAvgPrice}");

        Console.WriteLine("\nЗапрос 4");
        var cheapestProduct = products.OrderBy(p => p.Price).FirstOrDefault();
        Console.WriteLine($"Самый дешёвый товар: {cheapestProduct?.Name}, Цена: {cheapestProduct?.Price}");

        Console.WriteLine("\nЗапрос 5");
        var skladWithMinValue = products.GroupBy(p => p.Sklad)
            .Select(g => new { Sklad = g.Key, TotalValue = g.Sum(p => p.Price * p.Count) })
            .OrderBy(g => g.TotalValue).FirstOrDefault();
        
        Console.WriteLine($"Склад с наименьшей стоимостью товаров: {skladWithMinValue?.Sklad}, Стоимость: {skladWithMinValue?.TotalValue}");

        var productsInSkladWithMinValue = products.Where(p => p.Sklad == skladWithMinValue.Sklad);
        
        foreach (var product in productsInSkladWithMinValue)
        {
            Console.WriteLine($"Артикул: {product.Art}, Название: {product.Name}, Категория: {product.Category}, Количество: {product.Count}, Цена: {product.Price}, Склад: {product.Sklad}");
        }
    }
}
