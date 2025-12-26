using System;

class MostFrequentChar
{
    // Finds most frequent character
    static char FindMostFrequent(string text)
    {
        int maxCount = 0;
        char result = text[0];

        for (int i = 0; i < text.Length; i++)       //looping and checking the condition
        {
            int count = 0;
            for (int j = 0; j < text.Length; j++)
            {
                if (text[i] == text[j])
                    count++;
            }
            if (count > maxCount)
            {
                maxCount = count;
                result = text[i];
            }
        }
        return result;
    }

    static void Main()
    {
        Console.Write("Enter a string: ");
        string input = Console.ReadLine()!;

        Console.WriteLine("Most Frequent Character: " + FindMostFrequent(input));  //printing the output
    }
}
