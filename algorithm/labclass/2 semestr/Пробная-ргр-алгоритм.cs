using System;
using System.Collections.Generic;
class Program
{
    static void Main()
    {
        Menu menu = new Menu();
        menu.Run();
    }
}
class Menu
{      
    public void Run()
    {
        bool exit = false;
        while (!exit)
        {
            Console.WriteLine("Функции:");
            Console.WriteLine("1. Сведения об авторе");
            Console.WriteLine("2. Польская запись");
            Console.WriteLine("3. Скобочная последовательность");
            Console.WriteLine("4. Выход");

            Console.Write("\nВведите номер выбранной функции (1/2/3/4): ");
            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.WriteLine("Матросова Раиса Евгеньевна, ФИТиКС, ФИТ-232/2, 1 курс");
                    Console.WriteLine();
					Run();
                    break;
                case 2:
                    Console.WriteLine("Введите выражение в виде польской записи");
                    string strokaPolish = Console.ReadLine();
                    try
                    {
                        int res = Polsh(strokaPolish);
                        Console.WriteLine(res);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    Console.WriteLine();
                    Run();
                    break;
                case 3:
				    Console.WriteLine("Введите скобочное выражение");
                    string strokaSkobki = Console.ReadLine();
					string answ;
					bool isSkobki = Scobki(strokaSkobki);
                    if (isSkobki) {answ ="Скобки расставлены правильно";}
					else {answ="Скобки расставлены неправильно";}
                    Console.WriteLine($"Правильно ли расставлены скобки в выражении {strokaSkobki}? {answ}");
                    Console.WriteLine();
				    Run();
                    break;
                case 4:
                    exit = true;
                    Console.Clear();
                    Console.WriteLine("Чтобы вернуться, нажмите 0");
					Console.WriteLine();
                    int ent = Convert.ToInt32(Console.ReadLine());
                    if (ent == 0)
                    {
                        Run();
                    }
                    break;
                default:
                    Console.WriteLine("Неверный выбор");
                    Console.ReadKey();
                    break;
            }
        }
    }
    
    private static int Polsh(string stroka)
    {
        Stack<int> stack = new Stack<int>();
        string[] els = stroka.Split(' ');

        foreach (string el in els)
        {
            if (int.TryParse(el, out int num))
            {
                stack.Push(num);
            }
            else
            {
                if (stack.Count < 2)
                {
                    throw new ArgumentException("Недостаточно элементов");
                }

                int op2 = stack.Pop();
                int op1 = stack.Pop();
                int res = Operation(op1, op2, el);
                stack.Push(res);
            }
        }
        if (stack.Count != 1)
        {
            throw new ArgumentException("Недостаточно знаков");
        }
        return stack.Pop();
    }

    private static int Operation(int op1, int op2, string op)
    {
        switch (op)
        {
            case "+":
                return op1 + op2;
            case "-":
                return op1 - op2;
            case "*":
                return op1 * op2;
            case "/":
                if (op2 == 0)
                {
                    throw new DivideByZeroException("Нельзя делить на ноль");
                }
                return op1 / op2;
            default:
                throw new ArgumentException("Неправильный знак");
        }
    }

    private static bool Scobki(string stroka)
    {
        Stack<char> stack = new Stack<char>();

        foreach (char ch in stroka)
        {
            switch (ch)
            {
                case '{':
                case '(':
                case '[':
                    stack.Push(ch);
                    break;
                case '}':
                    if (stack.Count == 0 || stack.Pop() != '{')
                        return false;
                    break;
                case ')':
                    if (stack.Count == 0 || stack.Pop() != '(')
                        return false;
                    break;
                case ']':
                    if (stack.Count == 0 || stack.Pop() != '[')
                        return false;
                    break;
            }
        }
        return stack.Count == 0;
   }
}
