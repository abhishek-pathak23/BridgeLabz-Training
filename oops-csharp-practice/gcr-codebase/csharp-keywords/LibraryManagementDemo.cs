using System;

class Book
{
    // Static variable shared by all Book objects
    // Stores the name of the library
    public static string LibraryName;

    // Public instance variable to store book title
    public string Title;

    // Public instance variable to store author name
    public string Author;

    // Readonly variable: ISBN can be set only once (inside constructor)
    public readonly string ISBN;

    // Constructor to initialize book details
    public Book(string title, string author, string isbn)
    {
        // 'this' keyword differentiates class variables from parameters
        this.Title = title;
        this.Author = author;
        this.ISBN = isbn;
    }

    // Static method to display library name
    // Can be called without creating a Book object
    public static void DisplayLibraryName()
    {
        Console.WriteLine("Library: " + LibraryName);
    }

    // Instance method to display book details
    public void ShowBook()
    {
        Console.WriteLine(Title + " by " + Author);
    }
}

class LibraryManagementDemo
{
    // Entry point of the program
    static void Main()
    {
        // Assign value to static variable
        Book.LibraryName = "Central Library";

        // Take book title input from user
        Console.Write("Enter Title: ");
        string t = Console.ReadLine();

        // Take author name input from user
        Console.Write("Enter Author: ");
        string a = Console.ReadLine();

        // Take ISBN input from user
        Console.Write("Enter ISBN: ");
        string i = Console.ReadLine();

        // Store Book object in object-type reference (upcasting)
        object b = new Book(t, a, i);

        // Type-checking using 'is' operator for safety
        if (b is Book)
        {
            // Downcasting object back to Book
            ((Book)b).ShowBook();
        }

        // Call static method using class name
        Book.DisplayLibraryName();
    }
}
