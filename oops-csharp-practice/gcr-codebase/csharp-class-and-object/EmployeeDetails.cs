using System;   


class EmployeeDetails
{
    // Instance variables to store employee data
    string name;
    int id;
    double salary;

    // Method to display employee details
    void DisplayDetails()
    {
        Console.WriteLine("\nEmployee Details:");
        Console.WriteLine("Name: " + name);
        Console.WriteLine("ID: " + id);
        Console.WriteLine("Salary: " + salary);
    }

    // Main method: program execution starts here
    static void Main()
    {
        // Creating an object of EmployeeDetails class
        EmployeeDetails emp = new EmployeeDetails();

        // Taking input from user
        Console.Write("Enter Employee Name: ");
        emp.name = Console.ReadLine();

        Console.Write("Enter Employee ID: ");
        emp.id = int.Parse(Console.ReadLine());

        Console.Write("Enter Employee Salary: ");
        emp.salary = double.Parse(Console.ReadLine());

        // Displaying employee details
        emp.DisplayDetails();
    }
}
