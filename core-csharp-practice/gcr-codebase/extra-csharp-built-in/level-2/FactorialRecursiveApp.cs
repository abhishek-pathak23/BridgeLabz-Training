using System;

class FactorialRecursiveApp
{
    // Recursive factorial calculation
    static long Factorial(int num)
    {
        if (num == 0)
            return 1;
        return num * Factorial(num - 1);
    }

    static void Main()
    {
        Console.Write("Enter a number: ");
        int num = int.Parse(Console.ReadLine()!);               //User input

        Console.WriteLine("Factorial: " + Factorial(num));      //Output
    }
}
