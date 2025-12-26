using System;

class ReplaceWordProg
{
    // Replaces a word manually
    static string ReplaceWord(string sentence, string oldWord, string newWord)
    {
        string result = "";                                       // creating the empty string
        int i = 0;

        while (i < sentence.Length)
        {
            if (i <= sentence.Length - oldWord.Length &&                     //checking the condition
                sentence.Substring(i, oldWord.Length) == oldWord)
            {
                result += newWord;
                i += oldWord.Length;
            }
            else
            {
                result += sentence[i];
                i++;
            }
        }
        return result;
    }

    static void Main()
    {
        Console.Write("Enter sentence: ");                // Taking inputs from the user
        string sentence = Console.ReadLine()!;
        Console.Write("Enter word to replace: ");
        string oldWord = Console.ReadLine()!;
        Console.Write("Enter new word: ");
        string newWord = Console.ReadLine()!;

        Console.WriteLine("Modified Sentence:");
        Console.WriteLine(ReplaceWord(sentence, oldWord, newWord));       //output
    }
}
