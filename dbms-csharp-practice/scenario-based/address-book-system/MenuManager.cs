using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;

namespace BridgeLabzTraining.oops_csharp_practice.scenario_based.address_book
{
    // Manages multiple address books
    internal class MenuManager
    {
        private static List<AddressBookImpl> addressBooks = new List<AddressBookImpl>();

        public static void DisplayMenu()
        {
            int choice;

            do
            {
                Console.WriteLine("\n--- Multiple Address Book Menu ---");
                Console.WriteLine("1. Create New Address Book");
                Console.WriteLine("2. Select Address Book");
                Console.WriteLine("3. Search Person (City/State)");
                Console.WriteLine("4. Count Persons by City or State");
                Console.WriteLine("0. Exit");

                choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        CreateNewAddressBook();
                        break;
                    case 2:
                        SelectAddressBook();
                        break;
                    case 3:
                        SearchAcrossBooks();
                        break;
                    case 4:
                        CountPersonsByCityOrState();
                        break;
                }

            } while (choice != 0);
        }

       private static void CreateNewAddressBook()
{
    Console.Write("Enter Address Book Name: ");
    string name = Console.ReadLine() ?? "";

    using (SqlConnection con = new SqlConnection(AddressBookImpl.connectionString))
    {
        string query = "INSERT INTO AddressBooks (BookName) VALUES (@Name)";
        SqlCommand cmd = new SqlCommand(query, con);
        cmd.Parameters.AddWithValue("@Name", name);

        con.Open();
        cmd.ExecuteNonQuery();
    }

    Console.WriteLine("Address Book Saved To Database!\n");
}

          

        
          private static void SelectAddressBook()
{
    List<AddressBookImpl> books = new List<AddressBookImpl>();

    using (SqlConnection con = new SqlConnection(AddressBookImpl.connectionString))
    {
        string query = "SELECT * FROM AddressBooks";
        SqlCommand cmd = new SqlCommand(query, con);

        con.Open();
        SqlDataReader reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            books.Add(new AddressBookImpl(
                Convert.ToInt32(reader["AddressBookId"]),
                reader["BookName"].ToString() ?? ""
            ));
        }
    }

    if (books.Count == 0)
    {
        Console.WriteLine("No Address Books Found.\n");
        return;
    }

    for (int i = 0; i < books.Count; i++)
        Console.WriteLine($"{i + 1}. {books[i].Name}");

    int choice = Convert.ToInt32(Console.ReadLine());

    if (choice >= 1 && choice <= books.Count)
        AddressBookMenu(books[choice - 1]);
}

             

        private static void AddressBookMenu(AddressBookImpl book)
        {
            int choice;

            do
            {
                Console.WriteLine($"\n--- Address Book: {book.Name} ---");
                Console.WriteLine("1. Add Contact");
                Console.WriteLine("2. Edit Contact");
                Console.WriteLine("3. Delete Contact");
                Console.WriteLine("4. Add Multiple Contacts");
                Console.WriteLine("5. Display All Contacts");
                Console.WriteLine("0. Back");

                choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1: book.AddContact(); break;
                    case 2: book.EditContact(); break;
                    case 3: book.DeleteContact(); break;
                    case 4: book.AddMultipleContactsMenu(); break;
                    case 5: book.DisplayAllContacts(); break;
                }

            } while (choice != 0);
        }

        private static void SearchAcrossBooks()
        {
            Console.WriteLine("1. Search by City");
            Console.WriteLine("2. Search by State");

            int choice = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter value: ");
            string value = Console.ReadLine();

            foreach (var book in addressBooks)
            {
                if (choice == 1)
                    book.SearchByCity(value);
                else
                    book.SearchByState(value);
            }
        }

       

                private static void CountPersonsByCityOrState()
        {
            Console.WriteLine("1. Count by City");
            Console.WriteLine("2. Count by State");

            int choice = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter value: ");
            string value = Console.ReadLine();

            int total = 0;

            foreach (var book in addressBooks)
            {
                if (choice == 1)
                    total += book.GetCountByCity(value);
                else
                    total += book.GetCountByState(value);
            }

            Console.WriteLine($"Total Count: {total}\n");
        }
    }
}
