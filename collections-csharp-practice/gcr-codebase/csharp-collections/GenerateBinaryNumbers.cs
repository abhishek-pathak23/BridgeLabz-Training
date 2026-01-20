using System;
using System.Collections.Generic;

class GenerateBinaryNumbers
{
    static void Main()
    {
        Console.WriteLine("Enter N (number of binary numbers to generate):");
        int n = int.Parse(Console.ReadLine());

        Queue<string> queue = new Queue<string>();
        List<string> result = new List<string>();

        // Start with "1"
        queue.Enqueue("1");

        for (int i = 0; i < n; i++)
        {
            // Get front element
            string current = queue.Dequeue();
            result.Add(current);

            // Append "0" and "1" to current and enqueue
            queue.Enqueue(current + "0");
            queue.Enqueue(current + "1");
        }

        // Display result
        Console.WriteLine("\nFirst " + n + " binary numbers:");
        Console.WriteLine(string.Join(", ", result));
    }
}
