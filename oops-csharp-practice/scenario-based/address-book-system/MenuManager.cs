using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzDup.oops_csharp_practice.scenario_based.address_book_system
{
    internal class MenuManager
    {
        // Displays the main menu and handles user interactions
        public static void DisplayMenu()
        {
            IAddressBook addressBook = new AddressBook(); // Create AddressBook instance
            int choice;

            do
            {
                // Display menu options
                Console.WriteLine("1. Add Contact");
                Console.WriteLine("0. Exit");
                Console.Write("Enter your choice: ");

                choice = Convert.ToInt32(Console.ReadLine()); // Read user choice

                // Perform action based on user choice
                switch (choice)
                {
                    case 1:
                        addressBook.AddContact(); // Call method to add a contact
                        break;

                    case 0:
                        Console.WriteLine("Program Ended"); // Exit message
                        break;

                    default:
                        Console.WriteLine("Invalid Choice"); // Handle wrong input
                        break;
                }

            } while (choice != 0); // Loop until user chooses to exit
        }
    }
}
