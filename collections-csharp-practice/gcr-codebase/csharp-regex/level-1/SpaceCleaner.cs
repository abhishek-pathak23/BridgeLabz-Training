using System;
using System.Text.RegularExpressions;

// This class replaces multiple spaces with one space
class SpaceCleaner
{
    static void Main()
    {
        // Take sentence input
        Console.WriteLine("Enter a sentence:");
        string sentence = Console.ReadLine();

        // Regex: one or more spaces
        string pattern = @"\s+";

        // Replace multiple spaces with single space
        string result = Regex.Replace(sentence, pattern, " ");

        Console.WriteLine("After Removing Extra Spaces:");
        Console.WriteLine(result);
    }
}
