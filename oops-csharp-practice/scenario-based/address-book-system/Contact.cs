using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.oops_csharp_practice.scenario_based.address_book
{
    // Represents a single contact in the address book

        //UC 1:Ability to create a Contacts in Address Book with first and last names, address,city, state, zip, phone number and email
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


        // UC-7: Override Equals to check duplicate person by name
        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Contact))
                return false;

            Contact other = (Contact)obj;

            return this.FirstName == other.FirstName &&
                   this.LastName == other.LastName;
        }


    }
}
