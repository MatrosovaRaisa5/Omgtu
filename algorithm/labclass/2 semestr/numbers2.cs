using System;
using System.Collections.Generic;
using System.Collections;

class Program
{
    static void Main()
    {
        Queue<Tuple<string, DateTime, TimeSpan, int>> callDataQueue = new Queue<Tuple<string, DateTime, TimeSpan, int>>();


        callDataQueue.Enqueue(new Tuple<string, DateTime, TimeSpan, int>("12345678", new DateTime(2023, 4, 1), new TimeSpan(10, 30, 0), 5));
        callDataQueue.Enqueue(new Tuple<string, DateTime, TimeSpan, int>("87654321", new DateTime(2023, 4, 1), new TimeSpan(11, 0, 0), 10));
        callDataQueue.Enqueue(new Tuple<string, DateTime, TimeSpan, int>("12345678", new DateTime(2023, 4, 2), new TimeSpan(9, 0, 0), 7));

        Dictionary<DateTime, int> totalMinutesByDateDict = new Dictionary<DateTime, int>();
        Hashtable totalMinutesByDateHashTable = new Hashtable();

        while (callDataQueue.Count > 0)
        {
            var call = callDataQueue.Dequeue();

            if (totalMinutesByDateDict.ContainsKey(call.Item2))
            {
                totalMinutesByDateDict[call.Item2] += call.Item4;
            }
            else
            {
                totalMinutesByDateDict.Add(call.Item2, call.Item4);
            }

            if (totalMinutesByDateHashTable.ContainsKey(call.Item2))
            {
                totalMinutesByDateHashTable[call.Item2] = (int)totalMinutesByDateHashTable[call.Item2] + call.Item4;
            }
            else
            {
                totalMinutesByDateHashTable.Add(call.Item2, call.Item4);
            }
        }

        Console.WriteLine("Дата\t\tСуммарное время разговоров (dict)");
        
        foreach (var entry in totalMinutesByDateDict)
        {
            
            Console.WriteLine($"{entry.Key.ToShortDateString()}\t{entry.Value} мин.");
        }

        Console.WriteLine("\nДата\t\tСуммарное время разговоров (hashtable)");
        foreach (DictionaryEntry entry in totalMinutesByDateHashTable)
        {
            Console.WriteLine($"{((DateTime)entry.Key).ToShortDateString()}\t{entry.Value} мин.");
        }
    }
}