using System;
using System.Text.RegularExpressions;

// This class extracts email addresses
class EmailExtractor
{
    static void Main()
    {
        // Take sentence input
        Console.WriteLine("Enter text containing emails:");
        string text = Console.ReadLine();

        // Simple email regex
        string pattern = @"[a-zA-Z0-9._]+@[a-zA-Z]+\.[a-zA-Z]{2,}";

        // Find all matches
        MatchCollection emails = Regex.Matches(text, pattern);

        Console.WriteLine("Extracted Email Addresses:");
        foreach (Match email in emails)
        {
            Console.WriteLine(email.Value);
        }
    }
}
