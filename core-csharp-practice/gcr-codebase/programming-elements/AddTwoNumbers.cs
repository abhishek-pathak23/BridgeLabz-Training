using System;   

class AddTwoNumbers   // Class to add two numbers
{
    static void Main()  
    {
        Console.Write("Enter first number: ");
        int num1 = Convert.ToInt32(Console.ReadLine()); // Reads first number

        Console.Write("Enter second number: ");
        int num2 = Convert.ToInt32(Console.ReadLine()); // Reads second number

        int sum = num1 + num2; // Adds the two numbers

        Console.WriteLine("Sum = " + sum); // Prints the result
    }
}
