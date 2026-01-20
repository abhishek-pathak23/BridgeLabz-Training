using System;
using System.Collections.Generic;

class HospitalTriage
{
    static void Main()
    {
        // Create a priority queue where higher severity has higher priority
        // In C#, PriorityQueue<TElement,TPriority> treats LOWER priority value as higher priority
        // So, we use negative severity to invert the order
        PriorityQueue<string, int> pq = new PriorityQueue<string, int>();

        Console.WriteLine("Enter number of patients:");
        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"Enter name of patient {i + 1}:");
            string name = Console.ReadLine();

            Console.WriteLine($"Enter severity of patient {i + 1} (higher number = more severe):");
            int severity = int.Parse(Console.ReadLine());

            // Use negative severity because PriorityQueue treats smaller numbers as higher priority
            pq.Enqueue(name, -severity);
        }

        Console.WriteLine("\nOrder of treatment (highest severity first):");
        while (pq.Count > 0)
        {
            Console.WriteLine(pq.Dequeue());
        }
    }
}
