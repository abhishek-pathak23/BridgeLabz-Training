using System;

class SubstringProg
{
    // Creating substring manually from start to end
    public static string SubstringManual(string text, int start, int end)
    {
        string result = "";
        for (int i = start; i < end && i < text.Length; i++)
        {
            result += text[i]; // Append each character
        }
        return result;
    }

    static void Main()
    {
        Console.Write("Enter string: ");
        string input = Console.ReadLine()!;

        Console.Write("Enter start index: ");
        int start = int.Parse(Console.ReadLine()!);

        Console.Write("Enter end index: ");
        int end = int.Parse(Console.ReadLine()!);

        string substring = SubstringManual(input, start, end);
        Console.WriteLine("Substring: " + substring);           // final output
    }
}
