using System;

class LongestWordFinder
{
    // Finds longest word 
    static string FindLongestWord(string sentence)
    {
        string longest = "";
        string current = "";

        for (int i = 0; i <= sentence.Length; i++)        // looping and checking the condition for finding longest word
        {
            if (i == sentence.Length || sentence[i] == ' ')
            {
                if (current.Length > longest.Length)
                    longest = current;
                current = "";
            }
            else
            {
                current += sentence[i];
            }
        }
        return longest;
    }

    static void Main()
    {
        Console.Write("Enter a sentence: ");
        string input = Console.ReadLine()!;

        Console.WriteLine("Longest Word: " + FindLongestWord(input));            //Output
    }
}
