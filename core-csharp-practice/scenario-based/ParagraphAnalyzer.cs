//Program does the following:
//Counts the number of words in a paragraph and finds the longest word.
//Checks if the paragraph is empty or contains only spaces.
//Replaces all occurrences of a given word with another word (case-insensitive).

using System;

class ParagraphAnalyzer
{
    string paragraph;

    // Constructor to initialize the paragraph
    ParagraphAnalyzer(string paragraph)
    {
        this.paragraph = paragraph;
    }

    // Check if paragraph is empty or contains only spaces
    bool IsEmptyParagraph()
    {
        for (int i = 0; i < paragraph.Length; i++)
            if (paragraph[i] != ' ')
                return false;
        return true;
    }

    // Count words in the paragraph
    int CountWords()
    {
        int wordCount = 0;
        for (int i = 0; i < paragraph.Length; i++)
            if (paragraph[i] != ' ' && (i == 0 || paragraph[i - 1] == ' '))
                wordCount++;
        return wordCount;
    }

    // Find the longest word
    string FindLongestWord()
    {
        string longest = "", current = "";
        for (int i = 0; i < paragraph.Length; i++)
        {
            if (paragraph[i] != ' ')
                current += paragraph[i];
            else
            {
                if (current.Length > longest.Length)
                    longest = current;
                current = "";
            }
        }
        if (current.Length > longest.Length)
            longest = current;
        return longest;
    }

    // Replace all occurrences of a word (case-insensitive)
    string ReplaceWord(string oldWord, string newWord)
    {
        string modified = "";
        int index = 0;

        while (index < paragraph.Length)
        {
            string temp = "";
            while (index < paragraph.Length && paragraph[index] != ' ')
                temp += paragraph[index++];

            // Case-insensitive comparison
            bool match = temp.Length == oldWord.Length;
            for (int j = 0; j < temp.Length && match; j++)
                if (char.ToLower(temp[j]) != char.ToLower(oldWord[j]))
                    match = false;

            modified += match ? newWord : temp;

            if (index < paragraph.Length) modified += paragraph[index]; // add space
            index++;
        }

        return modified;
    }

    // Main program logic
    static void Main()
    {
        Console.WriteLine("Enter a paragraph:");
        string para = Console.ReadLine();

        // Create object
        ParagraphAnalyzer analyzer = new ParagraphAnalyzer(para);

        if (analyzer.IsEmptyParagraph())
        {
            Console.WriteLine("Paragraph is empty or contains only spaces.");
            return;
        }

        Console.WriteLine("Number of words: " + analyzer.CountWords());
        Console.WriteLine("Longest word: " + analyzer.FindLongestWord());

        Console.Write("Word to replace: ");
        string oldWord = Console.ReadLine();
        Console.Write("New word: ");
        string newWord = Console.ReadLine();

        string modifiedParagraph = analyzer.ReplaceWord(oldWord, newWord);
        Console.WriteLine("Modified paragraph:");
        Console.WriteLine(modifiedParagraph);
    }
}
