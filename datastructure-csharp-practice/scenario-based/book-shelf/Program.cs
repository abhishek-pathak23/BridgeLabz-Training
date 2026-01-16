using System;

namespace BridgeLabzDup.datastructure_csharp_practice.scenario_based.book_shelf;

class Program
{
    static void Main()
    {
        IBookShelfManager library = new LibraryUtility();
        int choice;

        do
        {
            Console.WriteLine("\n--- BOOKSHELF MENU ---");
            Console.WriteLine("1. Add Book");
            Console.WriteLine("2. Borrow Book");
            Console.WriteLine("3. Show Catalog");
            Console.WriteLine("0. Exit");
            Console.Write("Enter choice: ");
            choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.Write("Enter Genre: ");
                    string g = Console.ReadLine();
                    Console.Write("Enter Book Name: ");
                    string b = Console.ReadLine();
                    library.AddBook(g, b);
                    break;

                case 2:
                    Console.Write("Enter Genre: ");
                    g = Console.ReadLine();
                    Console.Write("Enter Book Name: ");
                    b = Console.ReadLine();
                    library.BorrowBook(g, b);
                    break;

                case 3:
                    library.ShowCatalog();
                    break;

                case 0:
                    Console.WriteLine("Exiting...");
                    break;

                default:
                    Console.WriteLine("Invalid choice");
                    break;
            }

        } while (choice != 0);
    }
}






