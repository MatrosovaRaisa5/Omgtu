using System;
using System.Linq;
class HelloWorld
{
    static void Main()
    {
        int k = Convert.ToInt32(Console.ReadLine());
        int m = Convert.ToInt32(Console.ReadLine());
        int n = Convert.ToInt32(Console.ReadLine());

        int[] a = new int[k];
        for (int j = 0; j < k; j++)
        {
            a[j] = j + 1;
        }

        int i = 0;
        int start = i;
        while (a.Length > 1)
        {
            i = (i + m - 1) % a.Length;
            int[] temp = new int[a.Length - 1];
            Array.Copy(a, 0, temp, 0, i);
            Array.Copy(a, i + 1, temp, i, a.Length - i - 1);
            a = temp;
        }

        if (a[0] != n)
        {
            int r = a[0] - start;
            int p = n - r;
            if (p < 0)
            {
                p = k + p;
            }
            Console.WriteLine(p);
        }
        else
        {
            Console.WriteLine(start);
        }

    }

}