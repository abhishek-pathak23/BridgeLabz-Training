using System;
using System.Collections.Generic;

class RemoveDuplicatesProgram
{
    static void Main()
    {
        Console.WriteLine("Enter numbers (comma separated):");
        string[] input = Console.ReadLine().Split(',');

        // Original list
        List<int> list = new List<int>();
        foreach (string val in input)
        {
            list.Add(int.Parse(val.Trim()));
        }

        // HashSet to keep track of elements already seen
        HashSet<int> seen = new HashSet<int>();
        List<int> result = new List<int>();

        // Remove duplicates but keep original order
        foreach (int num in list)
        {
            if (!seen.Contains(num))
            {
                seen.Add(num);
                result.Add(num);
            }
        }

        Console.WriteLine("\nList after removing duplicates:");
        Console.WriteLine(string.Join(", ", result));
    }
}
