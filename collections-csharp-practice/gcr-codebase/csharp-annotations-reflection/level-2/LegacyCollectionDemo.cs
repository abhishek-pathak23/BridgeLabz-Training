using System;
using System.Collections;

class LegacyCollectionDemo
{
    static void Main()
    {
        // Suppress warnings for unchecked operations
        #pragma warning disable 0618
        #pragma warning disable 8600

        // Create a non-generic ArrayList
        ArrayList items = new ArrayList();

        // Take number of items from user
        Console.Write("How many items do you want to add? ");
        int n = Convert.ToInt32(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            Console.Write($"Enter item {i + 1}: ");
            object input = Console.ReadLine(); // can store any type
            items.Add(input);
        }

        // Display the ArrayList contents
        Console.WriteLine("\nItems in the collection:");
        foreach (var item in items)
        {
            Console.WriteLine(item);
        }

        // Restore warnings
        #pragma warning restore 0618
        #pragma warning restore 8600
    }
}
