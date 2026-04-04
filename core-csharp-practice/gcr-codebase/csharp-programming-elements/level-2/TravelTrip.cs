using System;

class TravelTrip
{
    public static void Main(string[] args)
    {
        // Input traveler and cities
        string name = Console.ReadLine();
        string fromCity = Console.ReadLine();
        string viaCity = Console.ReadLine();
        string toCity = Console.ReadLine();

        // Input distances
        double distanceFromToVia = Convert.ToDouble(Console.ReadLine());
        double distanceViaToFinalCity = Convert.ToDouble(Console.ReadLine());

        // Input times
        int timeFromToVia = Convert.ToInt32(Console.ReadLine());
        int timeViaToFinalCity = Convert.ToInt32(Console.ReadLine());

        // Calculate totals
        double totalDistance = distanceFromToVia + distanceViaToFinalCity;
        int totalTime = timeFromToVia + timeViaToFinalCity;

        // Output results
        Console.WriteLine(
            $"The results of the trip are: Total Distance {totalDistance} km, Total Time {totalTime} minutes"
        );
    }
}
