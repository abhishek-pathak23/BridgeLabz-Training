using System;

namespace BridgeLabzDup.datastructure_csharp_practice.scenario_based.book_shelf;

// Implements library logic using custom dictionary and linked lists
public class LibraryUtility : IBookShelfManager
{
    private CustomDictionary catalog = new CustomDictionary(10);

    public void AddBook(string genre, string bookName)
    {
        if (!catalog.ContainsKey(genre))
            catalog.Add(genre);

        catalog.Get(genre).Add(bookName);
        Console.WriteLine("Book added successfully");
    }

    public void BorrowBook(string genre, string bookName)
    {
        BookLinkedList list = catalog.Get(genre);

        if (list == null || list.IsEmpty())
        {
            Console.WriteLine("Book not available");
            return;
        }

        list.Remove(bookName);
        Console.WriteLine("Book borrowed");
    }

    public void ShowCatalog()
    {
        catalog.Display();
    }
}
