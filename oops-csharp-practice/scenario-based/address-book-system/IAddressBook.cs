using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.oops_csharp_practice.scenario_based.address_book
{
    // Interface for Address Book operations
    internal interface IAddressBook
    {
        // Method to add a new contact
        void AddContact();
        //method to edit contact
        void EditContact();
        //method to delete contact
        void DeleteContact();
        //method for add multiple contacts menu
        void AddMultipleContactsMenu();
        //method to serach by city
        void SearchByCity(string city);
        //method to search by state
        void SearchByState(string state);
        // count by city
        int GetCountByCity(string city);

        // count by state
        int GetCountByState(string state);

    }
}
