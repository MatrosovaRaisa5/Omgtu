using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

struct Person {
    public string Country;
    public string City;
    public int Year;

    public Person(string country, string city, int year) {
        Country = country;
        City = city;
        Year = year;
    }
}

class StructDemo {
    static void Main() {
        var path = @"T.txt";  
        var lines = File.ReadAllLines(path);
        if (lines.Length == 0) {
            Console.WriteLine("Файл пуст.");
            return;
        }

        List<Person> persons = new List<Person>();

        foreach (var line in lines)
        {
            var parts = line.Split(',');
            if(parts.Length != 3)
                continue; 
            if(int.TryParse(parts[2], out int year)) 
            {
                persons.Add(new Person(parts[0], parts[1], year));
            }
        }

        var sortYear = persons.OrderBy(p => p.Year).ToList();
        WriteToFile(sortYear, "SortYear.txt");

        var sortCity = persons.OrderBy(p => p.City).ToList();
        WriteToFile(sortCity, "SortCity.txt");

        Console.WriteLine("Введите название страны:");
        string country = Console.ReadLine();
        var filterCountry = persons.Where(p => p.Country.Equals(country, StringComparison.OrdinalIgnoreCase)).ToList();
        WriteToFile(filterCountry, "FilterCountry.txt");
    }

    
static void WriteToFile(List<Person> persons, string filePath) {
    using (var sw = new StreamWriter(filePath)) {
        foreach (var person in persons) {
            if (filePath.Contains("SortYear.txt")) {
                sw.WriteLine($"{person.Year}: {person.Country} {person.City}");
            } else if (filePath.Contains("SortCity.txt")) {
                sw.WriteLine($"{person.City}: {person.Year} {person.Country}");
            } else {
                sw.WriteLine($"{person.Country}, {person.City}, {person.Year}");
            }
        }
    }
}
}
