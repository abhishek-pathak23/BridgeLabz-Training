using System;
using System.Collections.Generic;

class SymmetricDifferenceSets
{
    static void Main()
    {
        // Read Set 1
        Console.WriteLine("Enter elements of Set 1 (comma separated):");
        string[] input1 = Console.ReadLine().Split(',');

        HashSet<int> set1 = new HashSet<int>();
        foreach (string val in input1)
        {
            set1.Add(int.Parse(val.Trim()));
        }

        // Read Set 2
        Console.WriteLine("Enter elements of Set 2 (comma separated):");
        string[] input2 = Console.ReadLine().Split(',');

        HashSet<int> set2 = new HashSet<int>();
        foreach (string val in input2)
        {
            set2.Add(int.Parse(val.Trim()));
        }

        // ----- Symmetric Difference -----
        // Elements present in either set but not in both
        HashSet<int> symmetricDifference = new HashSet<int>(set1);

        // Remove common elements
        symmetricDifference.IntersectWith(set2);
        HashSet<int> commonElements = new HashSet<int>(symmetricDifference);

        // Add all elements and then remove common ones
        symmetricDifference = new HashSet<int>(set1);
        symmetricDifference.UnionWith(set2);
        symmetricDifference.ExceptWith(commonElements);

        // Display Result
        Console.WriteLine("\nSymmetric Difference:");
        foreach (int item in symmetricDifference)
        {
            Console.Write(item + " ");
        }
    }
}
