using System;
using System.Text.RegularExpressions;

// This class is used to validate username
class UsernameValidator
{
    static void Main()
    {
        // Ask user to enter username
        Console.WriteLine("Enter Username:");
        string username = Console.ReadLine();

        // Regex rules:
        // Start with letter
        // Allowed: letters, numbers, underscore
        // Length between 5 to 15
        string pattern = @"^[A-Za-z][A-Za-z0-9_]{4,14}$";

        // Check username
        if (Regex.IsMatch(username, pattern))
        {
            Console.WriteLine("Valid Username");
        }
        else
        {
            Console.WriteLine("Invalid Username");
        }
    }
}
