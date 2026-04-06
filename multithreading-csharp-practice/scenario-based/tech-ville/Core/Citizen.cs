using System;
using System.Text.Json.Serialization;

public class Citizen : IComparable<Citizen>
{
    private int id;
    private string name;
    private int age;
    private double income;
    private string email;
    private string phone;

    [JsonIgnore]
    private string password;

    public int Id
    {
        get { return id; }
        set { id = value; }
    }

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public int Age
    {
        get { return age; }
        set { age = value; }
    }

    public double Income
    {
        get { return income; }
        set { income = value; }
    }

    public string Email
    {
        get { return email; }
        set { email = value; }
    }

    public string Phone
    {
        get { return phone; }
        set { phone = value; }
    }

    [JsonIgnore]
    public string Password
    {
        get { return password; }
        set { password = value; }
    }

    // REQUIRED for JSON deserialization
    public Citizen() { }

    public Citizen(int id, string name, int age, double income, string email, string phone)
    {
        this.id = id;
        this.name = name;
        this.age = age;
        this.income = income;
        this.email = email;
        this.phone = phone;
    }

    public override string ToString()
    {
        return $"ID: {id}, Name: {name}, Age: {age}, Income: {income}, Email: {email}, Phone: {phone}";
    }

    public int CompareTo(Citizen other)
    {
        return this.id.CompareTo(other.id);
    }
}
