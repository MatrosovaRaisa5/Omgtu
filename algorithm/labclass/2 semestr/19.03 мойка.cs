using System;
using System.Collections.Generic;

class Car
{
    public string Name { get; private set; }

    public Car(string name)
    {
        Name = name;
    }

    public void Clean()
    {
        Console.WriteLine($"{Name} теперь чист!");
    }
}

class Garage
{
    public List<Car> Cars { get; private set; } = new List<Car>();

    public void AddCar(Car car)
    {
        Cars.Add(car);
    }

    public IEnumerable<Car> GetCars()
    {
        return Cars;
    }
}

class Wash
{
    public void CleanCar(Car car)
    {
        car.Clean();
    }
}

delegate void CleanCarDelegate(Car car);

class Program
{
    static void Main(string[] args)
    {
        Garage garage = new Garage();
        Console.WriteLine("Введите количество автомобилей:");
        int n = Convert.ToInt32(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"Введите название автомобиля {i + 1}:");
            string name = Console.ReadLine();
            garage.AddCar(new Car(name));
        }
        CleanCarDelegate cleanDelegate = (Car car) => car.Clean();
        
        foreach (var car in garage.GetCars())
        {
            cleanDelegate(car);
        }
    }
}