using System;
using System.Collections.Generic;

class NthElementFromEnd
{
    static void Main()
    {
        // Create LinkedList
        LinkedList<string> list = new LinkedList<string>();

        Console.WriteLine("Enter elements (comma separated):");
        string[] input = Console.ReadLine().Split(',');

        // Add elements to LinkedList
        foreach (string val in input)
        {
            list.AddLast(val.Trim());
        }

        Console.WriteLine("Enter N:");
        int n = int.Parse(Console.ReadLine());

        // Two-pointer approach
        LinkedListNode<string> first = list.First;
        LinkedListNode<string> second = list.First;

        // Move first pointer N steps ahead
        for (int i = 0; i < n; i++)
        {
            if (first == null)
            {
                Console.WriteLine("N is greater than the number of elements");
                return;
            }
            first = first.Next;
        }

        // Move both pointers until first reaches end
        while (first != null)
        {
            first = first.Next;
            second = second.Next;
        }

        Console.WriteLine("\nNth element from the end: " + second.Value);
    }
}
