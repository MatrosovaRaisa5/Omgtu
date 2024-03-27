using System;

namespace MathOperations
{
    public interface IMathOperations
    {
        double Add(double a, double b);
        double Subtract(double a, double b);
        double Multiply(double a, double b);
        double Divide(double a, double b);
        double SquareRoot(double a);
        double Sin(double a);
        double Cos(double a);
    }

    public class MathOperation : IMathOperations
    {
        public double Add(double a, double b) => a + b;
        public double Subtract(double a, double b) => a - b;
        public double Multiply(double a, double b) => a * b;
        public double Divide(double a, double b)
        {
            if (b == 0) throw new DivideByZeroException("Деление на ноль");
            return a / b;
        }
        public double SquareRoot(double a)
        {
            if (a < 0) { throw new ArgumentException("Корень из отриц.числа");}
            return Math.Sqrt(a);
        }
        public double Sin(double a) => Math.Sin(a);
        public double Cos(double a) => Math.Cos(a);
    }

    class Program
    {
        delegate double MathOperationDelegate(double a, double b = 0);
        
        static void Main(string[] args)
        {
            MathOperation mathOp = new MathOperation();
            MathOperationDelegate operation = null;

            try 
            {
                Console.WriteLine("Выберите операцию (+, -, *, /, sqrt, sin, cos):");
                string op = Console.ReadLine();
				
				switch (op)
                {
                    case "+":
                        operation = mathOp.Add;
                        break;
                    case "-":
                        operation = mathOp.Subtract;
                        break;
                    case "*":
                        operation = mathOp.Multiply;
                        break;
                    case "/":
                        operation = mathOp.Divide;
                        break;
                    case "sqrt":
                        operation = (a, b) => mathOp.SquareRoot(a);
                        break;
                    case "sin":
                        operation = (a, b) => mathOp.Sin(a);
                        break;
                    case "cos":
                        operation = (a, b) => mathOp.Cos(a);
                        break;
                    default:
                        Console.WriteLine("Нет такой операции");
                        return;
                }
				double num1 = 0;
				double num2 = 0;
				
                if (op == "sqrt" || op == "sin" || op == "cos")
                {
                    Console.WriteLine("1 число:");
                    num1 = Convert.ToDouble(Console.ReadLine());
                }

                if (op != "sqrt" && op != "sin" && op != "cos")
                {
                    Console.WriteLine("1 число:");
                    num1 = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("2 число:");
                    num2 = Convert.ToDouble(Console.ReadLine());
                }
				
                double result = operation.Invoke(num1, num2); 
                Console.WriteLine($"Ответ: {result}");
            
			} 
			catch (FormatException)
            {
                Console.WriteLine("Неправильный формат данных");
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }
    }
}