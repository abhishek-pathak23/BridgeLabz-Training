using System;
using System.Collections.Generic;
using System.Threading.Tasks; // NEW: For Multithreading

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
                try // NEW: Exception Handling Added
                {
                    Console.WriteLine("\n--- Multiple Address Book Menu ---");
                    Console.WriteLine("1. Create New Address Book");
                    Console.WriteLine("2. Select Address Book");
                    Console.WriteLine("3. Search Person (City/State)");
                    Console.WriteLine("4. View Persons by City or State");
                    Console.WriteLine("5. Count Persons by City or State");
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
                            ViewPersonsByCityOrState();
                            break;
                        case 5:
                            CountPersonsByCityOrState();
                            break;
                        case 0:
                            Console.WriteLine("Exiting program...");
                            break;
                        default:
                            Console.WriteLine("Invalid choice. Try again.");
                            break;
                    }
                }
                catch (FormatException) // NEW
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                    choice = -1;
                }
                catch (Exception ex) // NEW
                {
                    Console.WriteLine("Unexpected error: " + ex.Message);
                    choice = -1;
                }

            } while (choice != 0);
        }

        private static void CreateNewAddressBook()
        {
            try // NEW
            {
                Console.Write("Enter Address Book Name: ");
                string name = Console.ReadLine();

                if (addressBooks.Exists(b => b.Name == name))
                {
                    Console.WriteLine("Address Book already exists.\n");
                    return;
                }

                addressBooks.Add(new AddressBookImpl(name));
                Console.WriteLine("Address Book created.\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error creating address book: " + ex.Message);
            }
        }

        private static void SelectAddressBook()
        {
            try // NEW
            {
                if (addressBooks.Count == 0)
                {
                    Console.WriteLine("No address books available.\n");
                    return;
                }

                for (int i = 0; i < addressBooks.Count; i++)
                    Console.WriteLine($"{i + 1}. {addressBooks[i].Name}");

                int choice = Convert.ToInt32(Console.ReadLine());

                if (choice >= 1 && choice <= addressBooks.Count)
                    AddressBookMenu(addressBooks[choice - 1]);
                else
                    Console.WriteLine("Invalid selection.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error selecting address book: " + ex.Message);
            }
        }

        private static void AddressBookMenu(AddressBookImpl book)
        {
            int choice;

            do
            {
                try // NEW
                {
                    Console.WriteLine($"\n--- Address Book: {book.Name} ---");
                    Console.WriteLine("1. Add Contact");
                    Console.WriteLine("2. Edit Contact");
                    Console.WriteLine("3. Delete Contact");
                    Console.WriteLine("4. Add Multiple Contacts");
                    Console.WriteLine("5. Sort by Name");
                    Console.WriteLine("6. Sort by City");
                    Console.WriteLine("7. Sort by State");
                    Console.WriteLine("8. Sort by Zip");
                    Console.WriteLine("9. Display All Contacts");
                    Console.WriteLine("0. Back");

                    choice = Convert.ToInt32(Console.ReadLine());

                    switch (choice)
                    {
                        case 1: book.AddContact(); break;
                        case 2: book.EditContact(); break;
                        case 3: book.DeleteContact(); break;
                        case 4: book.AddMultipleContactsMenu(); break;
                        case 5: book.SortContactsByName(); break;
                        case 6: book.SortContactsByCity(); break;
                        case 7: book.SortContactsByState(); break;
                        case 8: book.SortContactsByZip(); break;
                        case 9: book.DisplayAllContacts(); break;
                        case 0: break;
                        default:
                            Console.WriteLine("Invalid choice.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error in address book menu: " + ex.Message);
                    choice = -1;
                }

            } while (choice != 0);
        }

        private static void SearchAcrossBooks()
        {
            try
            {
                Console.WriteLine("1. Search by City");
                Console.WriteLine("2. Search by State");

                int choice = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter value: ");
                string value = Console.ReadLine();

                // NEW: Multithreading using Task for parallel search
                List<Task> tasks = new List<Task>();

                foreach (var book in addressBooks)
                {
                    tasks.Add(Task.Run(() =>
                    {
                        if (choice == 1)
                            book.SearchByCity(value);
                        else
                            book.SearchByState(value);
                    }));
                }

                Task.WaitAll(tasks.ToArray()); // Wait for all tasks to complete
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error during search: " + ex.Message);
            }
        }

        private static void ViewPersonsByCityOrState()
        {
            try
            {
                var cityMap = new Dictionary<string, List<string>>();
                var stateMap = new Dictionary<string, List<string>>();

                // NEW: Multithreading for building dictionaries
                List<Task> tasks = new List<Task>();

                foreach (var book in addressBooks)
                {
                    tasks.Add(Task.Run(() =>
                    {
                        lock (cityMap) // NEW: Thread safety
                        {
                            book.AddToCityStateDictionary(cityMap, stateMap);
                        }
                    }));
                }

                Task.WaitAll(tasks.ToArray());

                Console.WriteLine("1. View by City");
                Console.WriteLine("2. View by State");

                int choice = Convert.ToInt32(Console.ReadLine());

                if (choice == 1)
                {
                    foreach (var entry in cityMap)
                        foreach (var person in entry.Value)
                            Console.WriteLine($"{entry.Key} -> {person}");
                }
                else
                {
                    foreach (var entry in stateMap)
                        foreach (var person in entry.Value)
                            Console.WriteLine($"{entry.Key} -> {person}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error viewing persons: " + ex.Message);
            }
        }

        private static void CountPersonsByCityOrState()
        {
            try
            {
                Console.WriteLine("1. Count by City");
                Console.WriteLine("2. Count by State");

                int choice = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter value: ");
                string value = Console.ReadLine();

                int total = 0;

                // NEW: Multithreading for counting
                List<Task<int>> tasks = new List<Task<int>>();

                foreach (var book in addressBooks)
                {
                    tasks.Add(Task.Run(() =>
                    {
                        if (choice == 1)
                            return book.GetCountByCity(value);
                        else
                            return book.GetCountByState(value);
                    }));
                }

                Task.WaitAll(tasks.ToArray());

                foreach (var task in tasks)
                    total += task.Result;

                Console.WriteLine($"Total Count: {total}\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error during count: " + ex.Message);
            }
        }
    }
}
