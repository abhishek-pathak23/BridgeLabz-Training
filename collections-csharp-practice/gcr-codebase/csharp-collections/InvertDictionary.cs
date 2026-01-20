using System;
using System.Collections.Generic;

class InvertDictionary
{
    static void Main()
    {
        Console.WriteLine("Enter number of key-value pairs:");
        int n = int.Parse(Console.ReadLine());

        // Original dictionary
        Dictionary<string, int> original = new Dictionary<string, int>();

        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"Enter key #{i + 1}:");
            string key = Console.ReadLine();

            Console.WriteLine($"Enter value for key '{key}':");
            int value = int.Parse(Console.ReadLine());

            original[key] = value;
        }

        // Inverted dictionary: value -> list of keys
        Dictionary<int, List<string>> inverted = new Dictionary<int, List<string>>();

        foreach (var pair in original)
        {
            string key = pair.Key;
            int value = pair.Value;

            if (!inverted.ContainsKey(value))
            {
                inverted[value] = new List<string>();
            }

            inverted[value].Add(key);
        }

        // Display inverted dictionary
        Console.WriteLine("\nInverted Dictionary:");
        foreach (var pair in inverted)
        {
            Console.WriteLine(pair.Key + " = [" + string.Join(", ", pair.Value) + "]");
        }
    }
}
