
using System;

class ConvertKilometersToMiles
{
    public static void Main(string[] args)
    {
        double distanceInKilometers = 10.8;

        double kilometerToMileFactor = 1.6;

        // Calculate the distance in miles
        double distanceInMiles = distanceInKilometers * kilometerToMileFactor;

        // Display the converted distance
        Console.WriteLine($"The distance {distanceInKilometers} km in miles is {distanceInMiles}");
    }
}
