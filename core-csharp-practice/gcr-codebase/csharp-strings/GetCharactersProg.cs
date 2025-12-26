using System;

class GetCharactersProg
{
    // Return all characters manually
    public static char[] GetCharacters(string text)
    {
        char[] chars = new char[text.Length];
        for (int i = 0; i < text.Length; i++)
        {
            chars[i] = text[i]; // Copy each character
        }
        return chars;
    }

    static void Main()
    {
        Console.Write("Enter string: ");
        string input = Console.ReadLine()!;

        char[] characters = GetCharacters(input);
        Console.WriteLine("Characters: " + string.Join(", ", characters)); // output
    }
}
