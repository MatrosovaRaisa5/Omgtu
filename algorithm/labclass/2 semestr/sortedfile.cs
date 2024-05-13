using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        MergeSortedFiles("1.txt", "2.txt", "3.txt");
    }
    
    static void MergeSortedFiles(string inputFile1, string inputFile2, string outputFile)
    {
        using (StreamReader reader1 = new StreamReader(inputFile1))
        using (StreamReader reader2 = new StreamReader(inputFile2))
        using (StreamWriter writer = new StreamWriter(outputFile))
        {
            string line1 = reader1.ReadLine();
            string line2 = reader2.ReadLine();
            
            while (line1 != null && line2 != null)
            {
                if (int.TryParse(line1, out int number1) && int.TryParse(line2, out int number2))
                {
                    if (number1 < number2)
                    {
                        writer.WriteLine(line1);
                        line1 = reader1.ReadLine();
                    }
                    else
                    {
                        writer.WriteLine(line2);
                        line2 = reader2.ReadLine();
                    }
                }
                else
                {
                    throw new InvalidDataException("Одна из строк это не число!!!");
                }
            }

            while (line1 != null)
            {
                writer.WriteLine(line1);
                line1 = reader1.ReadLine();
            }
            
            while (line2 != null)
            {
                writer.WriteLine(line2);
                line2 = reader2.ReadLine();
            }
        }
    }
}
