using System;
using System.Collections.Generic;
using System.Linq;

namespace BridgeLabzTraining.oops_csharp_practice.scenario_based.address_book
{
    // Implements all address book functionalities
    internal class AddressBookImpl : IAddressBook
    {
        // Using List collection instead of fixed-size array
        private List<Contact> contacts = new List<Contact>();

        // Name of this address book
        public string Name { get; set; }

        public AddressBookImpl(string name)
        {
            Name = name;
        }

        // Adds a new contact to the list
        public void AddContact()
        {
            try // NEW: Exception Handling
            {
                Contact contact = new Contact();

                Console.Write("Enter First Name: ");
                contact.FirstName = Console.ReadLine() ?? "";

                Console.Write("Enter Last Name: ");
                contact.LastName = Console.ReadLine() ?? "";

                // Duplicate check using List.Contains (uses overridden Equals)
                if (contacts.Contains(contact))
                {
                    Console.WriteLine("Duplicate contact found.\n");
                    return;
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

                contacts.Add(contact);
                Console.WriteLine("Contact added successfully.\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error while adding contact: " + ex.Message);
            }
        }

        public void EditContact()
        {
            try
            {
                Console.Write("Enter First Name to Edit: ");
                string name = Console.ReadLine() ?? "";

                var contact = contacts.FirstOrDefault(c => c.FirstName == name);

                if (contact != null)
                {
                    Console.Write("Enter New City: ");
                    contact.City = Console.ReadLine() ?? "";
                    Console.WriteLine("Contact updated.\n");
                }
                else
                {
                    Console.WriteLine("Contact not found.\n");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error while editing: " + ex.Message);
            }
        }

        public void DeleteContact()
        {
            try
            {
                Console.Write("Enter First Name to Delete: ");
                string name = Console.ReadLine() ?? "";

                var contact = contacts.FirstOrDefault(c => c.FirstName == name);

                if (contact != null)
                {
                    contacts.Remove(contact);
                    Console.WriteLine("Contact deleted.\n");
                }
                else
                {
                    Console.WriteLine("Contact not found.\n");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error while deleting: " + ex.Message);
            }
        }

        public void AddMultipleContactsMenu()
        {
            int choice;
            do
            {
                try // NEW
                {
                    Console.WriteLine("\n1. Add New Contact");
                    Console.WriteLine("0. Go Back");
                    choice = Convert.ToInt32(Console.ReadLine());

                    if (choice == 1)
                        AddContact();
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                    choice = -1;
                }

            } while (choice != 0);
        }

        // Other methods remain same (search/count/sort/display)
        // No threading here (threading handled in MenuManager for multiple books)

        public void SearchByCity(string city)
        {
            var results = contacts.Where(c => c.City == city);
            foreach (var contact in results)
                Console.WriteLine($"{contact.FirstName} {contact.LastName} | {Name}");
        }

        public void SearchByState(string state)
        {
            var results = contacts.Where(c => c.State == state);
            foreach (var contact in results)
                Console.WriteLine($"{contact.FirstName} {contact.LastName} | {Name}");
        }

        public int GetCountByCity(string city)
        {
            return contacts.Count(c => c.City == city);
        }

        public int GetCountByState(string state)
        {
            return contacts.Count(c => c.State == state);
        }

        public void SortContactsByName()
        {
            contacts.Sort((a, b) => a.FirstName.CompareTo(b.FirstName));
            Console.WriteLine("Sorted by Name.\n");
        }

        public void SortContactsByCity()
        {
            contacts.Sort((a, b) => a.City.CompareTo(b.City));
            Console.WriteLine("Sorted by City.\n");
        }

        public void SortContactsByState()
        {
            contacts.Sort((a, b) => a.State.CompareTo(b.State));
            Console.WriteLine("Sorted by State.\n");
        }

        public void SortContactsByZip()
        {
            contacts.Sort((a, b) => a.Zip.CompareTo(b.Zip));
            Console.WriteLine("Sorted by Zip.\n");
        }

        public void DisplayAllContacts()
        {
            foreach (var contact in contacts)
                Console.WriteLine(contact);
        }

        public void AddToCityStateDictionary(
            Dictionary<string, List<string>> cityMap,
            Dictionary<string, List<string>> stateMap)
        {
            foreach (var contact in contacts)
            {
                if (!cityMap.ContainsKey(contact.City))
                    cityMap[contact.City] = new List<string>();

                cityMap[contact.City].Add(contact.FirstName + " " + contact.LastName);

                if (!stateMap.ContainsKey(contact.State))
                    stateMap[contact.State] = new List<string>();

                stateMap[contact.State].Add(contact.FirstName + " " + contact.LastName);
            }
        }
    }
}
