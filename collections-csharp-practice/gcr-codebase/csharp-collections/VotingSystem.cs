using System;
using System.Collections.Generic;
using System.Linq;

class VotingSystem
{
    static void Main()
    {
        // Dictionary to store votes (candidate -> count)
        Dictionary<string, int> votes = new Dictionary<string, int>();

        // List to maintain order of first votes (LinkedHashMap equivalent)
        List<string> voteOrder = new List<string>();

        Console.WriteLine("Enter number of votes to cast:");
        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"Vote #{i + 1}: Enter candidate name:");
            string candidate = Console.ReadLine();

            // Add to votes dictionary
            if (votes.ContainsKey(candidate))
            {
                votes[candidate]++;
            }
            else
            {
                votes[candidate] = 1;
                voteOrder.Add(candidate); // maintain first vote order
            }
        }

        // Display results in insertion order (LinkedHashMap equivalent)
        Console.WriteLine("\n--- Results in Order of First Vote ---");
        foreach (string candidate in voteOrder)
        {
            Console.WriteLine($"{candidate} : {votes[candidate]} votes");
        }

        // Display results sorted by candidate name using SortedDictionary
        SortedDictionary<string, int> sortedVotes = new SortedDictionary<string, int>(votes);
        Console.WriteLine("\n--- Results Sorted by Candidate Name ---");
        foreach (var pair in sortedVotes)
        {
            Console.WriteLine($"{pair.Key} : {pair.Value} votes");
        }

        // Display winner(s)
        int maxVotes = votes.Values.Max();
        var winners = votes.Where(x => x.Value == maxVotes).Select(x => x.Key);

        Console.WriteLine("\n--- Winner(s) ---");
        foreach (var winner in winners)
        {
            Console.WriteLine($"{winner} with {maxVotes} votes");
        }
    }
}
