using System;   

class AreaOfCircle
{
    static void Main() 
    {
        Console.Write("Enter Radius: ");
        double radius = Convert.ToDouble(Console.ReadLine()); // Read radius from user

        double area = Math.PI * radius * radius; // Area of circle formula

        Console.WriteLine("Area of the circle = " + area); // Display result
    }
}
