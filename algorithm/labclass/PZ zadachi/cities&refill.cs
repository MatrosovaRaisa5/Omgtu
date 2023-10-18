using System;
using System.Collections;

namespace ConsoleApplication5
{
    class Program
    {
        static void Main()
        {
            int n = Convert.ToInt32(Console.ReadLine()); 
            int k = Convert.ToInt32(Console.ReadLine());
            int[] goroda = new int[k];
            bool flag1 = false; 

            for (int i = 0; i < k; i++) 
                goroda[i] = int.Parse(Console.ReadLine());

            int r = k; 
            int minR = int.MaxValue; 
            int minI = 0; 
            for (int i = 1; i < k; i++) 
                r += goroda[i];

            for (int i = 0; i < goroda[goroda.Length - 1]; i++)  
            {
                bool flag2 = true; 
                foreach (var gor in goroda) 
                {
                    if (gor >= i) 
                        r-=1; 
                    else 
                        r+=1; 
                    if (Math.Abs(gor - i) < n) 
                        flag2 = false; 
                }
                if (flag2==true) 
                {
                    flag1 = true;
                    if (r < minR) 
                    {
                        minR = r; 
                        minI = i; 
                    }
                }
            }
            if (flag1==true) 
                Console.WriteLine("На километре " + minI + " минимальное расстояние " + minR);
            else 
                Console.WriteLine("Нет");
        }
    }
}