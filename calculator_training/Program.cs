using System;

namespace SimpleCalculator
{
    // this is Interface for calculator operations
    public interface ICalculatorOperation
    {
        double Execute(double num1, double num2);
    }

    // Addition class  
    public class Addition : ICalculatorOperation
    {
        public double Execute(double num1, double num2)
        {
            return num1 + num2;
        }
    }

    // Subtraction class 
    public class Subtraction : ICalculatorOperation
    {
        public double Execute(double num1, double num2)
        {
            return num1 - num2;
        }
    }

    // Multiplication class  
    public class Multiplication : ICalculatorOperation
    {
        public double Execute(double num1, double num2)
        {
            return num1 * num2;
        }
    }

    // Division class  
    public class Division : ICalculatorOperation
    {
        public double Execute(double num1, double num2)
        {
            if (num2 == 0)
                throw new DivideByZeroException("Division by zero is not allowed.");
            return num1 / num2;
        }
    }

    // Calculator class to use the operations
    class Calculator
    {
        public double Calculate(double num1, double num2, ICalculatorOperation operation)
        {
            return operation.Execute(num1, num2);
        }
    }

    // Main program
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Simple Calculator\n");

            Console.Write("Enter the first number: ");
            double num1 = Convert.ToDouble(Console.ReadLine());

            Console.Write("Enter an operator (+, -, *, /): ");
            char op = Console.ReadKey().KeyChar;
            Console.WriteLine();

            Console.Write("Enter the second number: ");
            double num2 = Convert.ToDouble(Console.ReadLine());

            ICalculatorOperation operation = null;

            switch (op)
            {
                case '+':
                    operation = new Addition();
                    break;
                case '-':
                    operation = new Subtraction();
                    break;
                case '*':
                    operation = new Multiplication();
                    break;
                case '/':
                    operation = new Division();
                    break;
                default:
                    Console.WriteLine("Error: Invalid operator.");
                    return;
            }

            try
            {
                Calculator calculator = new Calculator();
                double result = calculator.Calculate(num1, num2, operation);
                Console.WriteLine($"\nResult: {num1} {op} {num2} = {result}");
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
