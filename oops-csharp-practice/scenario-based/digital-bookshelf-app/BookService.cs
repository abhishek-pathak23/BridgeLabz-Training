using System;

// Implements book-related operations using fixed-size array
public class BookService : IBookService
{
    private string[] books = new string[100]; // Max 100 books
    private int count = 0; // Current number of books

    // Add a book
    public void AddBook(string title, string author)
    {
        if (count >= books.Length)
        {
            Console.WriteLine("Book array is full. Cannot add more books.");
            return;
        }

        if (string.IsNullOrWhiteSpace(title) || string.IsNullOrWhiteSpace(author))
        {
            Console.WriteLine("Title and Author cannot be empty.");
            return;
        }

        books[count] = $"{title} - {author}";
        count++;
        Console.WriteLine("Book added successfully.");
    }

    // Sort books alphabetically using simple bubble sort
    public void SortBooksAlphabetically()
    {
        if (count == 0)
        {
            Console.WriteLine("No books available to sort.");
            return;
        }

        for (int i = 0; i < count - 1; i++)
        {
            for (int j = 0; j < count - i - 1; j++)
            {
                if (string.Compare(books[j], books[j + 1], StringComparison.OrdinalIgnoreCase) > 0)
                {
                    string temp = books[j];
                    books[j] = books[j + 1];
                    books[j + 1] = temp;
                }
            }
        }

        Console.WriteLine("Books sorted alphabetically.");
    }

    // Search books by author
    public void SearchByAuthor(string author)
    {
        if (count == 0)
        {
            Console.WriteLine("No books available.");
            return;
        }

        bool found = false;

        for (int i = 0; i < count; i++)
        {
            string[] parts = books[i].Split('-');
            if (parts.Length == 2)
            {
                string bookAuthor = parts[1].Trim();
                if (bookAuthor.Equals(author, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine(books[i]);
                    found = true;
                }
            }
        }

        if (!found)
            Console.WriteLine("No books found for this author.");
    }

    // Export books as array
    public void ExportBooks()
    {
        if (count == 0)
        {
            Console.WriteLine("No books to export.");
            return;
        }

        string[] exportArray = new string[count];
        Array.Copy(books, exportArray, count);

        Console.WriteLine("\nExported Book List:");
        for (int i = 0; i < exportArray.Length; i++)
        {
            Console.WriteLine(exportArray[i]);
        }
    }
}
