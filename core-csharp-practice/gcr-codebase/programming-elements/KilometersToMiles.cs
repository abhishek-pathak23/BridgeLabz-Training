using System; 
class KilometersToMiles
{
    static void Main()   // Entry point of the program
    {
        Console.Write("Enter distance in kilometers: ");
        double kilometers = Convert.ToDouble(Console.ReadLine()); // Read kilometers

        double miles = kilometers * 0.621371; // Conversion formula: 1 km = 0.621371 miles

        Console.WriteLine(kilometers + " kilometers = " + miles + " miles"); // Display result
    }
}
