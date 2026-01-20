using System;
using System.Collections.Generic;

class CheckSetsEqual
{
    static void Main()
    {
        // Read first set
        Console.WriteLine("Enter elements of Set 1 (comma separated):");
        string[] input1 = Console.ReadLine().Split(',');

        HashSet<int> set1 = new HashSet<int>();
        foreach (string val in input1)
        {
            set1.Add(int.Parse(val.Trim()));
        }

        // Read second set
        Console.WriteLine("Enter elements of Set 2 (comma separated):");
        string[] input2 = Console.ReadLine().Split(',');

        HashSet<int> set2 = new HashSet<int>();
        foreach (string val in input2)
        {
            set2.Add(int.Parse(val.Trim()));
        }

        // Check if both sets have same elements
        bool areEqual = set1.SetEquals(set2);

        Console.WriteLine("\nAre both sets equal? " + areEqual);
    }
}
