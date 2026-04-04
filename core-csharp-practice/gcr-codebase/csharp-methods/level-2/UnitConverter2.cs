using System;

class UnitConverter2
{
    // Length conversions
    public static double ConvertYardsToFeet(double yards) => yards * 3;
    public static double ConvertFeetToYards(double feet) => feet * 0.333333;
    public static double ConvertMetersToInches(double meters) => meters * 39.3701;
    public static double ConvertInchesToMeters(double inches) => inches * 0.0254;
    public static double ConvertInchesToCm(double inches) => inches * 2.54;

    static void Main()
    {
        Console.Write("Enter yards: ");
        double yards = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine(yards + " yards = " + ConvertYardsToFeet(yards) + " feet");

        Console.Write("Enter feet: ");
        double feet = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine(feet + " feet = " + ConvertFeetToYards(feet) + " yards");

        Console.Write("Enter meters: ");
        double meters = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine(meters + " meters = " + ConvertMetersToInches(meters) + " inches");

        Console.Write("Enter inches: ");
        double inches = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine(inches + " inches = " + ConvertInchesToMeters(inches) + " meters");
        Console.WriteLine(inches + " inches = " + ConvertInchesToCm(inches) + " cm");
    }
}
