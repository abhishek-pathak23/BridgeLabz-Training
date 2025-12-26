using System;

class CountVowelsConsonants
{
    // Method counts vowels and consonants
    static void CountVC(string text, out int vowels, out int cons)
    {
        vowels = 0;
        cons = 0;

        for (int i = 0; i < text.Length; i++)
        {
            char ch = char.ToLower(text[i]);

            if (ch >= 'a' && ch <= 'z')                         // checking the condition
            {
                if (ch == 'a' || ch == 'e' || ch == 'i' || ch == 'o' || ch == 'u')
                    vowels++;
                else
                    cons++;
            }
        }
    }

    static void Main()
    {
        Console.Write("Enter a string: ");
        string input = Console.ReadLine()!;

        CountVC(input, out int v, out int c);            
        Console.WriteLine("Vowels: " + v);                // output
        Console.WriteLine("Cons: " + c);
    }
}
