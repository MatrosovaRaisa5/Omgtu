using System;
class HelloWorld
{
    static void Main()
    {
        int a, b;
        int modul, min, max;
        a = Convert.ToInt32(Console.ReadLine());
        b = Convert.ToInt32(Console.ReadLine());
        modul = Math.Abs(a - b);
        min = (a - modul + b) / 2;
        max = (a + modul + b) / 2;



        Console.WriteLine(min);
        Console.WriteLine(max);

    }
}