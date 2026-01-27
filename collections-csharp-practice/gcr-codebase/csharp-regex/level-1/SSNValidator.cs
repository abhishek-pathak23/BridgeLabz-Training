using System;
using System.Text.RegularExpressions;

// This class validates SSN format
class SSNValidator
{
    static void Main()
    {
        // Ask user to enter SSN
        Console.WriteLine("Enter SSN:");
        string ssn = Console.ReadLine();

        // Regex:
        // Format: 123-45-6789
        string pattern = @"^\d{3}-\d{2}-\d{4}$";

        if (Regex.IsMatch(ssn, pattern))
        {
            Console.WriteLine("Valid SSN");
        }
        else
        {
            Console.WriteLine("Invalid SSN");
        }
    }
}
