using System;
using System.Text.RegularExpressions;

// This class checks hex color code
class HexColorValidator
{
    static void Main()
    {
        // Ask user for hex color
        Console.WriteLine("Enter Hex Color Code:");
        string hexColor = Console.ReadLine();

        // Regex:
        // # followed by exactly 6 hex characters
        string pattern = @"^#[0-9A-Fa-f]{6}$";

        if (Regex.IsMatch(hexColor, pattern))
        {
            Console.WriteLine("Valid Hex Color Code");
        }
        else
        {
            Console.WriteLine("Invalid Hex Color Code");
        }
    }
}
