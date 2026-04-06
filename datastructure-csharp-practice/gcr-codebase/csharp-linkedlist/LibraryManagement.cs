using System;

class BookNode
{
    public int BookId;
    public string Title;
    public string Author;
    public string Genre;
    public bool IsAvailable;

    public BookNode Next;
    public BookNode Prev;

    public BookNode(int bookId, string title, string author, string genre, bool isAvailable)
    {
        BookId = bookId;
        Title = title;
        Author = author;
        Genre = genre;
        IsAvailable = isAvailable;
        Next = null;
        Prev = null;
    }
}

class LibraryDoublyLinkedList
{
    private BookNode head;
    private BookNode tail;

    public void AddAtBeginning(int id, string title, string author, string genre, bool available)
    {
        BookNode newNode = new BookNode(id, title, author, genre, available);

        if (head == null)
            head = tail = newNode;
        else
        {
            newNode.Next = head;
            head.Prev = newNode;
            head = newNode;
        }
    }

    public void AddAtEnd(int id, string title, string author, string genre, bool available)
    {
        BookNode newNode = new BookNode(id, title, author, genre, available);

        if (tail == null)
            head = tail = newNode;
        else
        {
            tail.Next = newNode;
            newNode.Prev = tail;
            tail = newNode;
        }
    }

    public void AddAtPosition(int pos, int id, string title, string author, string genre, bool available)
    {
        if (pos <= 1)
        {
            AddAtBeginning(id, title, author, genre, available);
            return;
        }

        BookNode temp = head;
        for (int i = 1; i < pos - 1 && temp != null; i++)
            temp = temp.Next;

        if (temp == null || temp.Next == null)
        {
            AddAtEnd(id, title, author, genre, available);
            return;
        }

        BookNode newNode = new BookNode(id, title, author, genre, available);
        newNode.Next = temp.Next;
        newNode.Prev = temp;
        temp.Next.Prev = newNode;
        temp.Next = newNode;
    }

    public void RemoveByBookId(int id)
    {
        if (head == null)
        {
            Console.WriteLine("Library is empty");
            return;
        }

        BookNode temp = head;
        while (temp != null && temp.BookId != id)
            temp = temp.Next;

        if (temp == null)
        {
            Console.WriteLine("Book not found");
            return;
        }

        if (temp == head)
        {
            head = head.Next;
            if (head != null) head.Prev = null;
        }
        else if (temp == tail)
        {
            tail = tail.Prev;
            tail.Next = null;
        }
        else
        {
            temp.Prev.Next = temp.Next;
            temp.Next.Prev = temp.Prev;
        }

        Console.WriteLine("Book removed");
    }

    public void SearchByTitle(string title)
    {
        BookNode temp = head;
        bool found = false;

        while (temp != null)
        {
            if (temp.Title.Equals(title, StringComparison.OrdinalIgnoreCase))
            {
                DisplayBook(temp);
                found = true;
            }
            temp = temp.Next;
        }

        if (!found) Console.WriteLine("Book not found");
    }

    public void SearchByAuthor(string author)
    {
        BookNode temp = head;
        bool found = false;

        while (temp != null)
        {
            if (temp.Author.Equals(author, StringComparison.OrdinalIgnoreCase))
            {
                DisplayBook(temp);
                found = true;
            }
            temp = temp.Next;
        }

        if (!found) Console.WriteLine("No books found");
    }

    public void UpdateAvailability(int id, bool status)
    {
        BookNode temp = head;
        while (temp != null)
        {
            if (temp.BookId == id)
            {
                temp.IsAvailable = status;
                Console.WriteLine("Availability updated");
                return;
            }
            temp = temp.Next;
        }
        Console.WriteLine("Book not found");
    }

    public void DisplayForward()
    {
        if (head == null)
        {
            Console.WriteLine("No books available");
            return;
        }

        BookNode temp = head;
        while (temp != null)
        {
            DisplayBook(temp);
            temp = temp.Next;
        }
    }

    public void DisplayReverse()
    {
        if (tail == null)
        {
            Console.WriteLine("No books available");
            return;
        }

        BookNode temp = tail;
        while (temp != null)
        {
            DisplayBook(temp);
            temp = temp.Prev;
        }
    }

    public void CountBooks()
    {
        int count = 0;
        BookNode temp = head;
        while (temp != null)
        {
            count++;
            temp = temp.Next;
        }
        Console.WriteLine("Total Books: " + count);
    }

    private void DisplayBook(BookNode b)
    {
        Console.WriteLine($"{b.BookId} | {b.Title} | {b.Author} | {b.Genre} | {(b.IsAvailable ? "Available" : "Not Available")}");
    }
}

class LibraryManagement
{
    static void Main()
    {
        LibraryDoublyLinkedList library = new LibraryDoublyLinkedList();

        while (true)
        {
            Console.WriteLine("\n1 Add At Beginning");
            Console.WriteLine("2 Add At End");
            Console.WriteLine("3 Add At Position");
            Console.WriteLine("4 Remove Book");
            Console.WriteLine("5 Search By Title");
            Console.WriteLine("6 Search By Author");
            Console.WriteLine("7 Update Availability");
            Console.WriteLine("8 Display Forward");
            Console.WriteLine("9 Display Reverse");
            Console.WriteLine("10 Count Books");
            Console.WriteLine("0 Exit");

            int ch = int.Parse(Console.ReadLine() ?? "0");

            if (ch == 0) break;

            int id, pos;
            string title, author, genre;
            bool status;

            switch (ch)
            {
                case 1:
                case 2:
                case 3:
                    if (ch == 3)
                    {
                        Console.Write("Position: ");
                        pos = int.Parse(Console.ReadLine());
                    }
                    else pos = 0;

                    Console.Write("Book ID: ");
                    id = int.Parse(Console.ReadLine());
                    Console.Write("Title: ");
                    title = Console.ReadLine();
                    Console.Write("Author: ");
                    author = Console.ReadLine();
                    Console.Write("Genre: ");
                    genre = Console.ReadLine();
                    Console.Write("Available (true/false): ");
                    status = bool.Parse(Console.ReadLine());

                    if (ch == 1) library.AddAtBeginning(id, title, author, genre, status);
                    else if (ch == 2) library.AddAtEnd(id, title, author, genre, status);
                    else library.AddAtPosition(pos, id, title, author, genre, status);
                    break;

                case 4:
                    Console.Write("Book ID: ");
                    id = int.Parse(Console.ReadLine());
                    library.RemoveByBookId(id);
                    break;

                case 5:
                    Console.Write("Title: ");
                    library.SearchByTitle(Console.ReadLine());
                    break;

                case 6:
                    Console.Write("Author: ");
                    library.SearchByAuthor(Console.ReadLine());
                    break;

                case 7:
                    Console.Write("Book ID: ");
                    id = int.Parse(Console.ReadLine());
                    Console.Write("Available (true/false): ");
                    status = bool.Parse(Console.ReadLine());
                    library.UpdateAvailability(id, status);
                    break;

                case 8:
                    library.DisplayForward();
                    break;

                case 9:
                    library.DisplayReverse();
                    break;

                case 10:
                    library.CountBooks();
                    break;
            }
        }
    }
}
