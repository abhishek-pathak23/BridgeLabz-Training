 
using System;

class EarthVolCalculation
{
    public static void Main(string[] args)
    {
        double radiusInKilometers = 6378;
        double pi = Math.PI;

        // Calculate volume in cubic kilometers
        double volumeInCubicKilometers = (4.0 / 3.0) * pi * Math.Pow(radiusInKilometers, 3);

        // Convert radius to miles for cubic miles calculation
        double radiusInMiles = radiusInKilometers * 0.621371;

        // Calculate volume in cubic miles
        double volumeInCubicMiles = (4.0 / 3.0) * pi * Math.Pow(radiusInMiles, 3);

        Console.WriteLine(
            $"The volume of earth in cubic kilometers is {volumeInCubicKilometers} and cubic miles is {volumeInCubicMiles}"
        );
    }
}
