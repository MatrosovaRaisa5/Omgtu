using System;
using System.IO;

class Program
{
    static void Main()
    {
        string path = @"1.txt";
        string minSubstringLine = "";
        int minSubLength = int.MaxValue;

        foreach (string line in File.ReadLines(path))
        {
            int cMinLength = GetMinSubLength(line);
            if (cMinLength < minSubLength)
            {
                minSubLength = cMinLength;
                minSubstringLine = line;
            }
        }

        Console.WriteLine($"Строка с наименьшей длиной подпоследовательности 'а': {minSubstringLine}");
        Console.WriteLine($"Длина наименьшей подпоследовательности 'а': {minSubLength}");
    }
    
    static int GetMinSubLength(string line)
    {
        int minLength = int.MaxValue;
        int cLength = 0;
        bool isCounting = false;

        foreach (char c in line)
        {
            if (c == 'a') // английская 'а'!!!
            {
                if (!isCounting)
                {
                    isCounting = true;
                    cLength = 1;
                }
                else
                {
                    cLength++;
                }
            }
            else if (isCounting)
            {
                if (cLength < minLength && cLength > 0)
                {
                    minLength = cLength;
                }
                isCounting = false;
                cLength = 0;
            }
        }

        if (isCounting && cLength < minLength)
        {
            minLength = cLength;
        }

        return minLength == int.MaxValue ? 0 : minLength;
    }
}
