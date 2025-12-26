using System;

class GcdLcmCalculator
{
    // Calculates GCD using Euclidean method
    static int CalculateGCD(int a, int b)
    {
        while (b != 0)
        {
            int temp = b;
            b = a % b;
            a = temp;
        }
        return a;
    }

    // Calculates LCM using GCD
    static int CalculateLCM(int a, int b)
    {
        return (a * b) / CalculateGCD(a, b);
    }

    static void Main()
    {
        Console.Write("Enter first number: ");
        int x = int.Parse(Console.ReadLine()!);

        Console.Write("Enter second number: ");
        int y = int.Parse(Console.ReadLine()!);

        Console.WriteLine("GCD: " + CalculateGCD(x, y));          //Output
        Console.WriteLine("LCM: " + CalculateLCM(x, y));
    }
}
