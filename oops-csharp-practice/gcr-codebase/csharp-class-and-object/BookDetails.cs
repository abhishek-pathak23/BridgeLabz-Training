using System; 

// Class to represent a Book
class BookDetails
{
    // Variables to store book details
    string title;
    string author;
    double price;

    // Method to display book details
    void DisplayBookDetails()
    {
        Console.WriteLine("\nBook Details:");
        Console.WriteLine("Title: " + title);
        Console.WriteLine("Author: " + author);
        Console.WriteLine("Price: " + price);
    }

    static void Main()
    {
        // Creating an object of Book class
        Book b = new Book();

        // Taking book details from user
        Console.Write("Enter Book Title: ");
        b.title = Console.ReadLine();

        Console.Write("Enter Author Name: ");
        b.author = Console.ReadLine();

        Console.Write("Enter Book Price: ");
        b.price = double.Parse(Console.ReadLine());

        // Displaying book details
        b.DisplayBookDetails();
    }
}
