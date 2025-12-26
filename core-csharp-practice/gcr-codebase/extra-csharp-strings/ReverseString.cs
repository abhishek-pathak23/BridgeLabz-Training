using System;

class ReverseString
{
    // Method reverses the string
    static string ReverseText(string text)
    {
        string result = "";                          // creating the empty string
        for (int i = text.Length - 1; i >= 0; i--)
        {
            result += text[i];
        }
        return result;
    }

    static void Main()
    {
        Console.Write("Enter a string: ");
        string input = Console.ReadLine()!;                         // taking user input

        Console.WriteLine("Reversed String: " + ReverseText(input)); //Output
    }
}
