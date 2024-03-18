using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main()
        {
            SortedSet<int> set1 = new SortedSet<int>();
            SortedSet<int> set2 = new SortedSet<int>();
            SortedSet<int> set3 = new SortedSet<int>();
            Console.WriteLine("Введите количество элементов 1 множества: ");
            int n1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"Введите {n1} элементов множества: ");
             for (int i = 0; i < n1 ; i++)
            {
                int el1 = Convert.ToInt32(Console.ReadLine());
                set1.Add(el1);
            }
            Print(set1);
            Console.WriteLine("Введите количество элементов 2 множества: ");
            int n2 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"Введите {n2} элементов множества: ");
             for (int i = 0; i < n2 ; i++)
            {
                int el2 = Convert.ToInt32(Console.ReadLine());
                set2.Add(el2);
            }
            Print(set2);
            Console.WriteLine("Введите количество элементов 3 множества: ");
            int n3 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"Введите {n3} элементов множества: ");
             for (int i = 0; i < n3 ; i++)
            {
                int el3 = Convert.ToInt32(Console.ReadLine());
                set3.Add(el3);
            }
            Print(set3);
            
            var perset12 = set1.Intersect(set2);
            var perset123 = perset12.Intersect(set3);
            Console.WriteLine("Пересечение: ");
            foreach (int x in perset123)
                Console.Write($"{x} ");
                
            Console.Write("\n");    
            var obset12 = set1.Union(set2);
            var obset123 = obset12.Union(set3);
            Console.WriteLine("Объединение: ");
            foreach (int x in obset123)
                Console.Write($"{x} ");
            Console.Write("\n");
            
            var dopset1 = obset123.Except(set1); 
            Console.WriteLine("Дополнение 1 множества: ");
            foreach (int x in dopset1)
                Console.Write($"{x} ");
            Console.Write("\n");
            var dopset2 = obset123.Except(set2);  
            Console.WriteLine("Дополнение 2 множества: ");
            foreach (int x in dopset2)
                Console.Write($"{x} ");
            Console.Write("\n");
            var dopset3 = obset123.Except(set3); 
            Console.WriteLine("Дополнение 3 множества: ");
            foreach (int x in dopset3)
                Console.Write($"{x} ");
            Console.Write("\n");
        }
        static void Print(SortedSet<int> set)
        {
            foreach (int el in set)
                Console.Write(el + " ");
            Console.WriteLine("\n");
        }
    
    }
    
}