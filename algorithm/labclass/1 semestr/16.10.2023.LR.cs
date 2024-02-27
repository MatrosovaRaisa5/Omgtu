
//определение количества пар строк, состоящих из одинаковых элементов

using System;
using System.Linq;
class HelloWorld
{
    static void Main(string[] args)
    {
        int m = Convert.ToInt32(Console.ReadLine());
        int n = Convert.ToInt32(Console.ReadLine());
        int[,] mas = new int[m, n];
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                mas[i, j] = Convert.ToInt32(Console.ReadLine());
            }
        }

        int[,] rez = new int[m, 3];
        for (int i = 0; i < m; i++)
        {
            int sum = 0; int prod = 1; int countnul = 0;
            for (int j = 0; j < n; j++)
            {
                sum += mas[i, j];
                prod *= mas[i, j];
                if (mas[i, j] == 0) { countnul++; }


                rez[i, 0] = sum;
                rez[i, 1] = prod;
                rez[i, 2] = countnul;

            }
        }

        int count = 0;

        for (int x = 0; x < m - 1; x++)
        {
            for (int y = x + 1; y < m; y++)
            {
                bool flag = true;
                for (int k = 0; k < 3; k++)
                {
                    if (rez[x, k] != rez[y, k])
                    {
                        flag = false;
                        break;
                    }
                }
                if (flag == true)
                {
                    count += 1;
                }
            }
        }

        Console.WriteLine("5 задача " + count);

    }
}