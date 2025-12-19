using System;

class TriangleArea
{
    public static void Main(string[] args)
    {
        double baseInInches, heightInInches;

        // Read base and height from user input
        baseInInches = Convert.ToDouble(Console.ReadLine());
        heightInInches = Convert.ToDouble(Console.ReadLine());

        // Calculate area in square inches
        double areaInSquareInches = 0.5 * baseInInches * heightInInches;

        // Convert area to square centimeters
        double areaInSquareCm = areaInSquareInches * Math.Pow(2.54, 2);

        Console.WriteLine(
            $"The area of the triangle in square inches is {areaInSquareInches} and in square centimeters is {areaInSquareCm}"
        );
    }
}