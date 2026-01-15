//uc-8 Ability to search Person in a City or State across the multiple Address Book 
using System;

namespace BridgeLabzDup.oops_csharp_practice.scenario_based.address_book_system
{
    internal class MenuManager
    {
        private static AddressBook[] addressBooks = new AddressBook[10];
        private static string[] addressBookNames = new string[10];
        private static int bookCount = 0;

        public static void DisplayMenu()
        {
            int choice;

            do
            {
                Console.WriteLine("\n--- Multiple Address Book Menu ---");
                Console.WriteLine("1. Create New Address Book");
                Console.WriteLine("2. Select Address Book");
                Console.WriteLine("3. Search Person (City/State)");
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
                        SearchAcrossAddressBooks();
                        break;
                }

            } while (choice != 0);
        }

        private static void CreateNewAddressBook()
        {
            Console.Write("Enter Name for New Address Book: ");
            addressBookNames[bookCount] = Console.ReadLine();
            addressBooks[bookCount] = new AddressBook(addressBookNames[bookCount]);
            bookCount++;
        }

        private static void SelectAddressBook()
        {
            for (int i = 0; i < bookCount; i++)
                Console.WriteLine($"{i + 1}. {addressBookNames[i]}");

            int choice = Convert.ToInt32(Console.ReadLine());
            AddressBookMenu(addressBooks[choice - 1]);
        }

        private static void AddressBookMenu(AddressBook book)
        {
            int choice;
            do
            {
                Console.WriteLine($"\n--- Address Book: {book.Name} ---");
                Console.WriteLine("1. Add Contact");
                Console.WriteLine("2. Add Multiple Contacts");
                Console.WriteLine("3. Edit Contact");
                Console.WriteLine("4. Delete Contact");
                Console.WriteLine("0. Go Back");

                choice = Convert.ToInt32(Console.ReadLine());

                if (choice == 1) book.AddContact();
                if (choice == 2) book.AddMultipleContactsMenu();
                if (choice == 3) book.EditContact();
                if (choice == 4) book.DeleteContact();

            } while (choice != 0);
        }

        // UC-8
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
    }
}
