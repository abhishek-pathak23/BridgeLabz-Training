using System;

// Interface that defines reservation-related actions
// Any library item that can be reserved must implement this
interface IReservable
{
    void ReserveItem();          // Handles reservation process
    bool CheckAvailability();    // Checks whether item is available
}

// Abstract class representing a generic library item
// Contains common properties shared by all items
abstract class LibraryItem
{
    private int itemId;
    private string title;

    // Property to store item ID
    public int ItemId
    {
        get => itemId;
        set => itemId = value;
    }

    // Property to store item title
    public string Title
    {
        get => title;
        set => title = value;
    }

    // Forces derived classes to define loan duration
    public abstract int GetLoanDuration();

    // Displays basic item details
    public void GetItemDetails()
    {
        Console.WriteLine($"ID: {ItemId}, Title: {Title}");
    }
}

// Book class extends LibraryItem and supports reservation
class Book : LibraryItem, IReservable
{
    // Books can be borrowed for 14 days
    public override int GetLoanDuration()
    {
        return 14;
    }

    // Reserves the book
    public void ReserveItem()
    {
        Console.WriteLine("Book Reserved Successfully");
    }

    // Returns availability status
    public bool CheckAvailability()
    {
        return true;
    }
}

// Program execution starts here
class LibrarySystem
{
    static void Main()
    {
        Book book = new Book();
        bool exit = false;

        // Taking basic book details
        Console.Write("Enter Book ID: ");
        book.ItemId = int.Parse(Console.ReadLine());

        Console.Write("Enter Book Title: ");
        book.Title = Console.ReadLine();

        // Menu-driven loop
        while (!exit)
        {
            Console.WriteLine("\n--- Library Menu ---");
            Console.WriteLine("1. View Item Details");
            Console.WriteLine("2. Check Availability");
            Console.WriteLine("3. Reserve Book");
            Console.WriteLine("4. Get Loan Duration");
            Console.WriteLine("5. Exit");
            Console.Write("Enter your choice: ");

            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    book.GetItemDetails();
                    break;

                case 2:
                    Console.WriteLine(book.CheckAvailability()
                        ? "Book is Available"
                        : "Book is Not Available");
                    break;

                case 3:
                    book.ReserveItem();
                    break;

                case 4:
                    Console.WriteLine($"Loan Duration: {book.GetLoanDuration()} days");
                    break;

                case 5:
                    exit = true;
                    Console.WriteLine("Exiting Library System");
                    break;

                default:
                    Console.WriteLine("Invalid choice. Try again.");
                    break;
            }
        }
    }
}
