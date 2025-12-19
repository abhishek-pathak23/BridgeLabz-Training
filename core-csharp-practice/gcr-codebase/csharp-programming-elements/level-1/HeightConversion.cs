using System;

class HeightConversion
{
    public static void Main(string[] args)
    {
        double heightInCm;

        // Read height in centimeters from user input
        heightInCm = Convert.ToDouble(Console.ReadLine());

        // Convert centimeters to inches
        double totalInches = heightInCm / 2.54;

        // Calculate feet and remaining inches
        int feet = (int)(totalInches / 12);
        double inches = totalInches % 12;

        Console.WriteLine(
            $"Your Height in cm is {heightInCm} while in feet is {feet} and inches is {inches}"
        );
    }
}
