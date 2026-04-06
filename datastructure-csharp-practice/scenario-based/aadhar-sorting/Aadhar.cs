using System;

public class Aadhar
{
    // Private fields to store Aadhar details
    private long AadharNumber;
    private string Name;
    private int Age;
    private string DOB;

    // Constructor to initialize Aadhar object
    public Aadhar(long aadharnum, string name, int age, string dob)
    {
        AadharNumber = aadharnum;
        Name = name;
        Age = age;
        DOB = dob;
    }

    // Getter and Setter for AadharNumber
    public long GetAadharNumber()
    {
        return AadharNumber;
    }
    public void SetAadharNumber(long aadharnum)
    {
        AadharNumber = aadharnum;
    }

    // Getter and Setter for Name
    public string GetName()
    {
        return Name;
    }
    public void SetName(string name)
    {
        Name = name;
    }

    // Getter and Setter for Age
    public int GetAge()
    {
        return Age;
    }
    public void SetAge(int age)
    {
        Age = age;
    }

    // Getter and Setter for DOB
    public string GetDOB()
    {
        return DOB;
    }
    public void SetDOB(string dob)
    {
        DOB = dob;
    }

    // Returns string representation of Aadhar object
    public override string ToString()
    {
        return "Aadhar: " + AadharNumber +
               ", Name: " + Name +
               ", Age: " + Age +
               ", DOB: " + DOB;
    }
}
