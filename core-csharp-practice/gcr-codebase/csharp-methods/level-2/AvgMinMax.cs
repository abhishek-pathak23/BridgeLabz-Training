using System;

class AvgMaxMin
{
    // Find average, min, max
    public static double[] FindAverageMinMax(int[] numbers)
    {
        int min = numbers[0], max = numbers[0], sum = 0;
        foreach (int n in numbers)
        {
            sum += n;
            min = Math.Min(min, n);
            max = Math.Max(max, n);
        }
        return new double[] { (double)sum / numbers.Length, min, max };
    }

    // Method to take user input and fill array
    public static int[] GetUserInputArray(int size)
    {
        int[] numbers = new int[size];
        for (int i = 0; i < size; i++)
        {
            Console.Write("Enter 4-digit number " + (i + 1) + ": ");
            numbers[i] = Convert.ToInt32(Console.ReadLine());
        }
        return numbers;
    }

    static void Main()
    {
        Console.Write("How many 4-digit numbers do you want to enter? ");
        int size = Convert.ToInt32(Console.ReadLine());

        int[] numbers = GetUserInputArray(size);
        double[] result = FindAverageMinMax(numbers);

        Console.WriteLine("Average: " + result[0]);
        Console.WriteLine("Min: " + result[1]);
        Console.WriteLine("Max: " + result[2]);
    }
}
