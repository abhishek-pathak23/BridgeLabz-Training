using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.oops_csharp_practice.scenario_based.address_book
{
    internal class MenuManager
    {
        private static AddressBookImpl[] addressBooks = new AddressBookImpl[10]; // Max 10 Address Books
        private static string[] addressBookNames = new string[10]; // Names for uniqueness
        private static int bookCount = 0;

        // UC-9 simulated dictionary using arrays
        private static string[] cityNames = new string[50];
        private static string[] cityPersons = new string[50];
        private static int cityCount = 0;

        private static string[] stateNames = new string[50];
        private static string[] statePersons = new string[50];
        private static int stateCount = 0;


        // Displays the main menu and handles user interactions

        public static void DisplayMenu()
        {
            int choice;

            do
            {
                Console.WriteLine("\n--- Multiple Address Book Menu ---");
                Console.WriteLine("1. Create New Address Book");
                Console.WriteLine("2. Select Address Book");
                Console.WriteLine("3. Search Person (City/State)");
                Console.WriteLine("4. View Persons by City or State");
                Console.WriteLine("5. Count Persons by City or State");

                Console.WriteLine("0. Exit");
                Console.Write("Enter Choice: ");

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
                        SearchAcrossAddressBooks();
                        break;
                    case 4:
                        ViewPersonsByCityOrState();
                        break;
                    case 5:
                        CountPersonsByCityOrState();
                        break;
                    case 0:
                        Console.WriteLine("Program Ended");
                        break;
                    default:
                        Console.WriteLine("Invalid Choice");
                        break;
                }

            } while (choice != 0);
        }

        private static void CreateNewAddressBook()
        {
            if (bookCount >= addressBooks.Length)
            {
                Console.WriteLine("Maximum Address Books reached!\n");
                return;
            }

            Console.Write("Enter Name for New Address Book: ");
            string name = Console.ReadLine();

            // Check if name is unique
            for (int i = 0; i < bookCount; i++)
            {
                if (addressBookNames[i] == name)
                {
                    Console.WriteLine("Address Book with this name already exists!\n");
                    return;
                }
            }

            AddressBookImpl newBook = new AddressBookImpl(name);
            addressBooks[bookCount] = newBook;
            addressBookNames[bookCount] = name;
            bookCount++;

            Console.WriteLine($"Address Book '{name}' Created Successfully\n");
        }


        private static void SelectAddressBook()
        {
            if (bookCount == 0)
            {
                Console.WriteLine("No Address Books available. Create one first!\n");
                return;
            }

            Console.WriteLine("\nAvailable Address Books:");
            for (int i = 0; i < bookCount; i++)
                Console.WriteLine($"{i + 1}. {addressBookNames[i]}");

            Console.Write("Select Address Book by number: ");
            int choice = Convert.ToInt32(Console.ReadLine());

            if (choice < 1 || choice > bookCount)
            {
                Console.WriteLine("Invalid Choice\n");
                return;
            }

            AddressBookImpl selectedBook = addressBooks[choice - 1];
            Console.WriteLine($"\n--- Selected Address Book: {selectedBook.Name} ---");
            AddressBookMenu(selectedBook);
        }


        public static void AddressBookMenu(AddressBookImpl book)
        {
            int choice;

            do
            {
                // Display menu options
                Console.WriteLine($"\n--- Address Book: {book.Name} ---");
                Console.WriteLine("1. Add Contact");
                Console.WriteLine("2. Edit Contact");
                Console.WriteLine("3. Delete Contact");
                Console.WriteLine("4. Add Multiple Contacts");
                Console.WriteLine("5. Sort Contacts by Name");
                Console.WriteLine("0. Exit");
                Console.Write("Enter your choice: ");

                choice = Convert.ToInt32(Console.ReadLine()); // Read user choice

                // Perform action based on user choice
                switch (choice)
                {
                    case 1:
                        book.AddContact(); // Call method to add a contact
                        break;

                    case 2:
                        book.EditContact();
                        break;

                    case 3:
                        book.DeleteContact();
                        break;
                    case 4:
                        book.AddMultipleContactsMenu();
                        break;

                    case 5:
                        book.SortContactsByName();
                        break;

                    case 0:
                        break;

                    default:
                       Console.WriteLine("Invalid Choice"); // Handle wrong input
                        break;
                }

            } while (choice != 0); // Loop until user chooses to exit

        }
        //UC-8:Ability to search Person in a City or State across the multiple Addres search Result
        private static void SearchAcrossAddressBooks()
        {
            Console.WriteLine("1. Search by City");
            Console.WriteLine("2. Search by State");

            int choice = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter value: ");
            string value = Console.ReadLine();

            for (int i = 0; i < bookCount; i++)
            {
                if (choice == 1)
                    addressBooks[i].SearchByCity(value);
                else
                    addressBooks[i].SearchByState(value);
            }
        }
        //UC-9:Ability to view Persons by City or State
        private static void ViewPersonsByCityOrState()
        {
            cityCount = 0;
            stateCount = 0;

            for (int i = 0; i < bookCount; i++)
            {
                addressBooks[i].AddToCityStateMap(
                    cityNames, cityPersons, ref cityCount,
                    stateNames, statePersons, ref stateCount
                );
            }

            Console.WriteLine("1. View by City");
            Console.WriteLine("2. View by State");

            int choice = Convert.ToInt32(Console.ReadLine());

            if (choice == 1)
            {
                for (int i = 0; i < cityCount; i++)
                    Console.WriteLine($"{cityNames[i]} -> {cityPersons[i]}");
            }
            else if (choice == 2)
            {
                for (int i = 0; i < stateCount; i++)
                    Console.WriteLine($"{stateNames[i]} -> {statePersons[i]}");
            }
        }



        // UC-10: Ability to get number of contact persons by City or State
        private static void CountPersonsByCityOrState()
        {
            Console.WriteLine("1. Count by City");
            Console.WriteLine("2. Count by State");

            int choice = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter value: ");
            string value = Console.ReadLine();

            int totalCount = 0;

            for (int i = 0; i < bookCount; i++)
            {
                if (choice == 1)
                    totalCount += addressBooks[i].GetCountByCity(value);
                else if (choice == 2)
                    totalCount += addressBooks[i].GetCountByState(value);
            }

            if (choice == 1)
                Console.WriteLine($"Total Contacts in City '{value}' : {totalCount}");
            else
                Console.WriteLine($"Total Contacts in State '{value}' : {totalCount}");
        }

    }
}
