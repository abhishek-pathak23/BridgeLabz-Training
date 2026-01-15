using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.oops_csharp_practice.scenario_based.address_book
{
    internal class AddressBookMain
    {
        // Entry point of the Address Book application
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Address Book Program\n"); // Greeting message

            // Display the main menu and handle user choices
            MenuManager.DisplayMenu();
        }
    }
}
