using System;
using System.Collections.Generic;

class SetToSortedList
{
    static void Main()
    {
        Console.WriteLine("Enter elements of the set (comma separated):");
        string[] input = Console.ReadLine().Split(',');

        // Create HashSet to store unique elements
        HashSet<int> set = new HashSet<int>();
        foreach (string val in input)
        {
            set.Add(int.Parse(val.Trim()));
        }

        // Convert HashSet to List
        List<int> sortedList = new List<int>(set);

        // Sort the list in ascending order
        sortedList.Sort();

        // Display sorted list
        Console.WriteLine("\nSorted List:");
        Console.WriteLine(string.Join(", ", sortedList));
    }
}
