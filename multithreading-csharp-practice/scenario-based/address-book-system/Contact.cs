using System;

namespace BridgeLabzTraining.oops_csharp_practice.scenario_based.address_book
{
    // Represents a single person in the address book
    internal class Contact
    {
        // Basic contact details
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        // Used to prevent duplicate contacts (based on name)
        public override bool Equals(object obj)
        {
            if (obj is Contact other)
            {
                return FirstName == other.FirstName &&
                       LastName == other.LastName;
            }
            return false;
        }

        // Required when overriding Equals
        public override int GetHashCode()
        {
            return HashCode.Combine(FirstName, LastName);
        }

        // Displays contact in readable format
        public override string ToString()
        {
            return $"{FirstName} {LastName}, {Address}, {City}, {State}, {Zip}, {PhoneNumber}, {Email}";
        }
    }
}
