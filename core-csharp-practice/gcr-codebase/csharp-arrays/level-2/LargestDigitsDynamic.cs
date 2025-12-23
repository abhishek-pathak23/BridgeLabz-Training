using System;

class LargestDigitsDynamic
{
    static void Main()
    {
        Console.WriteLine("Enter a number:");
        string? input = Console.ReadLine();

        if (!long.TryParse(input, out long number))
        {
            Console.WriteLine("Invalid input! Please enter a valid number.");
            return;
        }

        number = Math.Abs(number); // handling negative numbers

        int maxDigit = 10; // initial array size
        int[] digits = new int[maxDigit];
        int index = 0;
        long temp = number;

        // Extract digits into array
        while (temp != 0)
        {
            if (index == maxDigit)
            {
                // Increase array size by 10
                maxDigit += 10;
                int[] tempArr = new int[maxDigit];

                // Copy existing digits to the new array
                for (int i = 0; i < digits.Length; i++)
                    tempArr[i] = digits[i];

                digits = tempArr; // assign new larger array
            }

            digits[index] = (int)(temp % 10);
            temp /= 10;
            index++;
        }

        // Finding  largest and second largest digits
        int largest = -1;
        int secondLargest = -1;

        for (int i = 0; i < index; i++)
        {
            if (digits[i] > largest)
            {
                secondLargest = largest;
                largest = digits[i];
            }
            else if (digits[i] > secondLargest && digits[i] != largest)
            {
                secondLargest = digits[i];
            }
        }

        Console.WriteLine($"Largest Digit: {largest}");
        Console.WriteLine($"Second Largest Digit: {secondLargest}");
    }
}
