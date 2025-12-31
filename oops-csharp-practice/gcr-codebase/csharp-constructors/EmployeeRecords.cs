using System;

class Employee
{
    // Accessible everywhere
    public int employeeID;

    // Accessible in this class and child classes
    protected string department;

    // Accessible only inside this class
    private double salary;

    // Constructor to initialize employee details
    public Employee(int id, string dept)
    {
        employeeID = id;
        department = dept;
    }

    // Method to update salary
    public void UpdateSalary(double amount)
    {
        salary = amount;
    }

    // Method to return salary
    public double GetSalary()
    {
        return salary;
    }
}

// Child class
class Manager : Employee
{
    // Calling base class constructor
    public Manager(int id, string dept)
        : base(id, dept)
    {
    }

    // Display employee details
    public void DisplayDetails()
    {
        Console.WriteLine("\nEmployee Details");
        Console.WriteLine("Employee ID : " + employeeID);   // public
        Console.WriteLine("Department  : " + department);   // protected
    }
}

class EmployeeRecords
{
    static void Main()
    {
        // Taking input from user
        Console.Write("Enter Employee ID: ");
        int id = int.Parse(Console.ReadLine());

        Console.Write("Enter Department: ");
        string dept = Console.ReadLine();

        Console.Write("Enter Salary: ");
        double salary = double.Parse(Console.ReadLine());

        // Creating object of child class
        Manager manager = new Manager(id, dept);

        // Updating salary using public method
        manager.UpdateSalary(salary);

        // Displaying employee information
        manager.DisplayDetails();
        Console.WriteLine("Salary      : " + manager.GetSalary());
    }
}
