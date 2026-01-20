using System;
using System.Collections.Generic;

class FrequencyOfElements
{
    static void Main()
    {
        Console.WriteLine("Enter strings (comma separated):");
        string[] input = Console.ReadLine().Split(',');

        // Dictionary to store element and its frequency
        Dictionary<string, int> frequencyMap = new Dictionary<string, int>();

        // Count frequency of each element
        foreach (string item in input)
        {
            string word = item.Trim();

            if (frequencyMap.ContainsKey(word))
            {
                frequencyMap[word] = frequencyMap[word] + 1;
            }
            else
            {
                frequencyMap[word] = 1;
            }
        }

        // Display result
        Console.WriteLine("\nFrequency of elements:");
        foreach (var pair in frequencyMap)
        {
            Console.WriteLine(pair.Key + " : " + pair.Value);
        }
    }
}
