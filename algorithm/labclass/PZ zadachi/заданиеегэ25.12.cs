using System;

public class Program
{
    public static void Main()
    {
        for (int i = 106732567; i <= 152673836; i++)
        {
            if (Math.Pow((int)Math.Sqrt(i), 2) == i)
            {
                int count = 0;
                int highestDivisor = 0;
                int maxDivisor = 0;
                for (int j = 2; j <= (int)Math.Sqrt(i); j++)
                {
                    if (i % j == 0)
                    {
                        count++;
                        highestDivisor = j;
                        int otherDivisor = i / j;
                        if (j != otherDivisor)
                        {
                            count++;
                            highestDivisor = Math.Max(highestDivisor, otherDivisor);
                        }
                    }
                    maxDivisor = Math.Max(maxDivisor, highestDivisor);
                }
                if (count == 3)
                {
                    Console.WriteLine(i + " " + maxDivisor);
                }
            }
        }
    }
}