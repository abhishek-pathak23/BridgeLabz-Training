using System;
using System.Collections.Generic;

namespace LibraryManagement
{
    // Book class represents a single book
    class Book
    {
        public string Title { get; set; }  // Book title
        public string Author { get; set; } // Book author

        public Book(string title, string author)
        {
            Title = title;
            Author = author;
        }

        // Display book details
        public void DisplayBook()
        {
            Console.WriteLine($"Title: {Title}, Author: {Author}");
        }
    }

    // Library class aggregates multiple Book objects
    class Library
    {
        public string Name { get; set; }
        public List<Book> Books { get; set; } // Aggregation: Library has Books

        public Library(string name)
        {
            Name = name;
            Books = new List<Book>();
        }

        // Add book to the library
        public void AddBook(Book book)
        {
            Books.Add(book);
            Console.WriteLine($"Book '{book.Title}' added to {Name}.");
        }

        // Show all books in the library
        public void ShowBooks()
        {
            Console.WriteLine($"\nBooks in {Name}:");
            foreach (var book in Books)
            {
                book.DisplayBook();
            }
        }
    }

    class LibraryManagement
    {
        static void Main(string[] args)
        {
            // Create books independently
            Console.WriteLine("Enter number of books to create:");
            int numBooks = int.Parse(Console.ReadLine());
            List<Book> allBooks = new List<Book>();

            for (int i = 0; i < numBooks; i++)
            {
                Console.WriteLine($"\nEnter title of book {i + 1}:");
                string title = Console.ReadLine();
                Console.WriteLine("Enter author of the book:");
                string author = Console.ReadLine();

                Book book = new Book(title, author);
                allBooks.Add(book);
            }

            // Create libraries
            Console.WriteLine("\nEnter number of libraries:");
            int numLibraries = int.Parse(Console.ReadLine());
            List<Library> libraries = new List<Library>();

            for (int i = 0; i < numLibraries; i++)
            {
                Console.WriteLine($"\nEnter name of library {i + 1}:");
                string libName = Console.ReadLine();
                Library library = new Library(libName);

                // Add books to library
                Console.WriteLine($"How many books to add to {libName}?");
                int booksToAdd = int.Parse(Console.ReadLine());

                for (int j = 0; j < booksToAdd; j++)
                {
                    Console.WriteLine($"Select book index to add (1 to {allBooks.Count}):");
                    for (int k = 0; k < allBooks.Count; k++)
                    {
                        Console.WriteLine($"{k + 1}. {allBooks[k].Title}");
                    }

                    int index = int.Parse(Console.ReadLine()) - 1;
                    if (index >= 0 && index < allBooks.Count)
                        library.AddBook(allBooks[index]);
                    else
                        Console.WriteLine("Invalid index.");
                }

                libraries.Add(library);
            }

            // Display books in all libraries
            foreach (var library in libraries)
            {
                library.ShowBooks();
            }
        }
    }
}
