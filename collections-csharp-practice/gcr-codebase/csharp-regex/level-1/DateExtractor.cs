using System;
using System.Text.RegularExpressions;

// This class extracts dates in dd/mm/yyyy format
class DateExtractor
{
    static void Main()
    {
        // Take input text from user
        Console.WriteLine("Enter text containing dates:");
        string text = Console.ReadLine();

        // Regex for dd/mm/yyyy
        string pattern = @"\b\d{2}/\d{2}/\d{4}\b";

        // Find all dates
        MatchCollection dates = Regex.Matches(text, pattern);

        Console.WriteLine("Extracted Dates:");
        foreach (Match date in dates)
        {
            Console.WriteLine(date.Value);
        }
    }
}
