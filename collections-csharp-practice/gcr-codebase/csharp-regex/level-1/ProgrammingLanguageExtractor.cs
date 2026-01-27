using System;
using System.Text.RegularExpressions;

// This class extracts programming language names
class ProgrammingLanguageExtractor
{
    static void Main()
    {
        // Take input text
        Console.WriteLine("Enter text:");
        string text = Console.ReadLine();

        // Regex for common programming languages
        string pattern = @"\b(Java|Python|JavaScript|Go|C|C\+\+|C#)\b";

        MatchCollection languages = Regex.Matches(text, pattern);

        Console.WriteLine("Programming Languages Found:");
        foreach (Match lang in languages)
        {
            Console.WriteLine(lang.Value);
        }
    }
}
