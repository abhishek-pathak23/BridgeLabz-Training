using System;
using System.Text;

class ToLowerProg
{
    // Convert uppercase letters to lowercase
    public static string ToLowerManual(string text)
    {
        StringBuilder result = new StringBuilder();
        foreach (char c in text)
        {
            if (c >= 'A' && c <= 'Z')
                result.Append((char)(c + 32));
            else
                result.Append(c); // Keep other characters same
        }
        return result.ToString();
    }

    static void Main()
    {
        Console.Write("Enter string: ");
        string input = Console.ReadLine()!;
        Console.WriteLine("Lowercase: " + ToLowerManual(input)); //Output
    }
}
