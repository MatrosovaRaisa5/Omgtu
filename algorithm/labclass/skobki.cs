//скобочки
using System;
using System.Collections.Generic;

class Program
{
    static bool AreParenthesesBalanced(string expression)
    {
        Stack<char> stack = new Stack<char>();

        foreach (char ch in expression)
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

    static void Main()
    {
        string expression = "({(фффффвьлыоыло)авапвапва})";

        bool isBalanced = AreParenthesesBalanced(expression);

        Console.WriteLine($"Are parentheses balanced in the expression {expression}? {isBalanced}");
    }
}