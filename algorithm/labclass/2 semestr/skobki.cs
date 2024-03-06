using System;
using System.Collections.Generic;

class Program
{
    static bool Scobki(string stroka)
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

        // Если стек пустой, скобки были сбалансированы
        return stack.Count == 0;
    }

    static void Main()
    {
        string stroka = "(а+{3б-4([})/2]";
        
        bool isskobki =Scobki(stroka);
        
        Console.WriteLine($"Правильно ли рассталвены скобки в выражении? {stroka}? {isskobki}");
    }
}
