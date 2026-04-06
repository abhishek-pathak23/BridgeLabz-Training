using System;

class Book
{
    // Accessible everywhere
    public string ISBN;

    // Accessible in this class and derived classes
    protected string title;

    // Accessible only inside this class
    private string author;

    // Constructor to initialize ISBN and title
    public Book(string isbn, string bookTitle)
    {
        ISBN = isbn;
        title = bookTitle;
    }

    // Method to set author name
    public void SetAuthor(string name)
    {
        author = name;
    }

    // Method to get author name
    public string GetAuthor()
    {
        return author;
    }
}

// Child class
class EBook : Book
{
    // Calling parent constructor
    public EBook(string isbn, string bookTitle)
        : base(isbn, bookTitle)
    {
    }

    // Display book details
    public void DisplayDetails()
    {
        Console.WriteLine("\nBook Details");
        Console.WriteLine("ISBN  : " + ISBN);   // public member
        Console.WriteLine("Title : " + title);  // protected member
    }
}

class LibrarySystem
{
    static void Main()
    {
        // Taking input from user
        Console.Write("Enter ISBN: ");
        string isbn = Console.ReadLine();

        Console.Write("Enter Book Title: ");
        string title = Console.ReadLine();

        Console.Write("Enter Author Name: ");
        string author = Console.ReadLine();

        // Creating object of child class
        EBook book = new EBook(isbn, title);

        // Setting author using public method
        book.SetAuthor(author);

        // Displaying book information
        book.DisplayDetails();
        Console.WriteLine("Author: " + book.GetAuthor());
    }
}
