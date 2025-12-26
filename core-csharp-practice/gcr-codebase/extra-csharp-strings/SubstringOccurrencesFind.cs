using System;

class SubstringOccurrencesFind
{
    // Counts how many times substring appears
    static int CountOccurrences(string text, string sub)
    {
        int count = 0;

        for (int i = 0; i <= text.Length - sub.Length; i++) //looping and checkcing the condition
        {
            int j;
            for (j = 0; j < sub.Length; j++)
            {
                if (text[i + j] != sub[j])
                    break;
            }
            if (j == sub.Length)
                count++;
        }
        return count;
    }

    static void Main()
    {
        Console.Write("Enter main string: ");
        string text = Console.ReadLine()!;                               //User input
        Console.Write("Enter substring: ");
        string sub = Console.ReadLine()!;

        Console.WriteLine("Occurrences: " + CountOccurrences(text, sub)); //output
    }
}
