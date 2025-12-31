using System;

class LibraryBook
{
    // Fields to store book information
    public string title;       // Book title
    public string author;      // Book author
    public double price;       // Price of the book
    public bool isAvailable;   // Availability status of the book

    // Parameterized constructor to initialize a book with title, author, and price
    public LibraryBook(string t, string a, double p)
    {
        title = t;
        author = a;
        price = p;
        isAvailable = true; // New books are available by default
    }

    // Method to borrow the book
    public void BorrowBook()
    {
        if (isAvailable) // Check if the book is currently available
        {
            Console.WriteLine($"You have successfully borrowed '{title}'.");
            isAvailable = false; // Mark the book as borrowed
        }
        else
        {
            Console.WriteLine($"Sorry, '{title}' is not available.");
        }
    }

    // Method to display all details of the book
    public void Display()
    {
        Console.WriteLine($"Title: {title}, Author: {author}, Price: {price}, Available: {isAvailable}");
    }
}

class ProgramLibrarySys
{
    static void Main()
    {
        // Ask user for book details
        Console.WriteLine("Enter Book Details:");
        Console.Write("Title: "); 
        string t = Console.ReadLine(); // Read book title
        Console.Write("Author: "); 
        string a = Console.ReadLine(); // Read book author
        Console.Write("Price: "); 
        double p = Convert.ToDouble(Console.ReadLine()); // Read book price and convert to double

        // Create a new LibraryBook object with user input
        LibraryBook book = new LibraryBook(t, a, p);

        // Display the entered book details
        Console.WriteLine("\nBook Details:");
        book.Display();

        // Ask the user if they want to borrow the book
        Console.WriteLine("\nDo you want to borrow the book? (yes/no): ");
        string borrow = Console.ReadLine();
        if (borrow.ToLower() == "yes") // Convert input to lowercase for case-insensitive comparison
        {
            book.BorrowBook(); // Attempt to borrow the book
        }

        // Show updated details after borrowing
        Console.WriteLine("\nUpdated Book Details:");
        book.Display();
    }
}
