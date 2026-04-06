using System;
using System.Collections.Generic;
using System.Linq;

namespace BridgeLabzTraining.oops_csharp_practice.scenario_based.address_book
{
    // Represents a single address book and manages its contacts
    internal class AddressBook : IAddressBook
    {
        // Dynamic list to store contacts
        private List<Contact> contacts = new List<Contact>();

        // NEW: Lock object for thread safety
        private readonly object _lock = new object();

        // Name of this Address Book
        public string Name { get; set; }

        public AddressBook(string name)
        {
            Name = name;
        }

        // Adds a new contact after duplicate check
        public void AddContact()
        {
            try // NEW: Exception Handling
            {
                Contact contact = new Contact();

                Console.Write("Enter First Name: ");
                contact.FirstName = Console.ReadLine() ?? "";

                Console.Write("Enter Last Name: ");
                contact.LastName = Console.ReadLine() ?? "";

                lock (_lock) // NEW: Thread safety
                {
                    // Check duplicate using overridden Equals()
                    if (contacts.Contains(contact))
                    {
                        Console.WriteLine("Duplicate contact found. Cannot add again.\n");
                        return;
                    }
                }

                Console.Write("Enter Address: ");
                contact.Address = Console.ReadLine() ?? "";

                Console.Write("Enter City: ");
                contact.City = Console.ReadLine() ?? "";

                Console.Write("Enter State: ");
                contact.State = Console.ReadLine() ?? "";

                Console.Write("Enter Zip: ");
                contact.Zip = Console.ReadLine() ?? "";

                Console.Write("Enter Phone Number: ");
                contact.PhoneNumber = Console.ReadLine() ?? "";

                Console.Write("Enter Email: ");
                contact.Email = Console.ReadLine() ?? "";

                lock (_lock) // NEW: Thread safety for add
                {
                    contacts.Add(contact);
                }

                Console.WriteLine("Contact added successfully.\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error adding contact: " + ex.Message);
            }
        }

        // Allows user to add multiple contacts
        public void AddMultipleContactsMenu()
        {
            int choice;

            do
            {
                try // NEW
                {
                    Console.WriteLine($"\n--- Add Contacts to Address Book: {Name} ---");
                    Console.WriteLine("1. Add New Contact");
                    Console.WriteLine("0. Go Back");

                    choice = Convert.ToInt32(Console.ReadLine());

                    if (choice == 1)
                        AddContact();
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                    choice = -1;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                    choice = -1;
                }

            } while (choice != 0);
        }

        // Edit contact city by first name
        public void EditContact()
        {
            try // NEW
            {
                Console.Write("Enter First Name to Edit: ");
                string name = Console.ReadLine() ?? "";

                lock (_lock) // NEW
                {
                    var contact = contacts.FirstOrDefault(c => c.FirstName == name);

                    if (contact != null)
                    {
                        Console.Write("Enter New City: ");
                        contact.City = Console.ReadLine() ?? "";
                        Console.WriteLine("Contact updated successfully.\n");
                    }
                    else
                    {
                        Console.WriteLine("Contact not found.\n");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error editing contact: " + ex.Message);
            }
        }

        // Delete contact by first name
        public void DeleteContact()
        {
            try // NEW
            {
                Console.Write("Enter First Name to Delete: ");
                string name = Console.ReadLine() ?? "";

                lock (_lock) // NEW
                {
                    var contact = contacts.FirstOrDefault(c => c.FirstName == name);

                    if (contact != null)
                    {
                        contacts.Remove(contact);
                        Console.WriteLine("Contact deleted successfully.\n");
                    }
                    else
                    {
                        Console.WriteLine("Contact not found.\n");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error deleting contact: " + ex.Message);
            }
        }

        // Display all contacts in this Address Book
        public void DisplayAllContacts()
        {
            try // NEW
            {
                lock (_lock) // NEW
                {
                    if (contacts.Count == 0)
                    {
                        Console.WriteLine("No contacts found.\n");
                        return;
                    }

                    Console.WriteLine($"\n--- Contacts in Address Book: {Name} ---");

                    foreach (var contact in contacts)
                    {
                        Console.WriteLine(contact);
                    }

                    Console.WriteLine();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error displaying contacts: " + ex.Message);
            }
        }

        // Search by city
        public void SearchByCity(string city)
        {
            lock (_lock) // NEW
            {
                var results = contacts.Where(c => c.City == city);

                foreach (var contact in results)
                    Console.WriteLine($"{contact.FirstName} {contact.LastName} | {Name}");
            }
        }

        // Search by state
        public void SearchByState(string state)
        {
            lock (_lock) // NEW
            {
                var results = contacts.Where(c => c.State == state);

                foreach (var contact in results)
                    Console.WriteLine($"{contact.FirstName} {contact.LastName} | {Name}");
            }
        }

        // Count contacts in city
        public int GetCountByCity(string city)
        {
            lock (_lock) // NEW
            {
                return contacts.Count(c => c.City == city);
            }
        }

        // Count contacts in state
        public int GetCountByState(string state)
        {
            lock (_lock) // NEW
            {
                return contacts.Count(c => c.State == state);
            }
        }

        // Add entries to city and state dictionary
        public void AddToCityStateDictionary(
            Dictionary<string, List<string>> cityDictionary,
            Dictionary<string, List<string>> stateDictionary)
        {
            lock (_lock) // NEW
            {
                foreach (var contact in contacts)
                {
                    // City Dictionary
                    if (!cityDictionary.ContainsKey(contact.City))
                        cityDictionary[contact.City] = new List<string>();

                    cityDictionary[contact.City].Add($"{contact.FirstName} {contact.LastName}");

                    // State Dictionary
                    if (!stateDictionary.ContainsKey(contact.State))
                        stateDictionary[contact.State] = new List<string>();

                    stateDictionary[contact.State].Add($"{contact.FirstName} {contact.LastName}");
                }
            }
        }

        // Sort by Name
        public void SortContactsByName()
        {
            lock (_lock) // NEW
            {
                contacts.Sort((a, b) => a.FirstName.CompareTo(b.FirstName));
            }
            Console.WriteLine("Contacts sorted by Name.\n");
        }

        // Sort by City
        public void SortContactsByCity()
        {
            lock (_lock) // NEW
            {
                contacts.Sort((a, b) => a.City.CompareTo(b.City));
            }
            Console.WriteLine("Contacts sorted by City.\n");
        }

        // Sort by State
        public void SortContactsByState()
        {
            lock (_lock) // NEW
            {
                contacts.Sort((a, b) => a.State.CompareTo(b.State));
            }
            Console.WriteLine("Contacts sorted by State.\n");
        }

        // Sort by Zip
        public void SortContactsByZip()
        {
            lock (_lock) // NEW
            {
                contacts.Sort((a, b) => a.Zip.CompareTo(b.Zip));
            }
            Console.WriteLine("Contacts sorted by Zip.\n");
        }
    }
}
