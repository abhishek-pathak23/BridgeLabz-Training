using System;

class NumberChecker5
{
    // Find factors of number
    public static int[] GetFactors(int number)
    {
        int count = 0;
        for (int i = 1; i <= number; i++) if (number % i == 0) count++;
        int[] factors = new int[count];
        int idx = 0;
        for (int i = 1; i <= number; i++)
            if (number % i == 0) factors[idx++] = i;
        return factors;
    }

    // Greatest factor
    public static int GreatestFactor(int[] factors)
    {
        int max = int.MinValue;
        foreach (int f in factors) if (f > max) max = f;
        return max;
    }

    // Sum of factors
    public static int SumFactors(int[] factors)
    {
        int sum = 0;
        foreach (int f in factors) sum += f;
        return sum;
    }

    // Product of factors
    public static int ProductFactors(int[] factors)
    {
        int prod = 1;
        foreach (int f in factors) prod *= f;
        return prod;
    }

    // Product of cube of factors
    public static double ProductCubeFactors(int[] factors)
    {
        double prod = 1;
        foreach (int f in factors) prod *= Math.Pow(f, 3);
        return prod;
    }

    // Check perfect number
    public static bool IsPerfect(int number)
    {
        int[] factors = GetFactors(number);
        int sum = 0;
        foreach (int f in factors) if (f != number) sum += f;
        return sum == number;
    }

    // Check abundant number
    public static bool IsAbundant(int number)
    {
        int[] factors = GetFactors(number);
        int sum = 0;
        foreach (int f in factors) if (f != number) sum += f;
        return sum > number;
    }

    // Check deficient number
    public static bool IsDeficient(int number)
    {
        int[] factors = GetFactors(number);
        int sum = 0;
        foreach (int f in factors) if (f != number) sum += f;
        return sum < number;
    }

    // Check strong number
    public static bool IsStrong(int number)
    {
        int sum = 0, n = number;
        while (n > 0)
        {
            int digit = n % 10;
            int fact = 1;
            for (int i = 1; i <= digit; i++) fact *= i;
            sum += fact;
            n /= 10;
        }
        return sum == number;
    }

    static void Main()
    {
        Console.Write("Enter a number: ");
        int num = int.Parse(Console.ReadLine());
        int[] factors = GetFactors(num);

        Console.WriteLine("Factors: " + string.Join(",", factors));
        Console.WriteLine("Greatest Factor: " + GreatestFactor(factors));
        Console.WriteLine("Sum of Factors: " + SumFactors(factors));
        Console.WriteLine("Product of Factors: " + ProductFactors(factors));
        Console.WriteLine("Product of Cube of Factors: " + ProductCubeFactors(factors));
        Console.WriteLine("Perfect Number: " + IsPerfect(num));
        Console.WriteLine("Abundant Number: " + IsAbundant(num));
        Console.WriteLine("Deficient Number: " + IsDeficient(num));
        Console.WriteLine("Strong Number: " + IsStrong(num));
    }
}
