using System;

class NumberChecker
{
    // Method to check the number type
    public static int CheckNumber(int number)
    {
        if (number > 0) return 1;
        if (number < 0) return -1;
        return 0;
    }

    static void Main()
    {
        Console.Write("Enter a number: ");
        int number = Convert.ToInt32(Console.ReadLine());

        int result = CheckNumber(number);
        Console.WriteLine("Result: " + result);
    }
}
