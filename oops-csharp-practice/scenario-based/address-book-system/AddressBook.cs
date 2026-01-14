// UC-1 Ability to create a Contacts in Address Book with first and last names, address,city, state, zip, phone number and email…

using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzDup.oops_csharp_practice.scenario_based.address_book_system
{
    internal class AddressBook : IAddressBook
    {
        // Holds the details of a single contact
        private Contact contact;

        // Method to add a new contact to the address book
        public void AddContact()
        {
            contact = new Contact(); // Create a new Contact object

            // Get contact details from user input
            Console.Write("Enter First Name: ");
            contact.FirstName = Console.ReadLine();

            Console.Write("Enter Last Name: ");
            contact.LastName = Console.ReadLine();

            Console.Write("Enter Address: ");
            contact.Address = Console.ReadLine();

            Console.Write("Enter City: ");
            contact.City = Console.ReadLine();

            Console.Write("Enter State: ");
            contact.State = Console.ReadLine();

            Console.Write("Enter Zip: ");
            contact.Zip = Console.ReadLine();

            Console.Write("Enter Phone Number: ");
            contact.PhoneNumber = Console.ReadLine();

            Console.Write("Enter Email: ");
            contact.Email = Console.ReadLine();

            Console.WriteLine("\nContact Added Successfully\n"); // Confirmation message
        }
    }
}
