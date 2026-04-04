using System;

class RemoveSpecificChar
{
    // Removes selected character from string
    static string RemoveChar(string text, char ch)
    {
        string result = "";             //empty string

        foreach (char c in text)
        {
            if (c != ch)
                result += c;
        }
        return result;
    }

    static void Main()
    {
        Console.Write("Enter a string: ");
        string text = Console.ReadLine()!;                   //User input
        Console.Write("Enter character to remove: ");
        char ch = Console.ReadKey().KeyChar;
        Console.WriteLine();

        Console.WriteLine("Modified String: " + RemoveChar(text, ch)); //printing the output
    }
}
