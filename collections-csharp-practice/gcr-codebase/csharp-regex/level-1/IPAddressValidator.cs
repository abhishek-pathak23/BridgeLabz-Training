using System;
using System.Text.RegularExpressions;

// This class validates IPv4 address
class IPAddressValidator
{
    static void Main()
    {
        // Ask user to enter IP address
        Console.WriteLine("Enter IP Address:");
        string ipAddress = Console.ReadLine();

        // Regex for IPv4 (0–255 range)
        string pattern =
            @"^((25[0-5]|2[0-4]\d|1\d\d|[1-9]?\d)\.){3}" +
            @"(25[0-5]|2[0-4]\d|1\d\d|[1-9]?\d)$";

        if (Regex.IsMatch(ipAddress, pattern))
        {
            Console.WriteLine("Valid IP Address");
        }
        else
        {
            Console.WriteLine("Invalid IP Address");
        }
    }
}
