using System;
using System.Text.RegularExpressions;

// This class extracts website links (URLs)
class LinkExtractor
{
    static void Main()
    {
        // Ask user to enter text
        Console.WriteLine("Enter text containing links:");
        string text = Console.ReadLine();

        // Regex for http and https links
        string pattern = @"https?://[a-zA-Z0-9./]+";

        // Find all links
        MatchCollection links = Regex.Matches(text, pattern);

        Console.WriteLine("Extracted Links:");
        foreach (Match link in links)
        {
            Console.WriteLine(link.Value);
        }
    }
}
