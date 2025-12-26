using System;

class FormatExceptionProg
{
    static void Main()
    {
        // Take user input
        Console.Write("Enter a number: ");
        string? str = Console.ReadLine();

        try
        {
            int num = int.Parse(str!); // Will throw FormatException if input is not numeric
            Console.WriteLine("You entered: " + num);
        }
        catch (FormatException e)
        {
            Console.WriteLine("Caught FormatException: " + e.Message);
        }
    }
}
