using System;

class Program
{
    static void Main()
    {
        Console.Write("Введите количество строк: ");
        int m = Convert.ToInt32(Console.ReadLine());
        Console.Write("Введите количество столбцов: ");
        int n = Convert.ToInt32(Console.ReadLine());
        int[,] array = new int[m, n];
        Massiv(array);

        Console.WriteLine("Минимальный отрицательный элемент каждой строки: ");
        for (int x = 0; x < m; x++)
        {
            if (Minim(array, x, n) >= 0)
            {
                Console.WriteLine("Такого элемента не существует");
            }
            else
            {
                Console.WriteLine(Minim(array, x, n));
            }
        }
        Console.WriteLine("Количество элементов в каждом столбце, не равных минимальному в массиве: ");
        for (int x = 0; x < n; x++)
        {
            Console.WriteLine(Count(array, x, m, n));
        }
        Stroki(array, m, n);
    }

    static void Massiv(int[,] array)
    {
        int m = array.GetLength(0);
        int n = array.GetLength(1);

        Console.WriteLine("Введите элементы массива:");

        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                Console.Write($"Элемент [{i}, {j}]: ");
                array[i, j] = int.Parse(Console.ReadLine());
            }
        }
    }

    static int Minim(int[,] array, int x, int n)
    {
        int min = 100000;
        for (int y = 0; y < n; y++)
        {
            if (array[x, y] < min)
            {
                min = array[x, y];
            }
        }
        return min;
    }

    static int Count(int[,] array, int x, int m, int n)
    {
        int el = 10000;
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (array[i, j] < el)
                {
                    el = array[i, j];
                }
            }
        }
        int kolvo = 0;
        for (int y = 0; y < m; y++)
        {
            if (array[y, x] != el)
            {
                kolvo = kolvo + 1;
            }
        }
        return kolvo;
    }

    static void Stroki(int[,] array, int m, int n)
    {
        int maxSum = 0;
        int count = 0;

        for (int i = 0; i < m; i++)
        {
            int sum = 0;
            for (int j = 0; j < n; j++)
            {
                if (array[i, j] % 2 == 0)
                {
                    sum += array[i, j];
                }
            }
            if (sum > maxSum)
            {
                maxSum = sum;
                count = 1;
            }
            else if (sum == maxSum)
            {
                count++;
            }
        }

        if (count > 0)
        {
            for (int i = 0; i < m; i++)
            {
                int sum = 0;
                for (int j = 0; j < n; j++)
                {
                    if (array[i, j] % 2 == 0)
                    {
                        sum += array[i, j];
                    }
                }
                if (sum == maxSum)
                {
                    for (int j = 0; j < n; j++)
                    {
                        array[i, j] = 1;
                    }
                }
            }
        }

        Console.WriteLine("Массив с единицами вместо строк с наибольшей суммой четных элементов:");
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                Console.Write(array[i, j] + " ");
            }
            Console.WriteLine();
        }
    }
}