using System;
using System.Collections;
using System.Linq;

namespace DataStructuresApp
{
    class Program
    {
        static void Main(string[] args)
        {
            while(true){
            Console.WriteLine("Выберите:");
            Console.WriteLine("1. Array");
            Console.WriteLine("2. ArrayList");
            Console.WriteLine("3. SortedList");
            Console.WriteLine("4. Выход");
            Console.Write("Ваш выбор: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    ArrayClass.HandleArray();
                    break;
                case "2":
                    ArrayListClass.HandleArrayList();
                    break;
                case "3":
                    SortedListClass.HandleSortedList();
                    break;
                case "4":
                    return;
                default:
                    Console.WriteLine("Некорректный выбор.");
                    break;
            }
            }
        }
    }

     public static class ArrayClass
    {
        public static void HandleArray()
        {
            Console.WriteLine("Array, числа");
            Console.WriteLine("Введите количество элементов массива:");
            int kolvo = ogranichenie();
            
            while(kolvo <= 0)
            {Console.WriteLine("Введите число > 0, пожалуйста:");
            kolvo = ogranichenie();}
            Array array = Array.CreateInstance(typeof(int), kolvo);

            for (int i = array.GetLowerBound(0); i <= array.GetUpperBound(0); i++) 
            {
                Console.WriteLine($"Введите элемент массива под индексом {i}:");
                int chislo = ogranichenie();
                array.SetValue(chislo, i);
            }

            Console.WriteLine("Метод Sort:");
            Array.Sort(array);
            Display(array);
            
            int count = array.Length;
            Console.WriteLine($"Метод Count: {count}");
            
            Console.WriteLine("Метод BinarySearch");
            Console.WriteLine("Введите элемент");
            int k = ogranichenie();
            int res = Array.BinarySearch(array, k); 
            if (res < 0) { Console.WriteLine("\nЭлемент для поиска " + "({0}) не найден", k); } 
            else { Console.WriteLine("Элемент " + "({0}) найден под индексом {1}.",k, res); }
            
            Console.WriteLine("Метод Find");
            Console.WriteLine("Введите начало диапазона");
            int a = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите конец диапазонa:");
            int b = Convert.ToInt32(Console.ReadLine());
            int[] typedarray = (int[])array;
            Console.WriteLine(Array.Find<int>(typedarray,element => (element < b) & (element > a)));
            
            Console.WriteLine("Метод FindLast");
            Console.WriteLine(Array.FindLast<int>(typedarray,element => (element < b) & (element > a)));
            
            Console.WriteLine("Метод IndexOf");
            Console.WriteLine("Введите элемент для поиска");
            int p = ogranichenie();
            int nomer = Array.IndexOf (array, p);
            if (nomer==-1) {Console.WriteLine("Элемент не найден");}
            else {Console.WriteLine(nomer);}
            
            Console.WriteLine("Метод Reverse");
            Array.Reverse(array);      
            Display(array);
            
            Console.WriteLine("Метод Resize");
            Console.WriteLine("Введите размер нового массива");
            int ufff = ogranichenie();
            if (ufff<kolvo){
            Console.WriteLine("Введите размер массива больше исходного");
            ufff = ogranichenie();}
               
            Array.Resize<int>(ref typedarray, ufff);
            for (int i = kolvo; i < ufff; i++)
            {
                Console.WriteLine($"Введите элемент массива под индексом {i}:");
                typedarray[i] = ogranichenie();
            }
            Display(typedarray);
        }
        static void Display(Array array)
        {
            System.Collections.IEnumerator myEnumerator = array.GetEnumerator();
            int i = 0;
            int cols = array.GetLength(0);
            while (myEnumerator.MoveNext())
            { if (i < cols)
            { i++; }
            else
            { Console.WriteLine();
            i = 1; 
            }
            Console.Write("\t{0}", myEnumerator.Current);
            } 
            Console.WriteLine();
        }
           
