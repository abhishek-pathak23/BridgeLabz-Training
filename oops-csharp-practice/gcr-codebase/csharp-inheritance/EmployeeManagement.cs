using System;

// Base class Employee
class Employee
{
    // Employee name
    public string Name;

    // Employee ID
    public int Id;

    // Employee salary
    public double Salary;

    // Virtual method to display employee details
    public virtual void DisplayDetails()
    {
        Console.WriteLine($"Name: {Name}, ID: {Id}, Salary: {Salary}");
    }
}

// Derived class Manager inherits from Employee
class Manager : Employee
{
    // Number of team members managed
    public int TeamSize;

    // Overriding DisplayDetails method
    public override void DisplayDetails()
    {
        // Call base class method
        base.DisplayDetails();

        // Display manager-specific details
        Console.WriteLine($"Team Size: {TeamSize}");
    }
}

// Main class
class EmployeeManagement
{
    static void Main()
    {
        // Create Manager object
        Manager m = new Manager();

        // Take name input from user
        Console.Write("Enter Name: ");
        m.Name = Console.ReadLine();

        // Take ID input from user
        Console.Write("Enter ID: ");
        m.Id = int.Parse(Console.ReadLine());

        // Take salary input from user
        Console.Write("Enter Salary: ");
        m.Salary = double.Parse(Console.ReadLine());

        // Take team size input from user
        Console.Write("Enter Team Size: ");
        m.TeamSize = int.Parse(Console.ReadLine());

        // Display all details
        m.DisplayDetails();
    }
}
