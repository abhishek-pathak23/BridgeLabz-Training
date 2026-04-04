using System;

class UnitConverter1
{
    // Distance conversions
    public static double ConvertKmToMiles(double km) => km * 0.621371;
    public static double ConvertMilesToKm(double miles) => miles * 1.60934;
    public static double ConvertMetersToFeet(double meters) => meters * 3.28084;
    public static double ConvertFeetToMeters(double feet) => feet * 0.3048;

    // Entry point of the program
    static void Main()
    {
        Console.Write("Enter kilometers: ");
        double km = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine(km + " km = " + ConvertKmToMiles(km) + " miles");

        Console.Write("Enter miles: ");
        double miles = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine(miles + " miles = " + ConvertMilesToKm(miles) + " km");

        Console.Write("Enter meters: ");
        double meters = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine(meters + " meters = " + ConvertMetersToFeet(meters) + " feet");

        Console.Write("Enter feet: ");
        double feet = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine(feet + " feet = " + ConvertFeetToMeters(feet) + " meters");
    }
}
