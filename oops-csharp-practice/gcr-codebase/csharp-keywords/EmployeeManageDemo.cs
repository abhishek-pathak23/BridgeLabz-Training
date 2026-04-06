using System;

class Employee
{
    // Static variable shared across all Employee objects
    // Stores the company name
    public static string CompanyName;

    // Private static variable to keep track of total employees created
    private static int count = 0;

    // Public instance variable to store employee name
    public string Name;

    // Readonly variable: employee ID cannot be changed after initialization
    public readonly int Id;

    // Public instance variable to store employee designation
    public string Designation;

    // Constructor to initialize employee details
    public Employee(string name, int id, string desig)
    {
        // Assign constructor parameters to class variables
        this.Name = name;
        this.Id = id;
        this.Designation = desig;

        // Increment employee count whenever a new object is created
        count++;
    }

    // Static method to display total number of employees
    // Can be accessed using the class name without creating an object
    public static void DisplayTotalEmployees()
    {
        Console.WriteLine("Total Employees: " + count);
    }

    // Instance method to display employee details
    public void Show()
    {
        Console.WriteLine(Name + " - " + Designation);
    }
}

class EmployeeManageDemo
{
    // Main method: program execution starts here
    static void Main()
    {
        // Initialize static company name
        Employee.CompanyName = "Tech Corp";

        // Read employee name from user
        Console.Write("Name: ");
        string n = Console.ReadLine();

        // Read employee ID and convert input to integer
        Console.Write("ID: ");
        int id = int.Parse(Console.ReadLine());

        // Read employee designation from user
        Console.Write("Designation: ");
        string d = Console.ReadLine();

        // Create Employee object and store it as object type (upcasting)
        object emp = new Employee(n, id, d);

        // Check type safely using 'is' operator
        if (emp is Employee)
        {
            // Downcast object back to Employee to access instance methods
            ((Employee)emp).Show();
        }

        // Call static method to display total employees
        Employee.DisplayTotalEmployees();
    }
}
