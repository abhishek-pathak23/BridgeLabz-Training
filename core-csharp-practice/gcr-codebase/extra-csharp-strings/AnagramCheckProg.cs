using System;

class AnagramCheckProg
{
    // Checks if two strings are anagrams
    static bool AreAnagrams(string a, string b)
    {
        if (a.Length != b.Length) return false;

        int[] freq = new int[256];

        foreach (char c in a) freq[c]++;
        foreach (char c in b) freq[c]--;

        foreach (int val in freq)
            if (val != 0) return false;

        return true;
    }

    static void Main()
    {
        Console.Write("Enter first string: ");
        string s1 = Console.ReadLine()!;                              // taking the input
        Console.Write("Enter second string: ");
        string s2 = Console.ReadLine()!;

        Console.WriteLine("Are Anagrams: " + AreAnagrams(s1, s2));    //output
    }
}
