using System;

namespace BridgeLabzDup.datastructure_csharp_practice.scenario_based.book_shelf;

// Custom dictionary mapping Genre → BookLinkedList
public class CustomDictionary
{
    private string[] keys;
    private BookLinkedList[] values;
    private int count;

    public CustomDictionary(int capacity)
    {
        keys = new string[capacity];
        values = new BookLinkedList[capacity];
        count = 0;
    }

    // Add new genre
    public void Add(string key)
    {
        if (ContainsKey(key))
            return;

        keys[count] = key;
        values[count] = new BookLinkedList();
        count++;
    }

    // Check if genre exists
    public bool ContainsKey(string key)
    {
        for (int i = 0; i < count; i++)
            if (keys[i] == key)
                return true;
        return false;
    }

    // Get book list of a genre
    public BookLinkedList Get(string key)
    {
        for (int i = 0; i < count; i++)
            if (keys[i] == key)
                return values[i];
        return null;
    }

    // Display full catalog
    public void Display()
    {
        for (int i = 0; i < count; i++)
        {
            Console.WriteLine("\nGenre: " + keys[i]);
            values[i].Display();
        }
    }
}
