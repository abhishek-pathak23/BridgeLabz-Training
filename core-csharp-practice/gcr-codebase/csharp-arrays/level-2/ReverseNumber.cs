using System;

class ReverseNumber
{
    static void Main()
    {
        Console.Write("Enter a number: ");
        string? input = Console.ReadLine();

        if (!int.TryParse(input, out int number))
        {
            Console.WriteLine("Invalid input!");
            return;
        }

        int temp = Math.Abs(number); // handle negative numbers
        int count = temp.ToString().Length;
        int[] digits = new int[count];

        for (int i = 0; i < count; i++)
        {
            digits[i] = temp % 10;
            temp /= 10;
        }

        Console.Write("Reversed Number: ");
        for (int i = 0; i < count; i++)
            Console.Write(digits[i]);
        Console.WriteLine();
    }
}
