using System;

class AthleteRounds
{
    public static void Main(string[] args)
    {
        double side1 = Convert.ToDouble(Console.ReadLine());
        double side2 = Convert.ToDouble(Console.ReadLine());
        double side3 = Convert.ToDouble(Console.ReadLine());

        double perimeter = side1 + side2 + side3;

        double totalDistanceMeters = 5000; // 5 km = 5000 meters
        double rounds = totalDistanceMeters / perimeter;

        Console.WriteLine(
            $"The total number of rounds the athlete will run is {rounds} to complete 5 km"
        );
    }
}
