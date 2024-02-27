using System;
class HelloWorld
{
    static void Main()
    {
        int kolvootr = 0;
        int kolvo3 = 0;
        int summ35 = 0;
        int prod = 1;
        for (int i = 0; i < 10; i++)
        {
            int s;
            s = Convert.ToInt32(Console.ReadLine());
            if (s < 0)
            { kolvootr += 1; }

            if (Math.Abs(s) % 10 == 3)
            { kolvo3 += 1; }

            if (Math.Abs(s) % 3 == Math.Abs(s) % 5)
            { summ35 += s; }

            if (Math.Abs(s) % 2 == 0 && s >= 0)
            { prod *= s; }
        }
        Console.WriteLine("Количество отрицательных чисел: " + kolvootr);
        Console.WriteLine("Количество чисел, оканчивающихся на 3: " + kolvo3);
        Console.WriteLine("Сумма чисел, которые в 3ичной и 5ичной системах оканчиваются одинаково: " + summ35);
        if (prod == 1) { Console.WriteLine("Произведение четных неотрицательных чисел: 0"); }
        else { Console.WriteLine("Произведение четных неотрицательных чисел: " + prod); }

    }
}