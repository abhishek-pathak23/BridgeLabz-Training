using System;

namespace BridgeLabzTraining.oops_csharp_practice.scenario_based.address_book
{
    // Application entry point
    internal class AddressBookMain
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Welcome to Address Book Program");
                MenuManager.DisplayMenu();
            }
            catch (Exception ex) // NEW: Global Exception Handling
            {
                Console.WriteLine("Unexpected error occurred: " + ex.Message);
            }
        }
    }
}
