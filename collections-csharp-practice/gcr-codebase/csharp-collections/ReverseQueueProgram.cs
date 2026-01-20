using System;
using System.Collections.Generic;

class ReverseQueueProgram
{
    static void Main()
    {
        Console.WriteLine("Enter queue elements (comma separated):");
        string[] input = Console.ReadLine().Split(',');

        // Create queue
        Queue<int> queue = new Queue<int>();

        foreach (string val in input)
        {
            queue.Enqueue(int.Parse(val.Trim()));
        }

        Console.WriteLine("\nOriginal Queue:");
        PrintQueue(queue);

        // Reverse the queue
        ReverseQueue(queue);

        Console.WriteLine("\nReversed Queue:");
        PrintQueue(queue);
    }

    // Method to reverse queue using only queue operations
    static void ReverseQueue(Queue<int> queue)
    {
        if (queue.Count == 0)
            return;

        // Remove front element
        int front = queue.Dequeue();

        // Reverse remaining queue
        ReverseQueue(queue);

        // Add removed element at rear
        queue.Enqueue(front);
    }

    // Helper method to print queue
    static void PrintQueue(Queue<int> queue)
    {
        foreach (int item in queue)
        {
            Console.Write(item + " ");
        }
        Console.WriteLine();
    }
}
