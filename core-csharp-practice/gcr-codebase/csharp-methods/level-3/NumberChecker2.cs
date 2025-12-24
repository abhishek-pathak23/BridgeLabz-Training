using System;

class NumberChecker2
{
    // Get digits of a number
    public static int[] GetDigits(int number)
    {
        int[] digits = new int[number.ToString().Length];
        for (int i = digits.Length - 1; i >= 0; i--)
        {
            digits[i] = number % 10;
            number /= 10;
        }
        return digits;
    }

    // Sum of digits
    public static int SumDigits(int number)
    {
        int sum = 0;
        foreach (int d in GetDigits(number)) sum += d;
        return sum;
    }

    // Sum of squares of digits
    public static int SumSquares(int number)
    {
        int sum = 0;
        foreach (int d in GetDigits(number)) sum += (int)Math.Pow(d, 2);
        return sum;
    }

    // Check Harshad number
    public static bool IsHarshad(int number)
    {
        return number % SumDigits(number) == 0;
    }

    // Display digit frequency
    public static void DigitFrequency(int number)
    {
        int[] digits = GetDigits(number);
        Console.WriteLine("Digit Frequencies:");
        for (int i = 0; i < digits.Length; i++)
        {
            int count = 0;
            foreach (int d in digits) if (d == digits[i]) count++;
            Console.WriteLine(digits[i] + " -> " + count);
        }
    }

    static void Main()
    {
        Console.Write("Enter a number: ");
        int num = int.Parse(Console.ReadLine());

        Console.WriteLine("Sum: " + SumDigits(num));
        Console.WriteLine("Sum of Squares: " + SumSquares(num));
        Console.WriteLine("Harshad Number: " + IsHarshad(num));
        DigitFrequency(num);
    }
}
