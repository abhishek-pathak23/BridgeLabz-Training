using System;

class QuotientRemainder
{
    public static void Main(string[] args)
    {
        int number1, number2;

        // Read two numbers from user input
        number1 = Convert.ToInt32(Console.ReadLine());
        number2 = Convert.ToInt32(Console.ReadLine());

        // Calculate quotient and remainder
        int quotient = number1 / number2;
        int remainder = number1 % number2;

        // Display the result
        Console.WriteLine(
            $"The Quotient is {quotient} and Remainder is {remainder} of two numbers {number1} and {number2}"
        );
    }
}
