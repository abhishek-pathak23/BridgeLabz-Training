using System;
using System.Text.RegularExpressions;

// This class extracts currency values
class CurrencyExtractor
{
    static void Main()
    {
        // Ask user for text
        Console.WriteLine("Enter text with currency values:");
        string text = Console.ReadLine();

        // Regex:
        // Optional $ sign, followed by numbers and decimals
        string pattern = @"\$?\s?\d+(\.\d{2})?";

        MatchCollection values = Regex.Matches(text, pattern);

        Console.WriteLine("Extracted Currency Values:");
        foreach (Match value in values)
        {
            // Remove extra spaces
            Console.WriteLine(value.Value.Trim());
        }
    }
}