           static int ogranichenie()
        {
        bool isNumeric = false;
        int vvod = 0;
        while (!isNumeric)
    {
            try
            {
                vvod = Convert.ToInt32(Console.ReadLine());
                isNumeric = true;
            }
            catch (FormatException)
            {
                Console.WriteLine("Неверный формат ввода. Введите целое число.");
            }
            catch (OverflowException)
            {
                Console.WriteLine("Введенное число слишком большое. Введите целое число в допустимом диапазоне.");
            }
        }
        return vvod;
    }
    }
public static class ArrayListClass
{
    public static void HandleArrayList()
    {
        Console.WriteLine("ArrayList, вводите слова");
        Console.WriteLine("Введите количество элементов массива:");
        int kolvo = ogranichenie();
        while(kolvo <= 0)
            {Console.WriteLine("Введите число > 0, пожалуйста:");
            kolvo = ogranichenie();}
        ArrayList larray = new ArrayList();
        for (int i = 0; i < kolvo; i++)
{
    Console.WriteLine("Введите элемент массива:");
    string ch = Console.ReadLine();

    while (String.IsNullOrEmpty(ch) || !ch.All(char.IsLetter))
    {
        Console.WriteLine("Введите только строчный элемент массива:");
        ch = Console.ReadLine();
    }
    larray.Add(ch);
}
        Console.WriteLine("ArrayList:");
        Display(larray);

        int count1 = larray.Count;
        Console.WriteLine($"Метод Count: {count1}");

        Console.WriteLine("Метод BinarySearch");
        Console.WriteLine("Введите элемент для поиска:");
        string k1 = Console.ReadLine();
        int res1 = larray.BinarySearch(k1);

        if (res1 < 0)
        {
            Console.WriteLine($"\nЭлемент для поиска {k1} не найден");
        }
        else
        {
            Console.WriteLine($"Элемент {k1} найден под индексом {res1}.");
        }
        Console.WriteLine("Метод Insert");
        Console.WriteLine("Введите элемент для вставки:");
        string el = Console.ReadLine();
        Console.WriteLine("Введите индекс:");
        int inx = ogranichenie();
        while (inx < 0 || inx >= count1)
        {
            Console.WriteLine($"Введите нормальный индекс! От 0 до {count1 - 1}");
            inx = Convert.ToInt32(Console.ReadLine());
        }
        larray.Insert(inx, el);
        Display(larray);

        Console.WriteLine("Метод Sort");
        larray.Sort();
        Display(larray);

        Console.WriteLine("Метод IndexOf");
        Console.WriteLine("Введите элемент для поиска:");
        string elem = Console.ReadLine();
        int index = larray.IndexOf(elem);
        if (index < 0)
        {
            Console.WriteLine($"Элемент {elem} не найден");
        }
        else
        {
            Console.WriteLine($"Индекс элемента {elem} в ArrayList: {index}");
        }
        
        Console.WriteLine("Метод Reverse");
        larray.Reverse();      
        Display(larray);
    }
    static void Display(IEnumerable myList)
    {
        foreach (var item1 in myList)
        {
            Console.Write(item1 + " ");
        }
        Console.WriteLine();
    }
    static int ogranichenie()
    {
        bool isNumeric = false;
        int vvod = 0;
        while (!isNumeric)
        {
            try
            {
                vvod = Convert.ToInt32(Console.ReadLine());
                isNumeric = true;
            }
            catch (FormatException)
            {
                Console.WriteLine("Неверный формат ввода. Введите целое число.");
            }
            catch (OverflowException)
            {
                Console.WriteLine("Введенное число слишком большое. Введите целое число в допустимом диапазоне.");
            }
        }
        return vvod;
    }
}
    public static class SortedListClass
    {
        public static void HandleSortedList()
        {
            Console.WriteLine("SortedList");
            Console.WriteLine("Введите количество элементов массива:");
            int kolvo = ogranichenie();
            while(kolvo <= 0)
            {Console.WriteLine("Введите число > 0, пожалуйста:");
            kolvo = ogranichenie();}
            SortedList slist = new SortedList();
            Console.WriteLine("Метод Add");
            for (int i = 0; i<kolvo; i++){
                Console.WriteLine("Введите ключ:");
                string skey = Console.ReadLine();
                Console.WriteLine("Введите значение:");
                string sval = Console.ReadLine();
                slist.Add(skey, sval);
            }
            Display(slist);
            Console.WriteLine("Метод IndexOfKey");
            Console.WriteLine("Введите ключ для поиска: ");
            string mykey = Console.ReadLine();
            int kindex = slist.IndexOfKey(mykey);
            if (kindex < 0)
            {
                Console.WriteLine($"Ключ {mykey} не найден");
            }
            else
            {
                Console.WriteLine($"Индекс ключа {mykey}: {kindex}");
            }
            Console.WriteLine("Метод IndexOfValue");
            Console.WriteLine("Введите значение для поиска: ");
            string myval = Console.ReadLine();
            int vindex = slist.IndexOfValue(myval);
            if (vindex < 0)
            {
                Console.WriteLine($"Ключ {myval} не найден");
            }
            else
            {
                Console.WriteLine($"Индекс ключа {myval}: {vindex}");
            }
            Console.WriteLine("Метод GetKey");
            Console.WriteLine("Введите индекс для поиска ключа");
            int kind = ogranichenie();
            while (kind<0 || kind > (kolvo-1))
            {
                Console.WriteLine("Введите число, >= 0 и  <=" + (kolvo-1));
                kind = ogranichenie();
            }
            Console.WriteLine("Ключ с индексом " + kind + ": " + slist.GetKey(kind));
            Console.WriteLine("Метод GetByIndex");
            Console.WriteLine("Введите индекс для поиска значения");
            int vind = ogranichenie();
            while (vind<0 || vind > (kolvo-1))
            {
                Console.WriteLine("Введите число, >= 0 и  <=" + (kolvo-1));
                vind = ogranichenie();
            }
            Console.WriteLine("Значение с индексом " + vind + ": " + slist.GetByIndex(vind));
        }
    static void Display(SortedList slist)
    {
        Console.WriteLine("\t-ключ-\t-значение-");
        for (int i = 0; i < slist.Count; i++)
        {
            Console.WriteLine("\t{0}:\t{1}", slist.GetKey(i), slist.GetByIndex(i));
        }
        Console.WriteLine();
    }
    static int ogranichenie()
    {
        bool isNumeric = false;
        int vvod = 0;
        while (!isNumeric)
        {
            try
            {
                vvod = Convert.ToInt32(Console.ReadLine());
                isNumeric = true;
            }
            catch (FormatException)
            {
                Console.WriteLine("Неверный формат ввода. Введите целое число.");
            }
            catch (OverflowException)
            {
                Console.WriteLine("Введенное число слишком большое. Введите целое число в допустимом диапазоне.");
            }
        }
        return vvod;
    }
    }
}