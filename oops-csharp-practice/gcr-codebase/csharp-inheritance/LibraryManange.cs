using System;

// Base class Book
class Book
{
    // Title of the book
    public string Title;

    // Year the book was published
    public int PublicationYear;
}

// Derived class Author inherits from Book
class Author : Book
{
    // Name of the author
    public string Name;

    // Short biography of the author
    public string Bio;

    // Method to display complete book and author information
    public void DisplayInfo()
    {
        Console.WriteLine($"Title: {Title}");
        Console.WriteLine($"Year: {PublicationYear}");
        Console.WriteLine($"Author: {Name}");
        Console.WriteLine($"Bio: {Bio}");
    }
}

// Main class
class LibraryManange
{
    static void Main()
    {
        // Create object of Author class
        Author a = new Author();

        // Take book title input from user
        Console.Write("Enter Book Title: ");
        a.Title = Console.ReadLine();

        // Take publication year input from user
        Console.Write("Enter Publication Year: ");
        a.PublicationYear = int.Parse(Console.ReadLine());

        // Take author name input from user
        Console.Write("Enter Author Name: ");
        a.Name = Console.ReadLine();

        // Take author bio input from user
        Console.Write("Enter Author Bio: ");
        a.Bio = Console.ReadLine();

        // Display all details
        a.DisplayInfo();
    }
}
