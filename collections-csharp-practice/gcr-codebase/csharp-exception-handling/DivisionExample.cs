using System;

class DivisionExample
{
    static void Main()
    {
        try
        {
            Console.Write("Enter numerator: ");
            int num = int.Parse(Console.ReadLine());
            Console.Write("Enter denominator: ");
            int den = int.Parse(Console.ReadLine());
            Console.WriteLine("Result: " + (num / den));
        }
        catch (DivideByZeroException)
        {
            Console.WriteLine("Cannot divide by zero!");
        }
        catch (FormatException)
        {
            Console.WriteLine("Please enter numeric values only.");
        }
    }
}
