using System;

class AthleteRoundsPark
{
    // Method to calculate total number of rounds
    public static double CalculateRounds(double side1, double side2, double side3)
    {
        double perimeter = side1 + side2 + side3;
        double totalDistance = 5000; // meters
        return totalDistance / perimeter;
    }

    static void Main()
    {
        Console.Write("Enter side 1: ");
        double side1 = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter side 2: ");
        double side2 = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter side 3: ");
        double side3 = Convert.ToDouble(Console.ReadLine());

        double rounds = CalculateRounds(side1, side2, side3);
        Console.WriteLine("Number of rounds required: " + rounds);
    }
}
