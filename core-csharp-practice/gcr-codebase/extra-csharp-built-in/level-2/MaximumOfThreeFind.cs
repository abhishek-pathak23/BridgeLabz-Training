using System;

class MaximumOfThreeFind
{
    // Finds maximum among three numbers
    static int FindMaximum(int a, int b, int c)
    {
        int max = a;
        if (b > max) max = b;
        if (c > max) max = c;
        return max;
    }

    static void Main()
    {
        Console.Write("Enter first number: ");                //Reading inputs
        int n1 = int.Parse(Console.ReadLine()!);

        Console.Write("Enter second number: ");
        int n2 = int.Parse(Console.ReadLine()!);

        Console.Write("Enter third number: ");
        int n3 = int.Parse(Console.ReadLine()!);

        Console.WriteLine("Maximum Number: " + FindMaximum(n1, n2, n3)); //outputs
    } 
}
