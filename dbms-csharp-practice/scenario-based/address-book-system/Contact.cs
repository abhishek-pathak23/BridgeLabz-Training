internal class Contact
{
    public int ContactId { get; set; }   // ADD THIS

    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Address { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string Zip { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public int AddressBookId { get; set; }


    public override string ToString()
    {
        return $"{ContactId} | {FirstName} {LastName}, {City}, {State}, {PhoneNumber}";
    }
}
