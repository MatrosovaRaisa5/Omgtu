using System;
class HelloWorld
{
    static void Main()
    {
        int k;
        int hour, min, sec;
        k = Convert.ToInt32(Console.ReadLine());
        hour = k / 3600;
        min = (k - hour * 3600) / 60;
        sec = k - (hour * 3600 + min * 60);
        Console.WriteLine(hour);
        Console.WriteLine(min);
        Console.WriteLine(sec);

    }
}
