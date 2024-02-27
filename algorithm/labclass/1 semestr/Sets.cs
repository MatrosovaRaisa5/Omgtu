using System;
class Program
{
    static void Main()
    {

        Console.WriteLine("Введите размер ступенчатого массива");
        int N = Convert.ToInt32(Console.ReadLine());
        int[][] ar = new int[N][];
        for (int i = 0; i < N; i++)
        {
            Console.WriteLine("Введите размер массива");
            int size = Convert.ToInt32(Console.ReadLine());

            int[] arr = new int[size];

            Console.WriteLine("Введите элементы массива");
            for (int k = 0; k < size; k++)
            {
                int a = Convert.ToInt32(Console.ReadLine());
                arr[k] = a;
            }
            ar[i] = arr;
        }

        int[] intersection = GetIntersection(ar);
        int[] union = GetUnion(ar);
        int[][] complements = GetComplements(ar, union);

        Console.WriteLine("Пересечение множеств:");
        foreach (int num in intersection)
        {
            Console.Write(num + " ");
        }
        Console.WriteLine();

        Console.WriteLine("Объединение:");
        foreach (int num in union)
        {
            Console.Write(num + " ");
        }
        Console.WriteLine();

        Console.WriteLine("Дополнение для каждого из множеств:");
        foreach (int[] complement in complements)
        {
            foreach (int num in complement)
            {
                Console.Write(num + " ");
            }
            Console.WriteLine();
        }
    }

    static int[] GetIntersection(int[][] ar)
    {
        if (ar.Length == 0) return new int[0];

        int[] result = ar[0];

        for (int i = 1; i < ar.Length; i++)
        {
            result = Intersect(result, ar[i]);
        }

        return result;
    }

    static int[] Intersect(int[] set1, int[] set2)
    {
        int[] intersection = new int[Math.Min(set1.Length, set2.Length)];
        int index = 0;

        for (int i = 0; i < set1.Length; i++)
        {
            for (int j = 0; j < set2.Length; j++)
            {
                if (set1[i] == set2[j])
                {
                    intersection[index] = set1[i];
                    index++;
                    break;
                }
            }
        }

        Array.Resize(ref intersection, index);
        return intersection;
    }

    static int[] GetUnion(int[][] ar)
    {
        int totalLength = 0;

        for (int i = 0; i < ar.Length; i++)
        {
            totalLength += ar[i].Length;
        }

        int[] union = new int[totalLength];
        int index = 0;

        for (int i = 0; i < ar.Length; i++)
        {
            for (int j = 0; j < ar[i].Length; j++)
            {
                if (!Contains(union, ar[i][j]))
                {
                    union[index] = ar[i][j];
                    index++;
                }
            }
        }

        Array.Resize(ref union, index);
        return union;
    }

    static bool Contains(int[] set, int num)
    {
        for (int i = 0; i < set.Length; i++)
        {
            if (set[i] == num)
            {
                return true;
            }
        }

        return false;
    }

    static int[][] GetComplements(int[][] ar, int[] union)
    {
        int[][] complements = new int[ar.Length][];

        for (int i = 0; i < ar.Length; i++)
        {
            complements[i] = Subtract(union, ar[i]);
        }

        return complements;
    }

    static int[] Subtract(int[] set1, int[] set2)
    {
        int[] difference = new int[set1.Length];
        int index = 0;

        for (int i = 0; i < set1.Length; i++)
        {
            if (!Contains(set2, set1[i]))
            {
                difference[index] = set1[i];
                index++;
            }
        }

        Array.Resize(ref difference, index);
        return difference;
    }
}