using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        string path = "1.txt"; 
        
        var charCounts = new Dictionary<char, int>();
        char mostFrequentChar = char.MinValue;
        int mostFrequentCount = 0;

        using (var reader = new StreamReader(path))
        {
            while (reader.Peek() >= 0) 
            {
                char c = (char)reader.Read();
              
                if (charCounts.ContainsKey(c))
                {
                    charCounts[c]++;
                }
                else
                {
                    charCounts[c] = 1;
                }

                if (charCounts[c] > mostFrequentCount)
                {
                    mostFrequentChar = c;
                    mostFrequentCount = charCounts[c];
                }
            }
        }

        int uniqueCharsCount = charCounts.Count(kv => kv.Value == 1);

        var charsList = charCounts.Keys.ToList();
        charsList.Sort();

        Console.WriteLine($"Символ, встречающийся чаще всего: {mostFrequentChar} - {mostFrequentCount} раза");
        Console.WriteLine($"Количество уникальных символов: {uniqueCharsCount}");
        Console.WriteLine("Список символов в алфавитном порядке:");
        foreach (char c in charsList)
        {
            Console.WriteLine(c);
        }
    }
}
