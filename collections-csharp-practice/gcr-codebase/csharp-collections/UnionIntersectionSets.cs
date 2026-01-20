using System;
using System.Collections.Generic;

class UnionIntersectionSets
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

        // ----- Union -----
        HashSet<int> unionSet = new HashSet<int>(set1);
        unionSet.UnionWith(set2);

        // ----- Intersection -----
        HashSet<int> intersectionSet = new HashSet<int>(set1);
        intersectionSet.IntersectWith(set2);

        // Display Results
        Console.WriteLine("\nUnion:");
        foreach (int item in unionSet)
        {
            Console.Write(item + " ");
        }

        Console.WriteLine("\n\nIntersection:");
        foreach (int item in intersectionSet)
        {
            Console.Write(item + " ");
        }
    }
}
