using System;

class Car
{
    public int Year { get; set; }
    public string Colour { get; set; }
    public string Brand { get; set; }
    public string[] Name { get; set; }
    public int[] TechInspections { get; set; }
    public int EngineNumber { get; set; }

    public Car(int year, string colour, string brand, string[] name, int[] techInspections, int engineNumber)
    {
        Year = year;
        Colour = colour;
        Brand = brand;
        Name = name;
        TechInspections = techInspections;
        EngineNumber = engineNumber;
    }

    public void PrintCarInfo()
    {
        Console.WriteLine($"Год выпуска: {Year}, Цвет машины: {Colour}, Марка: {Brand}, Года прохождения техосмотра: {string.Join(", ", TechInspections)}, Номер двигателя: {EngineNumber}");
        Console.WriteLine("Владельцы машины: ");
        foreach (string name in Name)
        { Console.WriteLine(name); }

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

        InputCarsData();
        SearchByTechInspectionYear();
        SearchByEngineNumber();
        SearchOneOwnerCars();
    }

    static void InputCarsData()
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

            Console.Write("Введите количество владельцев: ");
            int nameCount = Convert.ToInt32(Console.ReadLine());
            string[] name = new string[nameCount];
            for (int j = 0; j < nameCount; j++)
            {
                Console.Write($"Введите ФИО владельца {j + 1}: ");
                name[j] = Console.ReadLine();
            }


            Console.Write("Введите количество годов прохождения техосмотра: ");
            int techInspectionsCount = Convert.ToInt32(Console.ReadLine());
            int[] techInspections = new int[techInspectionsCount];
            for (int j = 0; j < techInspectionsCount; j++)
            {
                Console.Write($"Введите год прохождения техосмотра {j + 1}: ");
                techInspections[j] = Convert.ToInt32(Console.ReadLine());
            }

            Console.Write("Введите номер двигателя: ");
            int engineNumber = Convert.ToInt32(Console.ReadLine());

            cars[i] = new Car(year, colour, brand, name, techInspections, engineNumber);
        }
    }

    static void SearchByEngineNumber()

    {
        Console.WriteLine("Введите номер двигателя для поиска");
        int number = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine($"Список владельцев машины с двигателем номер {number}:");
        foreach (Car car in cars)
        {
            if (car.EngineNumber == number)
            {
                foreach (string name in car.Name)
                { Console.WriteLine(name); }
            }
        }
    }

    static void SearchByTechInspectionYear()
    {
        Console.WriteLine("Введите год техосмотра по которому ищем машинку");
        int yearToSearch = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine($"Список машин, прошедших техосмотр в {yearToSearch} году:");
        foreach (Car car in cars)
        {
            foreach (int year in car.TechInspections)
            {
                if (year == yearToSearch)
                {
                    car.PrintCarInfo();
                    break;
                }
            }
        }
    }

    static void SearchOneOwnerCars()
    {
        Console.WriteLine("Список машин с одним владельцем:");
        foreach (Car car in cars)
        {
            if (car.TechInspections.Length == 1)
            {
                foreach (string name in car.Name)
                {
                    car.PrintCarInfo();
                }
            }
        }
    }
}