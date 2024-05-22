using System;
using System.Collections.Generic;
using System.Linq;

public class Worker
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Position { get; set; }
    public decimal Salary { get; set; }
    public string ProductCategory { get; set; }
    public int  ProductCount { get; set; }
    public decimal ProductPrice { get; set; }

    public decimal ProductionValue => ProductCount * ProductPrice;
}

public class Program
{
    public static void Main(string[] args)
    {
        List<Worker> workers = new List<Worker>
        {
            new Worker { Id = 1, Name = "Иванов", Position = "Молочник", Salary = 21000, ProductCategory = "Молочные продукты", ProductCount = 100, ProductPrice = 300 },
            new Worker { Id = 2, Name = "Петров", Position = "Мясник", Salary = 35000, ProductCategory = "Колбасные изделия", ProductCount = 200, ProductPrice = 150 },
            new Worker { Id = 3, Name = "Сидорова", Position = "Пекарь", Salary = 30000, ProductCategory = "Хлебные изделия",  ProductCount = 150, ProductPrice = 400 },
            new Worker { Id = 4, Name = "Кузнецов", Position = "Рыбак", Salary = 25000, ProductCategory = "Рыба", ProductCount = 100, ProductPrice = 300 },
            new Worker { Id = 5, Name = "Петрова", Position = "Мясник", Salary = 34999, ProductCategory = "Колбасные изделия", ProductCount = 200, ProductPrice = 150 },
            new Worker { Id = 6, Name = "Картошкина", Position = "Кондитер", Salary = 39000, ProductCategory = "Кондитерские изделия",  ProductCount = 200, ProductPrice = 90 },
        };
        
        int workersWithLowerSalaryThanProduction = workers.Count(w => w.Salary < w.ProductionValue);
        Console.WriteLine($"1. Работники с зарплатой < сумма выработанной продукции: {workersWithLowerSalaryThanProduction}");

        var productionByCategory = workers
            .GroupBy(w => w.ProductCategory)
            .Select(g => new
            {
                Category = g.Key,
                TotalQuantity = g.Sum(w => w. ProductCount),
                TotalValue = g.Sum(w => w.ProductionValue),
            });
            
        Console.WriteLine("2. Продукция по категориям");
        foreach (var category in productionByCategory)
        {
            Console.WriteLine($"Категория {category.Category}: Количество = {category.TotalQuantity}, Значение = {category.TotalValue}");
        }
        
        decimal totalProductionValue = workers.Sum(w => w.ProductionValue);
        Console.WriteLine($"3. Общий суммарный объём произведённой продукции: {totalProductionValue}");
        
        int highIncomeWorkers = workers.Count(w => w.Salary > 0.5m * w.ProductionValue);
        Console.WriteLine($"4. Работники с зарплатой > 50%  от суммы производимого ими продукта: {highIncomeWorkers}");
    }
}
