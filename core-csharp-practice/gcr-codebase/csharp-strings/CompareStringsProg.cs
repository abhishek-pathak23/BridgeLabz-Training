using System;

class CompareStringsProg
{
    // Method to manually compare two strings
    public static bool CompareStrings(string first, string second)
    {
        if (first.Length != second.Length) return false;

        for (int i = 0; i < first.Length; i++)
        {
            if (first[i] != second[i]) return false;
        }
        return true;
    }

    static void Main()
    {
        Console.Write("Enter first string: ");
        string str1 = Console.ReadLine()!; // Using  '!' to tell compiler it's not null

        Console.Write("Enter second string: ");
        string str2 = Console.ReadLine()!; // Same here the above logic

        bool result = CompareStrings(str1, str2);
        Console.WriteLine("Are they equal: " + result);
    }
}
