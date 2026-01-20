using System;
using System.Collections.Generic;

class RotateListProgram
{
    static void Main()
    {
        Console.WriteLine("Enter numbers (comma separated):");
        string[] input = Console.ReadLine().Split(',');

        // Store elements in list
        List<int> list = new List<int>();
        foreach (string val in input)
        {
            list.Add(int.Parse(val.Trim()));
        }

        Console.WriteLine("Enter rotation count:");
        int k = int.Parse(Console.ReadLine());

        // Handle rotation greater than list size
        k = k % list.Count;

        List<int> rotatedList = new List<int>();

        // Add elements from rotation index to end
        for (int i = k; i < list.Count; i++)
        {
            rotatedList.Add(list[i]);
        }

        // Add remaining elements from start
        for (int i = 0; i < k; i++)
        {
            rotatedList.Add(list[i]);
        }

        Console.WriteLine("\nRotated List:");
        Console.WriteLine(string.Join(", ", rotatedList));
    }
}
