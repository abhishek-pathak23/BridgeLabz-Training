using System;
using System.Text.RegularExpressions;

// This class validates license plate number
class LicensePlateValidator
{
    static void Main()
    {
        // Take license plate input
        Console.WriteLine("Enter License Plate Number:");
        string plateNumber = Console.ReadLine();

        // Regex:
        // 2 uppercase letters + 4 digits
        string pattern = @"^[A-Z]{2}[0-9]{4}$";

        if (Regex.IsMatch(plateNumber, pattern))
        {
            Console.WriteLine("Valid License Plate Number");
        }
        else
        {
            Console.WriteLine("Invalid License Plate Number");
        }
    }
}
