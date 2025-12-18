using System;  

class RectanglePerimeter
{
    static void Main()   
    {
        Console.Write("Enter length of rectangle: ");
        double length = Convert.ToDouble(Console.ReadLine()); // Read length

        Console.Write("Enter width of rectangle: ");
        double width = Convert.ToDouble(Console.ReadLine()); // Read width

        double perimeter = 2 * (length + width); //formula

        Console.WriteLine("Perimeter of the rectangle = " + perimeter); // Display result
    }
}
