using System;   

class VolumeOfCylinder
{
    static void Main()   // Entry point of the program
    {
        Console.Write("Enter radius: ");
        double radius = Convert.ToDouble(Console.ReadLine()); // Read radius

        Console.Write("Enter height: ");
        double height = Convert.ToDouble(Console.ReadLine()); // Read height

        double volume = Math.PI * radius * radius * height; // Volume formula

        Console.WriteLine("Volume of the cylinder = " + volume); // Display result
    }
}
