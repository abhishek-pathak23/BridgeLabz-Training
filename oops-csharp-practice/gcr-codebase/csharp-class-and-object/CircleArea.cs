using System;

class CircleArea
{
    // Variable to store radius
    double radius;

    // Method to calculate area
    void CalculateArea()
    {
        double area = 3.14 * radius * radius;
        Console.WriteLine("Area of Circle: " + area);
    }

    // Method to calculate circumference
    void CalculateCircumference()
    {
        double circumference = 2 * 3.14 * radius;
        Console.WriteLine("Circumference of Circle: " + circumference);
    }

    // Main method
    static void Main()
    {
        // Create object of SAME class name
        CircleArea c = new CircleArea();

        // Take user input
        Console.Write("Enter radius: ");
        c.radius = double.Parse(Console.ReadLine());

        // Call methods
        c.CalculateArea();
        c.CalculateCircumference();
    }
}
