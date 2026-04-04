using System;

class NaturalNumberSum
{
    // Method to calculate sum
    public static int CalculateSum(int n)
    {
        int sum = 0;
        for (int i = 1; i <= n; i++)
        {
            sum += i;
        }
        return sum;
    }

    static void Main()
    {
        Console.Write("Enter n: ");
        int n = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Sum of natural numbers: " + CalculateSum(n));
    }
}
