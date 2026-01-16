namespace BridgeLabzDup.datastructure_csharp_practice.scenario_based.book_shelf;

// Represents a single book in a linked list
public class BookNode
{
    public string BookName;
    public BookNode Next;

    public BookNode(string bookName)
    {
        BookName = bookName;
        Next = null;
    }
}
