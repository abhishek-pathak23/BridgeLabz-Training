using System;

class CompareTwoStrings
{
    // Manual string comparison
    static int CompareStrings(string a, string b)
    {
        int min = Math.Min(a.Length, b.Length);

        for (int i = 0; i < min; i++)             //Looping
        {
            if (a[i] != b[i])
                return a[i] - b[i];
        }
        return a.Length - b.Length;
    }

    static void Main()
    {
        Console.Write("Enter first string: ");
        string s1 = Console.ReadLine()!;
        Console.Write("Enter second string: ");
        string s2 = Console.ReadLine()!;

        int result = CompareStrings(s1, s2);

        if (result < 0)                                             //checking the condition and printing the output
            Console.WriteLine($"\"{s1}\" comes before \"{s2}\"");
        else if (result > 0)
            Console.WriteLine($"\"{s1}\" comes after \"{s2}\"");
        else
            Console.WriteLine("Both strings are equal");
    }
}
