using System;
using System.Linq;
class HelloWorld
{
    static void Main()
    {
        int n = Convert.ToInt32(Console.ReadLine());
        int[] num = { };
        for (int i = 0; i < n; i++)
        {
            int a = Convert.ToInt32(Console.ReadLine());
            num = num.Append(a).ToArray();
        }
        int k = 0;
        for (int j = 0; j < n; j++)
        {
            if ((j > 0) && (num[j] < num[j - 1]))
            {
                k += 1;
            }
        }
        int count = 0;
        for (int z = 0; z < n; z++)
        {
            int m = 0;
            for (int x = 0; x < z; x++)
            {
                if ((num[x] > num[z]) && (z > 0))
                {
                    m += 1;
                    if (m == z)
                    {
                        count += 1;
                    }
                }
            }
        }
        int znak = 0;
        int numToRemove = 0;
        num = num.Where(val => val != numToRemove).ToArray();
        int length = num.Length;
        for (int b = 0; b < (length - 1); b++)
        {
            if ((num[b] > 0 && num[b + 1] < 0) | (num[b + 1] > 0 && num[b] < 0) | (num[b] == 0 && num[b - 1] < 0 && num[b + 1] > 0) | (num[b] == 0 && num[b + 1] < 0 && num[b - 1] > 0))
            {
                znak += 1;
            }
        }
        Console.WriteLine("Кол-во элементов, значения которых меньше предыдущего элемента: " + k);
        Console.WriteLine("Кол-во элементов, значения которых меньше всех предыдущих элементов:" + count);
        Console.WriteLine("Сколько раз происходит смена знаков:" + znak);
    }
}
