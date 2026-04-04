using System;

class BasicCalculator
{
    public static void Main(string[] args)
    {
        double number1, number2;

        // Read two numbers from user input
        number1 = Convert.ToDouble(Console.ReadLine());
        number2 = Convert.ToDouble(Console.ReadLine());

        // Perform arithmetic operations
        double addition = number1 + number2;
        double subtraction = number1 - number2;
        double multiplication = number1 * number2;
        double division = number1 / number2;

        // Display all results in a single print statement
        Console.WriteLine(
            $"The addition, subtraction, multiplication and division value of 2 numbers {number1} and {number2} is {addition}, {subtraction}, {multiplication}, and {division}"
        );
    }
}