using System;  

class PowerCalculation
{
    static void Main()   
    {
        Console.Write("Enter the base number: ");
        double baseNum = Convert.ToDouble(Console.ReadLine()); // Read base

        Console.Write("Enter the exponent: ");
        double exponent = Convert.ToDouble(Console.ReadLine());

        double result = Math.Pow(baseNum, exponent); // Calculate power

        Console.WriteLine(baseNum + " raised to the power " + exponent + " = " + result); // Display result
    }
}
