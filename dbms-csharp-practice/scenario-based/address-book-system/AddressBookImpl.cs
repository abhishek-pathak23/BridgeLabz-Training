using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using Microsoft.Data.SqlClient;


namespace BridgeLabzTraining.oops_csharp_practice.scenario_based.address_book
{
    // Implements all address book functionalities
    internal class AddressBookImpl : IAddressBook
    {
        public static string connectionString ="Server=localhost\\SQLEXPRESS;Database=AddressBookDB;Trusted_Connection=true;TrustServerCertificate=true;";


        // Name of this address book
        public string Name { get; set; }
        public int AddressBookId { get; set; }


        public AddressBookImpl(int id, string name)
{
    AddressBookId = id;
    Name = name;
}


        // Adds a new contact to the list
        public void AddContact()
{
    Contact contact = new Contact();

    Console.Write("Enter First Name: ");
    contact.FirstName = Console.ReadLine() ?? "";

    Console.Write("Enter Last Name: ");
    contact.LastName = Console.ReadLine() ?? "";

    Console.Write("Enter Address: ");
    contact.Address = Console.ReadLine() ?? "";

    Console.Write("Enter City: ");
    contact.City = Console.ReadLine() ?? "";

    Console.Write("Enter State: ");
    contact.State = Console.ReadLine() ?? "";

    Console.Write("Enter Zip: ");
    contact.Zip = Console.ReadLine() ?? "";

    Console.Write("Enter Phone Number: ");
    contact.PhoneNumber = Console.ReadLine() ?? "";

    Console.Write("Enter Email: ");
    contact.Email = Console.ReadLine() ?? "";

    using (SqlConnection con = new SqlConnection(connectionString))
    {
        string query = @"INSERT INTO Contacts
(FirstName, LastName, Address, City, State, Zip, PhoneNumber, Email, AddressBookId)
VALUES
(@FirstName, @LastName, @Address, @City, @State, @Zip, @PhoneNumber, @Email, @AddressBookId)";

        SqlCommand cmd = new SqlCommand(query, con);

        cmd.Parameters.AddWithValue("@FirstName", contact.FirstName);
        cmd.Parameters.AddWithValue("@LastName", contact.LastName);
        cmd.Parameters.AddWithValue("@Address", contact.Address);
        cmd.Parameters.AddWithValue("@City", contact.City);
        cmd.Parameters.AddWithValue("@State", contact.State);
        cmd.Parameters.AddWithValue("@Zip", contact.Zip);
        cmd.Parameters.AddWithValue("@PhoneNumber", contact.PhoneNumber);
        cmd.Parameters.AddWithValue("@Email", contact.Email);
        cmd.Parameters.AddWithValue("@AddressBookId", AddressBookId);


        con.Open();
        cmd.ExecuteNonQuery();
    }

    Console.WriteLine("Contact Added Successfully!\n");
}

           

        // Updates city for a given contact
       public void EditContact()
{
    Console.Write("Enter First Name to Edit: ");
    string name = Console.ReadLine() ?? "";

    Console.Write("Enter New City: ");
    string newCity = Console.ReadLine() ?? "";

    using (SqlConnection con = new SqlConnection(connectionString))
    {
        string query = "UPDATE Contacts SET City=@City WHERE FirstName=@FirstName";

        SqlCommand cmd = new SqlCommand(query, con);
        cmd.Parameters.AddWithValue("@City", newCity);
        cmd.Parameters.AddWithValue("@FirstName", name);

        con.Open();
        int rows = cmd.ExecuteNonQuery();

        if (rows > 0)
            Console.WriteLine("Contact Updated.\n");
        else
            Console.WriteLine("Contact Not Found.\n");
    }
}


        // Removes contact using List.Remove
       public void DeleteContact()
{
    Console.Write("Enter First Name to Delete: ");
    string name = Console.ReadLine() ?? "";

    using (SqlConnection con = new SqlConnection(connectionString))
    {
        string query = "DELETE FROM Contacts WHERE FirstName=@FirstName";

        SqlCommand cmd = new SqlCommand(query, con);
        cmd.Parameters.AddWithValue("@FirstName", name);

        con.Open();
        int rows = cmd.ExecuteNonQuery();

        if (rows > 0)
            Console.WriteLine("Contact Deleted.\n");
        else
            Console.WriteLine("Contact Not Found.\n");
    }
}


        // Allows adding multiple contacts
        public void AddMultipleContactsMenu()
        {
            int choice;
            do
            {
                Console.WriteLine("\n1. Add New Contact");
                Console.WriteLine("0. Go Back");
                choice = Convert.ToInt32(Console.ReadLine());

                if (choice == 1)
                    AddContact();

            } while (choice != 0);
        }

        // Searches contacts by city
       public void SearchByCity(string city)
{
    using (SqlConnection con = new SqlConnection(connectionString))
    {
        string query = "SELECT FirstName, LastName FROM Contacts WHERE City=@City";

        SqlCommand cmd = new SqlCommand(query, con);
        cmd.Parameters.AddWithValue("@City", city);

        con.Open();
        SqlDataReader reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            Console.WriteLine($"{reader["FirstName"]} {reader["LastName"]} | {Name}");
        }
    }
}


        // Searches contacts by state
        public void SearchByState(string state)
{
    using (SqlConnection con = new SqlConnection(connectionString))
    {
        string query = "SELECT FirstName, LastName FROM Contacts WHERE State=@State";

        SqlCommand cmd = new SqlCommand(query, con);
        cmd.Parameters.AddWithValue("@State", state);

        con.Open();
        SqlDataReader reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            Console.WriteLine($"{reader["FirstName"]} {reader["LastName"]} | {Name}");
        }
    }
}


        // Returns total contacts in a city
       public int GetCountByCity(string city)
{
    using (SqlConnection con = new SqlConnection(connectionString))
    {
        string query = "SELECT COUNT(*) FROM Contacts WHERE City=@City";

        SqlCommand cmd = new SqlCommand(query, con);
        cmd.Parameters.AddWithValue("@City", city);

        con.Open();
        return (int)cmd.ExecuteScalar();
    }
}


        // Returns total contacts in a state
      public int GetCountByState(string state)
{
    using (SqlConnection con = new SqlConnection(connectionString))
    {
        string query = "SELECT COUNT(*) FROM Contacts WHERE State=@State";

        SqlCommand cmd = new SqlCommand(query, con);
        cmd.Parameters.AddWithValue("@State", state);

        con.Open();
        return (int)cmd.ExecuteScalar();
    }
}


        // Displays all contacts in this book
       public void DisplayAllContacts()
{
    using (SqlConnection con = new SqlConnection(connectionString))
    {
        string query = "SELECT * FROM Contacts WHERE AddressBookId=@AddressBookId";
        SqlCommand cmd = new SqlCommand(query, con);
        cmd.Parameters.AddWithValue("@AddressBookId", AddressBookId);


        con.Open();
        SqlDataReader reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            Console.WriteLine(
                $"{reader["ContactId"]} | " +
                $"{reader["FirstName"]} {reader["LastName"]} | " +
                $"{reader["City"]} | {reader["State"]} | " +
                $"{reader["PhoneNumber"]}");
        }
    }
}

        
    }
}
