using System;

class FibonacciSeqGenerator
{
    // Prints Fibonacci series
    static void GenerateFibonacci(int terms)
    {
        int a = 0, b = 1;

        for (int i = 1; i <= terms; i++)           //Condition
        {
            Console.Write(a + " ");
            int next = a + b;
            a = b;
            b = next;
        }
    }

    static void Main()
    {
        Console.Write("Enter number of terms: ");
        int terms = int.Parse(Console.ReadLine()!);

        GenerateFibonacci(terms);                       //Calling the method
    }
}
