using System;
class Animal
{
    public string Name { get; set; }
    public int YearOfBirth { get; set; }
}

class Dog : Animal
{
    public string Color { get; set; }
    public string Breed { get; set; }

    public Dog(string name, int yearOfBirth, string color, string breed)
    {
        Name = name;
        YearOfBirth = yearOfBirth;
        Color = color;
        Breed = breed;
    }
}

class Cat : Animal
{
    public string Color { get; set; }
    public string Breed { get; set; }

    public Cat(string name, int yearOfBirth, string color, string breed)
    {
        Name = name;
        YearOfBirth = yearOfBirth;
        Color = color;
        Breed = breed;
    }

    public void ChangeBreed(string newBreed)
    {
        Breed = newBreed;
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("Сколько будет кошек?");
        int catCount = int.Parse(Console.ReadLine());

        Cat[] cats = new Cat[catCount];
        for (int i = 0; i < catCount; i++)
        {
            Console.WriteLine($"Введите имя кошки {i + 1}:");
            string name = Console.ReadLine();
            Console.WriteLine($"Введите год рождения кошки {i + 1}:");
            int yearOfBirth = int.Parse(Console.ReadLine());
            Console.WriteLine($"Введите окрас кошки {i + 1}:");
            string color = Console.ReadLine();
            Console.WriteLine($"Введите породу кошки {i + 1}:");
            string breed = Console.ReadLine();

            cats[i] = new Cat(name, yearOfBirth, color, breed);
        }

        Console.WriteLine("Сколько будет собак?");
        int dogCount = int.Parse(Console.ReadLine());

        Dog[] dogs = new Dog[dogCount];
        for (int i = 0; i < dogCount; i++)
        {
            Console.WriteLine($"Введите имя собаки {i + 1}:");
            string name = Console.ReadLine();
            Console.WriteLine($"Введите год рождения собаки {i + 1}:");
            int yearOfBirth = int.Parse(Console.ReadLine());
            Console.WriteLine($"Введите окрас собаки {i + 1}:");
            string color = Console.ReadLine();
            Console.WriteLine($"Введите породу собаки {i + 1}:");
            string breed = Console.ReadLine();

            dogs[i] = new Dog(name, yearOfBirth, color, breed);
        }

        Console.WriteLine("Введите породу, чтобы найти собаку:");
        string breedToFind = Console.ReadLine();
        Console.WriteLine("Собаки по породе " + breedToFind + ":");
        foreach (Dog dog in dogs)
        {
            if (dog.Breed == breedToFind)
            {
                Console.WriteLine("Имя: " + dog.Name + ", Год рождения: " + dog.YearOfBirth + ", Окрас: " + dog.Color);
            }
        }

        Console.WriteLine("Введите окрас, чтобы найти кошку:");
        string colorToFind = Console.ReadLine();
        Console.WriteLine("Кошки по окрасу " + colorToFind + ":");
        foreach (Cat cat in cats)
        {
            if (cat.Color == colorToFind)
            {
                Console.WriteLine("Имя: " + cat.Name + ", Год рождения: " + cat.YearOfBirth + ", Порода: " + cat.Breed);
            }
        }

        Console.ReadKey();
    }
}