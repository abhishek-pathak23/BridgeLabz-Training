using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzDup.oops_csharp_practice.scenario_based.address_book_system
{
    // Represents a single contact in the address book
    internal class Contact
    {
        public string FirstName { get; set; }   // Contact's first name
        public string LastName { get; set; }    // Contact's last name
        public string Address { get; set; }     // Street address
        public string City { get; set; }        // City
        public string State { get; set; }       // State
        public string Zip { get; set; }         // ZIP code
        public string PhoneNumber { get; set; } // Phone number
        public string Email { get; set; }       // Email address
    }
}
