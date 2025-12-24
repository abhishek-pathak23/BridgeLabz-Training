using System;

class FactorOperations
{
    // Find factors of a number
    public static int[] FindFactors(int number)
    {
        int count = 0;
        for (int i = 1; i <= number; i++)
            if (number % i == 0) count++;

        int[] factors = new int[count];
        int index = 0;

        for (int i = 1; i <= number; i++)
            if (number % i == 0) factors[index++] = i;

        return factors;
    }

    // Sum of factors
    public static int FindSum(int[] factors)
    {
        int sum = 0;
        foreach (int f in factors) sum += f;
        return sum;
    }

    // Product of factors
    public static int FindProduct(int[] factors)
    {
        int product = 1;
        foreach (int f in factors) product *= f;
        return product;
    }

    // Sum of squares of factors
    public static double FindSumOfSquares(int[] factors)
    {
        double sum = 0;
        foreach (int f in factors) sum += Math.Pow(f, 2);
        return sum;
    }

    static void Main()
    {
        Console.Write("Enter number: ");
        int number = Convert.ToInt32(Console.ReadLine());

        int[] factors = FindFactors(number); // get factors

        Console.WriteLine("Factors:");
        foreach (int f in factors) Console.Write(f + " ");

        Console.WriteLine("\nSum is: " + FindSum(factors));
        Console.WriteLine("Product is: " + FindProduct(factors));
        Console.WriteLine("Sum of Squares is: " + FindSumOfSquares(factors));
    }
}
