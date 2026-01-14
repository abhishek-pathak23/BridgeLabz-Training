using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzDup.oops_csharp_practice.scenario_based.address_book_system
{
    internal class MenuManager
    {
        public static void DisplayMenu()
        {
            IAddressBook addressBook = new AddressBook();
            int choice;

            do
            {
                Console.WriteLine("1. Add Contact");  // Menu's displayed to the user
                Console.WriteLine("2. Edit Contact");
                Console.WriteLine("3. Delete Contact");
                Console.WriteLine("0. Exit");
                Console.Write("Enter your choice: ");

                choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        addressBook.AddContact();
                        break;

                    case 2:
                        addressBook.EditContact();
                        break;

                    case 3:
                        addressBook.DeleteContact();
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
    }
}
