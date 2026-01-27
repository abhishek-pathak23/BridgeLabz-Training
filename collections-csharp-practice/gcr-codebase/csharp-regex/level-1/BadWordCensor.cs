using System;
using System.Text.RegularExpressions;

// This class censors bad words
class BadWordCensor
{
    static void Main()
    {
        // Take sentence from user
        Console.WriteLine("Enter a sentence:");
        string sentence = Console.ReadLine();

        // List of bad words (can be extended)
        string pattern = @"\b(damn|stupid)\b";

        // Replace bad words with ****
        string censoredText = Regex.Replace(sentence, pattern, "****", RegexOptions.IgnoreCase);

        Console.WriteLine("Censored Sentence:");
        Console.WriteLine(censoredText);
    }
}
