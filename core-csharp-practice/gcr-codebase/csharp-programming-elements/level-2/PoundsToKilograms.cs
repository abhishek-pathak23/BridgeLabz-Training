using System;

class PoundsToKilograms
{
    public static void Main(string[] args)
    {
        double weightInPounds = Convert.ToDouble(Console.ReadLine());

        // Convert to kg
        double weightInKg = weightInPounds / 2.2;

        Console.WriteLine(
            $"The weight of the person in pounds is {weightInPounds} and in kg is {weightInKg}"
        );
    }
}
