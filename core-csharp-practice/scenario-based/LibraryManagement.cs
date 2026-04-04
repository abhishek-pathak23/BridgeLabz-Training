// SUMMARY:
//Implements a menu-driven Library Management System with separate Admin and User roles.
//Admin can initialize, add, remove, and update books, while Users can display books, search by partial title (case-insensitive), and checkout available books.
//Uses arrays and basic string operations to manage book data and track availability without any database.
using System;

class LibraryManagement
{
    static string[] titles = { };
    static string[] authors = { };
    static bool[] isAvailable = { };

    // Admin initializes books - only admin can add initial books
    static void AdminInitializeBooks()
    {
        Console.Write("Enter number of books to add initially: ");
        int n = int.Parse(Console.ReadLine());

        titles = new string[n];
        authors = new string[n];
        isAvailable = new bool[n];

        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"\nBook {i + 1}:");
            Console.Write("Enter title: ");
            titles[i] = Console.ReadLine();
            Console.Write("Enter author: ");
            authors[i] = Console.ReadLine();
            isAvailable[i] = true; // Initially, all books are available
        }
    }

    // Display all books with status
    static void DisplayBooks()
    {
        Console.WriteLine("\nBook List:");
        for (int i = 0; i < titles.Length; i++)
        {
            string status = isAvailable[i] ? "Available" : "Checked Out";
            Console.WriteLine($"{i + 1}. {titles[i]} - {authors[i]} - {status}");
        }
    }

    // Search books by partial title (case-insensitive)
    static void SearchBook(string searchText)
    {
        Console.WriteLine("\nSearch Results:");
        bool found = false;

        for (int i = 0; i < titles.Length; i++)
        {
            if (titles[i].ToLower().Contains(searchText.ToLower())) // Partial match
            {
                string status = isAvailable[i] ? "Available" : "Checked Out";
                Console.WriteLine($"{i + 1}. {titles[i]} - {status}");
                found = true;
            }
        }

        if (!found)
            Console.WriteLine("No book found.");
    }

    // Checkout a book - only if available
    static void CheckoutBook(int bookNumber)
    {
        int index = bookNumber - 1;
        if (index >= 0 && index < titles.Length)
        {
            if (isAvailable[index])
            {
                isAvailable[index] = false;
                Console.WriteLine("Book checked out successfully.");
            }
            else
            {
                Console.WriteLine("Book is already checked out.");
            }
        }
        else
        {
            Console.WriteLine("Invalid book number.");
        }
    }

    // Admin can add new book dynamically
    static void AddBook()
    {
        Console.Write("Enter book title: ");
        string title = Console.ReadLine();
        Console.Write("Enter author name: ");
        string author = Console.ReadLine();

        Array.Resize(ref titles, titles.Length + 1);
        Array.Resize(ref authors, authors.Length + 1);
        Array.Resize(ref isAvailable, isAvailable.Length + 1);

        titles[titles.Length - 1] = title;
        authors[authors.Length - 1] = author;
        isAvailable[isAvailable.Length - 1] = true;

        Console.WriteLine("Book added successfully.");
    }

    // Remove a book by its number
    static void RemoveBook(int bookNumber)
    {
        int index = bookNumber - 1;
        if (index >= 0 && index < titles.Length)
        {
            for (int i = index; i < titles.Length - 1; i++)
            {
                titles[i] = titles[i + 1];
                authors[i] = authors[i + 1];
                isAvailable[i] = isAvailable[i + 1];
            }

            Array.Resize(ref titles, titles.Length - 1);
            Array.Resize(ref authors, authors.Length - 1);
            Array.Resize(ref isAvailable, isAvailable.Length - 1);

            Console.WriteLine("Book removed successfully.");
        }
        else
        {
            Console.WriteLine("Invalid book number.");
        }
    }

    // Update a book's title and author
    static void UpdateBook(int bookNumber)
    {
        int index = bookNumber - 1;
        if (index >= 0 && index < titles.Length)
        {
            Console.Write("Enter new title: ");
            titles[index] = Console.ReadLine();
            Console.Write("Enter new author: ");
            authors[index] = Console.ReadLine();
            Console.WriteLine("Book updated successfully.");
        }
        else
        {
            Console.WriteLine("Invalid book number.");
        }
    }

    static void Main()
    {
        while (true)
        {
            Console.WriteLine("\nSelect Role:\n1. Admin\n2. User\n3. Exit");
            int role = int.Parse(Console.ReadLine());

            if (role == 1) // Admin
            {
                AdminInitializeBooks(); // Initialize books only for admin

                while (true)
                {
                    Console.WriteLine("\nAdmin Menu:\n1. Display Books\n2. Add Book\n3. Remove Book\n4. Update Book\n5. Exit");
                    int adminChoice = int.Parse(Console.ReadLine());

                    switch (adminChoice)
                    {
                        case 1:
                            DisplayBooks();
                            break;
                        case 2:
                            AddBook();
                            break;
                        case 3:
                            DisplayBooks();
                            Console.Write("Enter book number to remove: ");
                            int removeNum = int.Parse(Console.ReadLine());
                            RemoveBook(removeNum);
                            break;
                        case 4:
                            DisplayBooks();
                            Console.Write("Enter book number to update: ");
                            int updateNum = int.Parse(Console.ReadLine());
                            UpdateBook(updateNum);
                            break;
                        case 5:
                            goto RoleSelection; // Exit admin menu
                        default:
                            Console.WriteLine("Invalid choice.");
                            break;
                    }
                }
            }
            else if (role == 2) // User
            {
                while (true)
                {
                    Console.WriteLine("\nUser Menu:\n1. Display Books\n2. Search Book\n3. Checkout Book\n4. Exit");
                    int userChoice = int.Parse(Console.ReadLine());

                    switch (userChoice)
                    {
                        case 1:
                            DisplayBooks();
                            break;
                        case 2:
                            Console.Write("Enter part of book title to search: ");
                            string search = Console.ReadLine();
                            SearchBook(search); // Partial title search
                            break;
                        case 3:
                            DisplayBooks();
                            Console.Write("Enter book number to checkout: ");
                            int choice = int.Parse(Console.ReadLine());
                            CheckoutBook(choice);
                            break;
                        case 4:
                            goto RoleSelection; // Exit user menu
                        default:
                            Console.WriteLine("Invalid choice.");
                            break;
                    }
                }
            }
            else if (role == 3)
            {
                break; // Exit program
            }
            else
            {
                Console.WriteLine("Invalid role selection.");
            }

        RoleSelection:; // Label to return after exiting admin/user menu
        }
    }
}
