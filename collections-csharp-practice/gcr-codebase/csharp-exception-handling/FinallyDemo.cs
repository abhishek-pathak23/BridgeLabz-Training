using System;

class FinallyDemo
{
    static void Main()
    {
        try
        {
            Console.Write("Numerator: ");
            int num = int.Parse(Console.ReadLine());
            Console.Write("Denominator: ");
            int den = int.Parse(Console.ReadLine());

            Console.WriteLine("Result: " + (num / den));
        }
        catch (DivideByZeroException)
        {
            Console.WriteLine("Cannot divide by zero!");
        }
        finally
        {
            Console.WriteLine("Operation completed.");
        }
    }
}
