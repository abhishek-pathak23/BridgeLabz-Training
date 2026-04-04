using System;
using System.Text;

class ToUpperProg
{
    // Converting lowercase letters to uppercase
    public static string ToUpperManual(string text)
    {
        StringBuilder result = new StringBuilder();
        foreach (char c in text)
        {
            if (c >= 'a' && c <= 'z')
                result.Append((char)(c - 32));
            else
                result.Append(c); // Keep other characters same
        }
        return result.ToString();
    }

    static void Main()
    {
        Console.Write("Enter string: ");
        string input = Console.ReadLine()!;
        Console.WriteLine("Uppercase: " + ToUpperManual(input)); // output
    }
}
