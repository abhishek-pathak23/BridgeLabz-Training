using System;

class DistanceConversion
{
    public static void Main(string[] args)
    {
        double distanceInFeet;

        // Read distance in feet from user input
        distanceInFeet = Convert.ToDouble(Console.ReadLine());

        // Convert distance to yards
        double distanceInYards = distanceInFeet / 3;

        // Convert distance to miles
        double distanceInMiles = distanceInYards / 1760;

        // Display the results
        Console.WriteLine(
            $"The distance in yards is {distanceInYards} and in miles is {distanceInMiles}"
        );
    }
}
