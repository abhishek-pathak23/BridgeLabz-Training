using System;

class DigitFrequency
{
    static void Main()
    {
        Console.Write("Enter a number: ");
        string? input = Console.ReadLine();

        if (!long.TryParse(input, out long number))
        {
            Console.WriteLine("Invalid input! Please enter a valid number.");
            return;
        }

        number = Math.Abs(number); // Handle negative numbers

        int[] frequency = new int[10]; // Frequency of digits from 0-9

        long temp = number;
        while (temp != 0)
        {
            int digit = (int)(temp % 10);
            frequency[digit]++;
            temp /= 10;
        }

        Console.WriteLine("\nDigit\tFrequency");
        for (int i = 0; i < 10; i++)
        {
            if (frequency[i] > 0)
                Console.WriteLine($"{i}\t{frequency[i]}");
        }
    }
}
