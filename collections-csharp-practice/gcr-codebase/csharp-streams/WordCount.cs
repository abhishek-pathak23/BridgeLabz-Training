using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class WordCount
{
    static void Main()
    {
        Dictionary<string, int> words = new Dictionary<string, int>();

        using (StreamReader reader = new StreamReader("C:\\C sharp\\BridgeLabzDup\\BridgeLabzDup\\collections-csharp-practice\\gcr-codebase\\csharp-streams\\output.txt"))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                foreach (string word in line.Split(' ', '.', ',', ';'))
                {
                    if (string.IsNullOrWhiteSpace(word)) continue;

                    string key = word.ToLower();
                    words[key] = words.ContainsKey(key) ? words[key] + 1 : 1;
                }
            }
        }

        foreach (var w in words.OrderByDescending(x => x.Value).Take(5))
            Console.WriteLine($"{w.Key} : {w.Value}");
    }
}
