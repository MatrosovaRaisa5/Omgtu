using System;
using System.Collections;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        var queue = new Queue<string>(); 
        queue.Enqueue("12345,2023-03-15,10:30,15");
        queue.Enqueue("12345,2023-03-16,11:00,5");
        queue.Enqueue("67890,2023-03-15,13:45,20");
        var phoneMinutesDictionary = new Dictionary<string, int>();
        var phoneMinutesHashtable = new Hashtable();

        while (queue.Count > 0)
        {
            var callData = queue.Dequeue().Split(',');
            var phoneNumber = callData[0];
            var duration = int.Parse(callData[3]);

            if (phoneMinutesDictionary.ContainsKey(phoneNumber))
            {
                phoneMinutesDictionary[phoneNumber] += duration;
            }
            
            else
            {
                phoneMinutesDictionary.Add(phoneNumber, duration);
            }

            if (phoneMinutesHashtable.ContainsKey(phoneNumber))
            {
                phoneMinutesHashtable[phoneNumber] = (int)phoneMinutesHashtable[phoneNumber] + duration;
            }
            
            else
            {
                phoneMinutesHashtable.Add(phoneNumber, duration);
            }
        }

        Console.WriteLine("Отчет из словаря (Dict):");
        foreach (var pair in phoneMinutesDictionary)
        {
            Console.WriteLine($"Номер: {pair.Key}, Минуты: {pair.Value}");
        }

        Console.WriteLine("\nОтчет из хеш-таблицы (Hash):");
        foreach (DictionaryEntry entry in phoneMinutesHashtable)
        {
            Console.WriteLine($"Номер: {entry.Key}, Минуты: {entry.Value}");
        }
    }
}