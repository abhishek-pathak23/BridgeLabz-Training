using System;
using System.Text.RegularExpressions;

// This class finds repeating words
class RepeatingWordFinder
{
    static void Main()
    {
        // Take sentence input
        Console.WriteLine("Enter a sentence:");
        string sentence = Console.ReadLine();

        // Regex:
        // Finds same word appearing twice in a row
        string pattern = @"\b(\w+)\s+\1\b";

        MatchCollection matches = Regex.Matches(sentence, pattern, RegexOptions.IgnoreCase);

        Console.WriteLine("Repeating Words:");
        foreach (Match match in matches)
        {
            Console.WriteLine(match.Groups[1].Value);
        }
    }
}
