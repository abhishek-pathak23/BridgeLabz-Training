using System;

// Node class representing one text state
class TextStateNode
{
    public string Content;
    public TextStateNode Prev;
    public TextStateNode Next;

    public TextStateNode(string content)
    {
        Content = content;
        Prev = null;
        Next = null;
    }
}

// Doubly Linked List for Undo / Redo
class TextEditorHistory
{
    private TextStateNode head;
    private TextStateNode tail;
    private TextStateNode current;
    private int size;
    private const int MAX_SIZE = 10;

    // Add new text state
    public void AddState(string content)
    {
        TextStateNode newNode = new TextStateNode(content);

        // If undo was used, clear redo history
        if (current != null && current.Next != null)
        {
            current.Next.Prev = null;
            current.Next = null;
            tail = current;
            size = CountNodes();
        }

        if (head == null)
        {
            head = tail = current = newNode;
            size = 1;
            return;
        }

        tail.Next = newNode;
        newNode.Prev = tail;
        tail = newNode;
        current = newNode;
        size++;

        // Maintain fixed size (remove oldest)
        if (size > MAX_SIZE)
        {
            head = head.Next;
            head.Prev = null;
            size--;
        }
    }

    // Undo operation
    public void Undo()
    {
        if (current == null || current.Prev == null)
        {
            Console.WriteLine("Nothing to undo");
            return;
        }

        current = current.Prev;
        DisplayCurrentState();
    }

    // Redo operation
    public void Redo()
    {
        if (current == null || current.Next == null)
        {
            Console.WriteLine("Nothing to redo");
            return;
        }

        current = current.Next;
        DisplayCurrentState();
    }

    // Display current text state
    public void DisplayCurrentState()
    {
        if (current == null)
        {
            Console.WriteLine("Editor is empty");
            return;
        }

        Console.WriteLine("Current Text: " + current.Content);
    }

    // Helper method to count nodes
    private int CountNodes()
    {
        int count = 0;
        TextStateNode temp = head;
        while (temp != null)
        {
            count++;
            temp = temp.Next;
        }
        return count;
    }
}

// Main class
class TextEditor
{
    static void Main()
    {
        TextEditorHistory editor = new TextEditorHistory();

        editor.AddState("Hello");
        editor.AddState("Hello World");
        editor.AddState("Hello World!");
        editor.AddState("Hello World!!");

        editor.DisplayCurrentState();

        Console.WriteLine("\nUndo:");
        editor.Undo();

        Console.WriteLine("\nUndo:");
        editor.Undo();

        Console.WriteLine("\nRedo:");
        editor.Redo();

        Console.WriteLine("\nAdd New Text:");
        editor.AddState("Hello ChatGPT");

        Console.WriteLine("\nRedo:");
        editor.Redo();
    }
}