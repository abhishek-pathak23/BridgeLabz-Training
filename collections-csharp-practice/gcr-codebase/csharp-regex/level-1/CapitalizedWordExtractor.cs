using System;
using System.Text.RegularExpressions;

// This class extracts capitalized words
class CapitalizedWordExtractor
{
    static void Main()
    {
        // Ask user for sentence
        Console.WriteLine("Enter a sentence:");
        string sentence = Console.ReadLine();

        // Regex:
        // Word starting with capital letter
        string pattern = @"\b[A-Z][a-z]*\b";

        MatchCollection words = Regex.Matches(sentence, pattern);

        Console.WriteLine("Capitalized Words:");
        foreach (Match word in words)
        {
            Console.WriteLine(word.Value);
        }
    }
}
