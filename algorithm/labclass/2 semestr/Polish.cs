using System;
using System.Collections;

class ReversePolish
{
    public static int Polsh(string stroka)
    {
        Stack stack = new Stack();
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

                int op2 = (int)stack.Pop();
                int op1 = (int)stack.Pop();
                int res = Operation(op1, op2, el);
                stack.Push(res);
            }
        }

        if (stack.Count != 1)
        {
            throw new ArgumentException("Недостаточно знаков");
        }

        return (int)stack.Pop();
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
                return op1 * op2;;
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

    static void Main()
    {
        Console.WriteLine("Введите выражение в виде польской записи");
        string stroka = Console.ReadLine();
        try
        {
            int res = Polsh(stroka);
            Console.WriteLine(res);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}