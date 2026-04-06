using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BridgeLabzTraining.oops_csharp_practice.scenario_based.address_book
{
    internal class AddressBookImpl : IAddressBook
    {


        private Contact[] contacts = new Contact[50];
        private int count = 0;

        public string Name; // Name of this Address Book

        public AddressBookImpl(string name)
        {
            Name = name;
        }

        //UC-2:Ability to add a new Contact to Address Book
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

            // Duplicate check
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

            contacts[count] = contact;
            count++;

            Console.WriteLine("Contact Added Successfully\n");
        }
        //UC-3:Ability to add a new Contact to Address Book
        public void EditContact()
        {
            Console.Write("Enter First Name to Edit Contact: ");
            string name = Console.ReadLine();

            for (int i = 0; i < count; i++)
            {
                if (contacts[i].FirstName == name)
                {
                    Console.Write("Enter New Address: ");
                    contacts[i].Address = Console.ReadLine();

                    Console.Write("Enter New City: ");
                    contacts[i].City = Console.ReadLine();

                    Console.Write("Enter New State: ");
                    contacts[i].State = Console.ReadLine();

                    Console.Write("Enter New Zip: ");
                    contacts[i].Zip = Console.ReadLine();

                    Console.Write("Enter New Phone Number: ");
                    contacts[i].PhoneNumber = Console.ReadLine();

                    Console.Write("Enter New Email: ");
                    contacts[i].Email = Console.ReadLine();

                    Console.WriteLine("\nContact Updated Successfully\n");
                    return;
                }
            }
            Console.WriteLine("Contact Not Found\n");
        }
        //UC-4:Ability to delete a person using person's name
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

                    contacts[count - 1] = null;
                    count--;

                    Console.WriteLine("Contact Deleted Successfully\n");
                    return;
                }
            }

            Console.WriteLine("Contact Not Found\n");
        }

        //UC-5:Ability to add multiple person to Address Book
        public void AddMultipleContactsMenu()
        {
            int choice;

            do
            {
                Console.WriteLine("\n--- Add Multiple Contacts ---");
                Console.WriteLine("1. Add New Contact");
                Console.WriteLine("0. Go Back");
                Console.Write("Enter Choice: ");

                choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        AddContact();
                        break;

                    case 0:
                        break;

                    default:
                        Console.WriteLine("Invalid Choice");
                        break;
                }

            } while (choice != 0);
        }

        // UC-8:Ability to search Person in a City or State across the multiple Addres search Result
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



        // UC-9:Ability to view Persons by City or State
        public void AddToCityStateMap(
            string[] cities, string[] cityPersons, ref int cityCount,
            string[] states, string[] statePersons, ref int stateCount)
        {
            for (int i = 0; i < count; i++)
            {
                string fullName = contacts[i].FirstName + " " + contacts[i].LastName;

                // CITY
                int cityIndex = -1;
                for (int c = 0; c < cityCount; c++)
                {
                    if (cities[c] == contacts[i].City)
                    {
                        cityIndex = c;
                        break;
                    }
                }

                if (cityIndex == -1)
                {
                    cities[cityCount] = contacts[i].City;
                    cityPersons[cityCount] = fullName;
                    cityCount++;
                }
                else
                {
                    cityPersons[cityIndex] += ", " + fullName;
                }

                // STATE
                int stateIndex = -1;
                for (int s = 0; s < stateCount; s++)
                {
                    if (states[s] == contacts[i].State)
                    {
                        stateIndex = s;
                        break;
                    }
                }

                if (stateIndex == -1)
                {
                    states[stateCount] = contacts[i].State;
                    statePersons[stateCount] = fullName;
                    stateCount++;
                }
                else
                {
                    statePersons[stateIndex] += ", " + fullName;
                }
            }
        }


        // UC-10: Ability to get number of contact persons by City
        public int GetCountByCity(string city)
        {
            int cityCount = 0;
            for (int i = 0; i < count; i++)
            {
                if (contacts[i].City == city)
                    cityCount++;
            }
            return cityCount;
        }

        // UC-10: Ability to get number of contact persons by State
        public int GetCountByState(string state)
        {
            int stateCount = 0;
            for (int i = 0; i < count; i++)
            {
                if (contacts[i].State == state)
                    stateCount++;
            }
            return stateCount;
        }


        // UC-11: Ability to sort contacts alphabetically by First Name
        public void SortContactsByName()
        {
            for (int i = 0; i < count - 1; i++)
            {
                for (int j = i + 1; j < count; j++)
                {
                    // Compare First Names
                    if (string.Compare(contacts[i].FirstName, contacts[j].FirstName) > 0)
                    {
                        // Swap contacts
                        Contact temp = contacts[i];
                        contacts[i] = contacts[j];
                        contacts[j] = temp;
                    }
                }
            }

            Console.WriteLine("\n--- Contacts Sorted Alphabetically ---");
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine(contacts[i].ToString());
            }
        }

    }
}
