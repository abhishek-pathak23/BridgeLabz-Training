using System;

namespace library_management_review.library_management
{
    class Program
    {
        static void Main(string[] args)
        {
            Library library = new Library();
            int choice;
            do 
            {
                Console.WriteLine("\n--- Library Management System ---");
                Console.WriteLine("1. Display Books");
                Console.WriteLine("2. Search Book");
                Console.WriteLine("3. Checkout Book");
                Console.WriteLine("4. Add Book");
                Console.WriteLine("5. Exit");
                Console.Write("Enter choice: ");

                choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        library.DisplayBooks();
                        break;

                    case 2:
                        Console.Write("Enter partial title: ");
                        string title = Console.ReadLine();
                        library.SearchBook(title);
                        break;

                    case 3:
                        Console.Write("Enter Book ID: ");
                        int id = Convert.ToInt32(Console.ReadLine());
                        library.CheckoutBook(id);
                        break;

                    case 4:
                        library.AddBook();
                        break;

                    case 5:
                        Console.WriteLine("Exiting program...");
                        break;

                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }

            } while (choice != 5);
        }
    }
}
