using System;

class NumberChecker3
{
    // Get digits of number
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

    // Reverse an array
    public static int[] ReverseArray(int[] array)
    {
        int[] rev = new int[array.Length];
        for (int i = 0; i < array.Length; i++) rev[i] = array[array.Length - 1 - i];
        return rev;
    }

    // Check if arrays are equal
    public static bool AreArraysEqual(int[] a, int[] b)
    {
        if (a.Length != b.Length) return false;
        for (int i = 0; i < a.Length; i++) if (a[i] != b[i]) return false;
        return true;
    }

    // Check palindrome number
    public static bool IsPalindrome(int number)
    {
        int[] digits = GetDigits(number);
        return AreArraysEqual(digits, ReverseArray(digits));
    }

    // Check Duck number
    public static bool IsDuck(int number)
    {
        int[] digits = GetDigits(number);
        foreach (int d in digits) if (d != 0) return true;
        return false;
    }

    static void Main()
    {
        Console.Write("Enter a number: ");
        int num = int.Parse(Console.ReadLine());
        Console.WriteLine("Palindrome: " + IsPalindrome(num));
        Console.WriteLine("Duck Number: " + IsDuck(num));
    }
}
