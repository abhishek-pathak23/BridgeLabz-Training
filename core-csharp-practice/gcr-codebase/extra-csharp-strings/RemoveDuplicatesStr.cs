using System;

class RemoveDuplicatesStr
{
    // Removes duplicate characters 
    static string RemoveDuplicateChars(string text)
    {
        string result = "";       // Empty String

        for (int i = 0; i < text.Length; i++)   // looping and checking the condition
        {
            if (!result.Contains(text[i]))
                result += text[i];
        }
        return result;
    }

    static void Main()
    {
        Console.Write("Enter a string: ");
        string input = Console.ReadLine()!;

        Console.WriteLine("After Removing Duplicates: " + RemoveDuplicateChars(input)); //Output
    }
}
