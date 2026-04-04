using System;

class ToggleCaseProg
{
    // Toggling the case
    static string ToggleText(string text)
    {
        string result = "";

        foreach (char ch in text)                  // looping and checking the condition
        {
            if (ch >= 'a' && ch <= 'z')
                result += (char)(ch - 32);
            else if (ch >= 'A' && ch <= 'Z')
                result += (char)(ch + 32);
            else
                result += ch;
        }
        return result;
    }

    static void Main()
    {
        Console.Write("Enter a string: ");
        string input = Console.ReadLine()!;

        Console.WriteLine("Toggled Case: " + ToggleText(input));      //Output
    }
}
