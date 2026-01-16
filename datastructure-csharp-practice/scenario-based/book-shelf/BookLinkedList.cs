using System;

namespace BridgeLabzDup.datastructure_csharp_practice.scenario_based.book_shelf;

// Linked list to manage books of a particular genre
public class BookLinkedList
{
    private BookNode head;

    // Prevents duplicate book entries
    public bool Contains(string bookName)
    {
        BookNode temp = head;
        while (temp != null)
        {
            if (temp.BookName == bookName)
                return true;
            temp = temp.Next;
        }
        return false;
    }

    // Insert book at end
    public void Add(string bookName)
    {
        if (Contains(bookName))
        {
            Console.WriteLine("Book already exists");
            return;
        }

        BookNode newNode = new BookNode(bookName);

        if (head == null)
        {
            head = newNode;
            return;
        }

        BookNode temp = head;
        while (temp.Next != null)
            temp = temp.Next;

        temp.Next = newNode;
    }

    // Remove a book when borrowed
    public void Remove(string bookName)
    {
        if (head == null)
            return;

        if (head.BookName == bookName)
        {
            head = head.Next;
            return;
        }

        BookNode temp = head;
        while (temp.Next != null && temp.Next.BookName != bookName)
            temp = temp.Next;

        if (temp.Next != null)
            temp.Next = temp.Next.Next;
    }

    // Display all books in this genre
    public void Display()
    {
        BookNode temp = head;
        while (temp != null)
        {
            Console.Write(temp.BookName + " -> ");
            temp = temp.Next;
        }
        Console.WriteLine("null");
    }

    public bool IsEmpty() => head == null;
}
