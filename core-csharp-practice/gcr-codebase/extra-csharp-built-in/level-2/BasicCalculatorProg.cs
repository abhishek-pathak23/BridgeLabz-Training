using System;

class BasicCalculatorProg
{
    // Method to add two numbers
    static double Add(double a, double b) => a + b;

    // Method to subtract second number from first
    static double Subtract(double a, double b) => a - b;

    // Method to multiply two numbers
    static double Multiply(double a, double b) => a * b;

    // Method to divide first number by second
    static double Divide(double a, double b) => a / b;

    static void Main()
    {
        // Read first number 
        Console.Write("Enter first number: ");
        double num1 = double.Parse(Console.ReadLine()!);

        // Read second number
        Console.Write("Enter second number: ");
        double num2 = double.Parse(Console.ReadLine()!);

        Console.Write("Choose operation (+ - * /): ");
        char op = Console.ReadKey().KeyChar;
        Console.WriteLine();

        // Variable to store result
        double result = 0;

        // Perform operation based on user choice
        if (op == '+') result = Add(num1, num2);
        else if (op == '-') result = Subtract(num1, num2);
        else if (op == '*') result = Multiply(num1, num2);
        else if (op == '/') result = Divide(num1, num2);

        // Display final result
        Console.WriteLine("Result: " + result);
    }
}
