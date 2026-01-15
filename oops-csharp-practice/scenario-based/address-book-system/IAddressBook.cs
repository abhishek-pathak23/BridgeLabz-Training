using System;

namespace BridgeLabzDup.oops_csharp_practice.scenario_based.address_book_system
{
    internal interface IAddressBook
    {
        void AddContact();
        void AddMultipleContactsMenu();
        void EditContact();
        void DeleteContact();

        // UC-8
        void SearchByCity(string city);
        void SearchByState(string state);
    }
}
