using System;

namespace library_management_review.library_management
{
    class Library : IBookOperations
    {
        private Book[] books = new Book[100]; // fixed size array
        private int count = 0;                // current number of books
        private int nextId = 1;

        public void DisplayBooks()
        {
            if (count == 0)
            {
                Console.WriteLine("No books available.");
                return;
            }

            Console.WriteLine("\nBook List:");
            for (int i = 0; i < count; i++)
            {
                string status = books[i].IsAvailable ? "Available" : "Checked Out";
                Console.WriteLine($"{books[i].Id}. {books[i].Title} - {books[i].Author} ({status})");
            }
        }

        public void SearchBook(string title)
        {
            bool found = false;

            Console.WriteLine("\nSearch Results:");
            for (int i = 0; i < count; i++)
            {
                if (books[i].Title.ToLower().Contains(title.ToLower()))
                {
                    Console.WriteLine($"{books[i].Id}. {books[i].Title} - {books[i].Author}");
                    found = true;
                }
            }

            if (!found)
            {
                Console.WriteLine("No book found.");
            }
        }

        public void CheckoutBook(int id)
        {
            for (int i = 0; i < count; i++)
            {
                if (books[i].Id == id)
                {
                    if (books[i].IsAvailable)
                    {
                        books[i].IsAvailable = false;
                        Console.WriteLine("Book checked out successfully.");
                    }
                    else
                    {
                        Console.WriteLine("Book already checked out.");
                    }
                    return;
                }
            }

            Console.WriteLine("Invalid Book ID.");
        }

        public void AddBook()
        {
            if (count >= books.Length)
            {
                Console.WriteLine("Library is full.");
                return;
            }

            Console.Write("Enter book title: ");
            string title = Console.ReadLine();

            Console.Write("Enter author name: ");
            string author = Console.ReadLine();

            books[count] = new Book(nextId++, title, author);
            count++;

            Console.WriteLine("Book added successfully.");
        }
    }
}
