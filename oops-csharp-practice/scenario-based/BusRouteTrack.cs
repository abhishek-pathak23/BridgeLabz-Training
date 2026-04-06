using System;

class BusRouteTrack
{
    static void Main()
    {
        int totalDistance = 0;   // stores total distance travelled

        Console.WriteLine("Bus Route Distance Tracker");

        while (true)
        {
            // Take distance from user
            Console.Write("Enter distance to next stop (km): ");
            int stopDistance = Convert.ToInt32(Console.ReadLine());

            // Add distance
            totalDistance = totalDistance + stopDistance;

            Console.WriteLine("Bus reached next stop.");
            Console.WriteLine("Total Distance: " + totalDistance + " km");

            // Ask passenger if they want to get off
            Console.Write("Do you want to get off here? (yes/no): ");
            string choice = Console.ReadLine();

            // Exit condition
            if (choice == "yes")
            {
                Console.WriteLine("You got off the bus.");
                break;
            }
        }

        Console.WriteLine("Journey Ended. Total Distance Travelled: " + totalDistance + " km");
    }
}
