using System;

// Interface defining a contract for workers
interface Worker
{
    // Method that must be implemented by any class implementing Worker
    void PerformDuties();
}

// Base class Person
class Person
{
    // Common attributes
    public string Name;
    public int Id;
}

// Chef class inherits from Person and implements Worker interface
class Chef : Person, Worker
{
    // Implementation of PerformDuties() from Worker interface
    public void PerformDuties()
    {
        Console.WriteLine("Chef prepares food");
    }
}

// Main class
class RestaurantManagement
{
    static void Main()
    {
        // Create object of Chef class
        Chef c = new Chef();

        // Take Name input from user
        Console.Write("Enter Name: ");
        c.Name = Console.ReadLine();

        // Take ID input from user
        Console.Write("Enter ID: ");
        c.Id = int.Parse(Console.ReadLine());

        // Call method from Worker interface
        c.PerformDuties();
    }
}
