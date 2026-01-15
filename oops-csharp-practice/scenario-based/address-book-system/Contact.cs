using System;

namespace BridgeLabzDup.oops_csharp_practice.scenario_based.address_book_system
{
    internal class Contact
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        // UC-7: Duplicate check by person name
        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Contact))
                return false;

            Contact other = (Contact)obj;
            return FirstName == other.FirstName && LastName == other.LastName;
        }
    }
}
