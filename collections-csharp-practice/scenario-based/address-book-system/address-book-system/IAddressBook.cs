using System.Collections.Generic;

namespace BridgeLabzTraining.oops_csharp_practice.scenario_based.address_book
{
    // Interface defining all operations supported by an Address Book
    internal interface IAddressBook
    {
        // Create operation
        void AddContact();

        // Update operation
        void EditContact();

        // Delete operation
        void DeleteContact();

        // Allows adding multiple contacts via menu
        void AddMultipleContactsMenu();

        // Search operations
        void SearchByCity(string city);
        void SearchByState(string state);

        // Count operations
        int GetCountByCity(string city);
        int GetCountByState(string state);

        // Sorting operations
        void SortContactsByName();
        void SortContactsByCity();
        void SortContactsByState();
        void SortContactsByZip();

        // Display all contacts in the address book
        void DisplayAllContacts();

        // Add entries into city and state dictionaries
        void AddToCityStateDictionary(
            Dictionary<string, List<string>> cityMap,
            Dictionary<string, List<string>> stateMap
        );
    }
}
