using System;

class NumberAnalyzer
{
    // Check if positive
    public static bool IsPositive(int number) => number >= 0;
    // Check if even
    public static bool IsEven(int number) => number % 2 == 0;
    // Compare two numbers
    public static int Compare(int a, int b)
    {
        if (a > b) return 1;
        if (a < b) return -1;
        return 0;
    }

    static void Main()
    {
        int[] numbers = new int[5];

        for (int i = 0; i < numbers.Length; i++)
        {
            Console.Write("Enter number: ");
            numbers[i] = Convert.ToInt32(Console.ReadLine());

            if (IsPositive(numbers[i]))
                Console.WriteLine(IsEven(numbers[i]) ? "Positive Even" : "Positive Odd");
            else
                Console.WriteLine("Negative");
        }

        int result = Compare(numbers[0], numbers[4]);
        Console.WriteLine("Comparison Result: " + result);
    }
}
