using System;

class LargestDigitsFind
{
    static void Main()
    {
        Console.WriteLine("Enter a number:");

        // Read input 
        string? input = Console.ReadLine();
        if (!long.TryParse(input, out long number))
        {
            Console.WriteLine("Invalid input! Please enter a valid number.");
            return;
        }

        int maxDigit = 10;
        int[] digits = new int[maxDigit];
        int index = 0;

        long temp = Math.Abs(number); // handling negative numbers

        // Extracting digits
        while (temp != 0)
        {
            if (index == maxDigit)
            {
                // Increase array size by 10
                maxDigit += 10;
                int[] tempArr = new int[maxDigit];
                for (int i = 0; i < digits.Length; i++)
                    tempArr[i] = digits[i];
                digits = tempArr;
            }

            digits[index] = (int)(temp % 10);
            temp /= 10;
            index++;
        }

        int largest = 0, secondLargest = 0;

        // Finding largest and second largest digit
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
