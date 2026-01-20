using System;
using System.Collections.Generic;

class ReverseListProgram
{
    static void Main()
    {
        Console.WriteLine("Enter numbers (comma separated):");
        string[] input = Console.ReadLine().Split(',');

        // ---------- ArrayList using List<int> ----------
        List<int> arrayList = new List<int>();
        foreach (string val in input)
        {
            arrayList.Add(int.Parse(val.Trim()));
        }

        // Reverse ArrayList using two-pointer technique
        int start = 0;
        int end = arrayList.Count - 1;

        while (start < end)
        {
            int temp = arrayList[start];
            arrayList[start] = arrayList[end];
            arrayList[end] = temp;

            start++;
            end--;
        }

        Console.WriteLine("\nReversed ArrayList:");
        Console.WriteLine(string.Join(", ", arrayList));


        // ---------- LinkedList ----------
        LinkedList<int> linkedList = new LinkedList<int>();

        foreach (int num in arrayList)
        {
            linkedList.AddLast(num);
        }

        // Reverse LinkedList without built-in methods
        LinkedList<int> reversedLinkedList = new LinkedList<int>();

        foreach (int item in linkedList)
        {
            // Add elements at the beginning
            reversedLinkedList.AddFirst(item);
        }

        Console.WriteLine("\nReversed LinkedList:");
        foreach (int item in reversedLinkedList)
        {
            Console.Write(item + " ");
        }
    }
}
