using System;

class KilometerToMile
{
    public static void Main(string[] args)
    {
        double km;
        double kilometerToMileFactor = 1.6;

        // Read kilometers from user input
        km = Convert.ToDouble(Console.ReadLine());

        // Calculate miles
        double miles = km / kilometerToMileFactor;

        Console.WriteLine(
            $"The total miles is {miles} mile for the given {km} km"
        );
    }
}
