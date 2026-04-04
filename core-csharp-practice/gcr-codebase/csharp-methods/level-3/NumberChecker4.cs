using System;

class NumberChecker4
{
    // Check prime number
    public static bool IsPrime(int number)
    {
        if (number <= 1) return false;
        for (int i = 2; i <= Math.Sqrt(number); i++)
            if (number % i == 0) return false;
        return true;
    }

    // Check neon number
    public static bool IsNeon(int number)
    {
        int square = number * number;
        int sum = 0;
        while (square > 0)
        {
            sum += square % 10;
            square /= 10;
        }
        return sum == number;
    }

    // Check spy number
    public static bool IsSpy(int number)
    {
        int sum = 0, prod = 1;
        int n = number;
        while (n > 0)
        {
            int digit = n % 10;
            sum += digit;
            prod *= digit;
            n /= 10;
        }
        return sum == prod;
    }

    // Check automorphic number
    public static bool IsAutomorphic(int number)
    {
        int square = number * number;
        string s = square.ToString();
        string nStr = number.ToString();
        return s.EndsWith(nStr);
    }

    // Check buzz number
    public static bool IsBuzz(int number)
    {
        return number % 7 == 0 || number % 10 == 7;
    }

    static void Main()
    {
        Console.Write("Enter a number: ");
        int num = int.Parse(Console.ReadLine());

        Console.WriteLine("Prime: " + IsPrime(num));
        Console.WriteLine("Neon: " + IsNeon(num));
        Console.WriteLine("Spy: " + IsSpy(num));
        Console.WriteLine("Automorphic: " + IsAutomorphic(num));
        Console.WriteLine("Buzz: " + IsBuzz(num));
    }
}
