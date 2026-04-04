using System;

class SquareSideCalculation
{
    public static void Main(string[] args)
    {
        double perimeter;

        // Read perimeter from user input
        perimeter = Convert.ToDouble(Console.ReadLine());

        // Calculate side of the square
        double side = perimeter / 4;

        // Display the result
        Console.WriteLine(
            $"The length of the side is {side} whose perimeter is {perimeter}"
        );
    }
}
