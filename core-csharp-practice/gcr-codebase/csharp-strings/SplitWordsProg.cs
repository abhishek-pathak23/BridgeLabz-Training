using System;

class SplitWordsProg
{
    // Split string manually
    public static string[,] SplitWordsAndLengths(string text)
    {
        string[] words = new string[text.Length]; // Temporary storage
        int wordCount = 0;
        string word = "";

        for (int i = 0; i < text.Length; i++)
        {
            if (text[i] != ' ')
                word += text[i]; // Build word
            else
            {
                if (word != "")
                {
                    words[wordCount++] = word;
                    word = "";
                }
            }
        }
        if (word != "") words[wordCount++] = word; // Add last word

        string[,] result = new string[wordCount, 2];
        for (int i = 0; i < wordCount; i++)
        {
            result[i, 0] = words[i];
            result[i, 1] = words[i].Length.ToString();
        }
        return result;
    }

    static void Main()
    {
        Console.Write("Enter string: ");
        string input = Console.ReadLine()!;

        string[,] wordData = SplitWordsAndLengths(input);
        for (int i = 0; i < wordData.GetLength(0); i++)
        {
            Console.WriteLine($"Word: {wordData[i, 0]}, Length: {wordData[i, 1]}"); //Output
        }
    }
}
