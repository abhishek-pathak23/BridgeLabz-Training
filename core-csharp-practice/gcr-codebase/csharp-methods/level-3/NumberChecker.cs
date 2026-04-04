using System;

class NumberChecker
{
    // Get digits of a number as array
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

    // Check Duck number
    public static bool IsDuck(int number)
    {
        int[] digits = GetDigits(number);
        foreach (int d in digits) if (d != 0) return true;
        return false;
    }

    // Check Armstrong number
    public static bool IsArmstrong(int number)
    {
        int[] digits = GetDigits(number);
        int sum = 0;
        foreach (int d in digits) sum += (int)Math.Pow(d, digits.Length);
        return sum == number;
    }

    // Find largest and second largest digit
    public static int[] LargestAndSecondLargest(int number)
    {
        int[] digits = GetDigits(number);
        int largest = int.MinValue, second = int.MinValue;
        foreach (int d in digits)
        {
            if (d > largest) { second = largest; largest = d; }
            else if (d > second && d != largest) second = d;
        }
        return new int[] { largest, second };
    }

    // Find smallest and second smallest digit
    public static int[] SmallestAndSecondSmallest(int number)
    {
        int[] digits = GetDigits(number);
        int smallest = int.MaxValue, second = int.MaxValue;
        foreach (int d in digits)
        {
            if (d < smallest) { second = smallest; smallest = d; }
            else if (d < second && d != smallest) second = d;
        }
        return new int[] { smallest, second };
    }

    static void Main()
    {
        Console.Write("Enter a number: ");
        int num = int.Parse(Console.ReadLine());

        // Display Duck and Armstrong checks
        Console.WriteLine("Duck Number: " + IsDuck(num));
        Console.WriteLine("Armstrong Number: " + IsArmstrong(num));

        int[] largest = LargestAndSecondLargest(num);
        Console.WriteLine("Largest: " + largest[0] + ", Second Largest: " + largest[1]);

        int[] smallest = SmallestAndSecondSmallest(num);
        Console.WriteLine("Smallest: " + smallest[0] + ", Second Smallest: " + smallest[1]);
    }
}
