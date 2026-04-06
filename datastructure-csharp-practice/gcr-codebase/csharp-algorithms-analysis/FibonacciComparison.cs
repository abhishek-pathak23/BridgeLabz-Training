using System;

class FibonacciComparison
{
    // Recursive Fibonacci - Slow for large N
    public static int FibonacciRecursive(int n)
    {
        if (n <= 1)
            return n;

        return FibonacciRecursive(n - 1) + FibonacciRecursive(n - 2);
    }

    // Iterative Fibonacci - Fast and efficient
    public static int FibonacciIterative(int n)
    {
        int a = 0, b = 1, sum = 0;

        for (int i = 2; i <= n; i++)
        {
            sum = a + b;
            a = b;
            b = sum;
        }

        return n == 0 ? 0 : b;
    }

    static void Main()
    {
        int n = 10;

        Console.WriteLine("Recursive Fibonacci: " + FibonacciRecursive(n));
        Console.WriteLine("Iterative Fibonacci: " + FibonacciIterative(n));
    }
}
