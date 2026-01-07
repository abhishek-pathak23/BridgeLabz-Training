using System;

class MovieNode
{
    public string Title, Director;
    public int Year;
    public double Rating;
    public MovieNode Prev, Next; // previous and next node references
}

class MovieDLL
{
    MovieNode head = null; // first node of the list

    public void AddMovie()
    {
        MovieNode node = new MovieNode();

        Console.Write("Title: ");
        node.Title = Console.ReadLine();

        Console.Write("Director: ");
        node.Director = Console.ReadLine();

        Console.Write("Year: ");
        node.Year = int.Parse(Console.ReadLine());

        Console.Write("Rating: ");
        node.Rating = double.Parse(Console.ReadLine());

        // if list is empty
        if (head == null)
        {
            head = node;
            return;
        }

        // move to last node
        MovieNode temp = head;
        while (temp.Next != null)
            temp = temp.Next;

        temp.Next = node;   // link new node
        node.Prev = temp;
    }

    public void DisplayForward()
    {
        MovieNode temp = head;
        while (temp != null)
        {
            Console.WriteLine($"{temp.Title} {temp.Director} {temp.Year} {temp.Rating}");
            temp = temp.Next;
        }
    }

    public void DisplayReverse()
    {
        MovieNode temp = head;

        // move to last node
        while (temp.Next != null)
            temp = temp.Next;

        // traverse backwards
        while (temp != null)
        {
            Console.WriteLine($"{temp.Title} {temp.Director} {temp.Year} {temp.Rating}");
            temp = temp.Prev;
        }
    }
}

class MovieManagementSystem
{
    static void Main()
    {
        MovieDLL list = new MovieDLL();

        while (true)
        {
            Console.WriteLine("1. Add\n2. Forward\n3. Reverse\n0. Exit");
            int ch = int.Parse(Console.ReadLine());

            if (ch == 0) break;
            if (ch == 1) list.AddMovie();
            if (ch == 2) list.DisplayForward();
            if (ch == 3) list.DisplayReverse();
        }
    }
}
