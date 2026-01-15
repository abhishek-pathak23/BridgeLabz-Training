using System;

namespace BridgeLabzDup.oops_csharp_practice.scenario_based.address_book_system
{
    internal class AddressBook : IAddressBook
    {
        private Contact[] contacts = new Contact[50];
        private int count = 0;

        public string Name;

        public AddressBook(string name)
        {
            Name = name;
        }

        // UC-7
        public void AddContact()
        {
            if (count >= contacts.Length)
            {
                Console.WriteLine("Address Book is Full\n");
                return;
            }

            Contact contact = new Contact();

            Console.Write("Enter First Name: ");
            contact.FirstName = Console.ReadLine();

            Console.Write("Enter Last Name: ");
            contact.LastName = Console.ReadLine();

            for (int i = 0; i < count; i++)
            {
                if (contacts[i].Equals(contact))
                {
                    Console.WriteLine("Duplicate Contact Found. Cannot Add Same Person Again\n");
                    return;
                }
            }

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

            contacts[count++] = contact;
            Console.WriteLine("Contact Added Successfully\n");
        }

        public void AddMultipleContactsMenu()
        {
            int choice;
            do
            {
                Console.WriteLine($"\n--- Add Contacts to Address Book: {Name} ---");
                Console.WriteLine("1. Add New Contact");
                Console.WriteLine("0. Go Back");

                choice = Convert.ToInt32(Console.ReadLine());

                if (choice == 1)
                    AddContact();

            } while (choice != 0);
        }

        public void EditContact()
        {
            Console.Write("Enter First Name to Edit: ");
            string name = Console.ReadLine();

            for (int i = 0; i < count; i++)
            {
                if (contacts[i].FirstName == name)
                {
                    Console.Write("Enter New City: ");
                    contacts[i].City = Console.ReadLine();
                    Console.WriteLine("Contact Updated\n");
                    return;
                }
            }

            Console.WriteLine("Contact Not Found\n");
        }

        public void DeleteContact()
        {
            Console.Write("Enter First Name to Delete: ");
            string name = Console.ReadLine();

            for (int i = 0; i < count; i++)
            {
                if (contacts[i].FirstName == name)
                {
                    for (int j = i; j < count - 1; j++)
                        contacts[j] = contacts[j + 1];

                    contacts[--count] = null;
                    Console.WriteLine("Contact Deleted\n");
                    return;
                }
            }

            Console.WriteLine("Contact Not Found\n");
        }

        // UC-8
        public void SearchByCity(string city)
        {
            for (int i = 0; i < count; i++)
            {
                if (contacts[i].City == city)
                    Console.WriteLine($"{contacts[i].FirstName} {contacts[i].LastName} | {Name}");
            }
        }

        public void SearchByState(string state)
        {
            for (int i = 0; i < count; i++)
            {
                if (contacts[i].State == state)
                    Console.WriteLine($"{contacts[i].FirstName} {contacts[i].LastName} | {Name}");
            }
        }
    }
}
