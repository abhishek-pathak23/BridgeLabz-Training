using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

class WordFrequencyCounter
{
    static void Main()
    {
        Console.WriteLine("Enter path of the text file:");
        string filePath = Console.ReadLine();

        if (!File.Exists(filePath))
        {
            Console.WriteLine("File does not exist!");
            return;
        }

        string text = File.ReadAllText(filePath);

        // Convert to lowercase to make counting case-insensitive
        text = text.ToLower();

        // Remove punctuation using Regex
        text = Regex.Replace(text, @"[^\w\s]", "");

        // Split words by spaces
        string[] words = text.Split(new char[] { ' ', '\n', '\r', '\t' }, StringSplitOptions.RemoveEmptyEntries);

        // Dictionary to store word frequencies
        Dictionary<string, int> frequency = new Dictionary<string, int>();

        foreach (string word in words)
        {
            if (frequency.ContainsKey(word))
            {
                frequency[word]++;
            }
            else
            {
                frequency[word] = 1;
            }
        }

        // Display word frequencies
        Console.WriteLine("\nWord Frequencies:");
        foreach (var pair in frequency)
        {
            Console.WriteLine(pair.Key + " : " + pair.Value);
        }
    }
}
