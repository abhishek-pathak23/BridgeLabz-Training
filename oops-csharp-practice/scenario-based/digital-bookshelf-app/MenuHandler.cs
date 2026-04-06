using System;

// Handles user input and menu
public class MenuHandler
{
    public static void ShowMenu(IBookService service)
    {
        int choice;

        do
        {
            Console.WriteLine("\n BookBuddy – Digital Bookshelf");
            Console.WriteLine("1. Add Book");
            Console.WriteLine("2. Sort Books Alphabetically");
            Console.WriteLine("3. Search By Author");
            Console.WriteLine("4. Export Books");
            Console.WriteLine("5. Exit");
            Console.Write("Enter choice: ");

            choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.Write("Enter book title: ");
                    string title = Console.ReadLine();

                    Console.Write("Enter author name: ");
                    string author = Console.ReadLine();

                    service.AddBook(title, author);
                    break;

                case 2:
                    service.SortBooksAlphabetically();
                    break;

                case 3:
                    Console.Write("Enter author to search: ");
                    string searchAuthor = Console.ReadLine();
                    service.SearchByAuthor(searchAuthor);
                    break;

                case 4:
                    service.ExportBooks();
                    break;

                case 5:
                    Console.WriteLine("Exiting BookBuddy...");
                    break;

                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }

        } while (choice != 5);
    }
}
