using System.Collections.Generic;

namespace BridgeLabzTraining.oops_csharp_practice.scenario_based.address_book
{
    // Interface defining all operations supported by an Address Book
    internal interface IAddressBook
    {
        void AddContact();
        void EditContact();
        void DeleteContact();
        void AddMultipleContactsMenu();
        void SearchByCity(string city);
        void SearchByState(string state);
        int GetCountByCity(string city);
        int GetCountByState(string state);
        void SortContactsByName();
        void SortContactsByCity();
        void SortContactsByState();
        void SortContactsByZip();
        void DisplayAllContacts();
        void AddToCityStateDictionary(
            Dictionary<string, List<string>> cityMap,
            Dictionary<string, List<string>> stateMap
        );
    }
}
