using System;

class Car
{
    public int year { get; set; }
    public string colour { get; set; }
    public string brand { get; set; }
    public string name { get; set; }
    public int tech { get; set; }

    public Car(int year1, string colour1, string brand1, string name1, int tech1)
    {
        year = year1;
        colour = colour1;
        brand = brand1;
        name = name1;
        tech = tech1;

    }

    public void PrintCarInfo()
    {
        Console.WriteLine($"Год выпуска: {year}, Цвет машины: {colour}, Марка: {brand}, ФИО владельца: {name}, Год прохождения техосмотра: {tech}");
    }
}


class Program
{
    static Car[] cars;
    static void Main()
    {
        Console.WriteLine("Введите количество задаваемых машинок: ");
        int n = Convert.ToInt32(Console.ReadLine());
        cars = new Car[n];

        InputCarData();
        SearchByYear();
        SearchByTech();
        SearchByBrand();
    }

    static void InputCarData()
    {
        for (int i = 0; i < cars.Length; i++)
        {
            Console.WriteLine($"Введите информацию о машинке {i + 1}:");

            Console.Write("Введите год выпуска: ");
            int year = Convert.ToInt32(Console.ReadLine());

            Console.Write("Введите цвет: ");
            string colour = Console.ReadLine();

            Console.Write("Введите марку: ");
            string brand = Console.ReadLine();

            Console.Write("Введите ФИО: ");
            string name = Console.ReadLine();

            Console.Write("Введите год прохождения техосмотра: ");
            int tech = Convert.ToInt32(Console.ReadLine());

            cars[i] = new Car(year, colour, brand, name, tech);
        }
    }

    static void SearchByYear()
    {
        Console.Write("Введите год  для поиска: ");
        int searchYear = Convert.ToInt32(Console.ReadLine());

        foreach (Car car in cars)
        {
            if (car.year == searchYear)
            {
                car.PrintCarInfo();
            }
        }
    }

    static void SearchByTech()
    {
        Console.Write("Введите год техосмотра для поиска: ");
        int searchTech = Convert.ToInt32(Console.ReadLine());

        foreach (Car car in cars)
        {
            if (car.tech == searchTech)
            {
                car.PrintCarInfo();
            }
        }
    }
    static void SearchByBrand()
    {
        Console.Write("Введите  марку для поиска: ");
        string searchBrand = Console.ReadLine();

        foreach (Car car in cars)
        {
            if (car.brand == searchBrand)
            {
                car.PrintCarInfo();
            }
        }
    }
    static void SearchByName()
    {
        Console.Write("Введите фио последнего владельца: ");
        string searchName = Console.ReadLine();

        foreach (Car car in cars)
        {
            if (car.name == searchName)
            {
                car.PrintCarInfo();
            }
        }
    }
}