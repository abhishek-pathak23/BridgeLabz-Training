using System;

class AccessModifiers
{
    // PUBLIC
    public int employeeId = 101;

    // PRIVATE
    private double basicSalary = 25000;

    // PROTECTED 
    protected string department = "IT";

    // INTERNAL
    internal int employeeAge = 22;

    // PROTECTED INTERNAL
    protected internal int experienceInYears = 2;

    // PRIVATE PROTECTED
    private protected string designation = "Trainee";

    // Method to access private member
    public void ShowSalary()
    {
        Console.WriteLine("Salary: " + basicSalary);
    }
}

class EmployeeDetails : AccessModifiers
{
    // Accessing inherited members
    public void DisplayEmployeeDetails()
    {
        Console.WriteLine("Department: " + department);
        Console.WriteLine("Experience: " + experienceInYears + " years");
        Console.WriteLine("Designation: " + designation);
    }
}

class Program
{
    static void Main()
    {
        AccessModifiers emp = new AccessModifiers();
        EmployeeDetails details = new EmployeeDetails();

        // Public access
        Console.WriteLine("Employee ID: " + emp.employeeId);

        // Internal access
        Console.WriteLine("Employee Age: " + emp.employeeAge);

        // Protected internal access
        Console.WriteLine("Experience: " + emp.experienceInYears + " years");

        // Private access via method
        emp.ShowSalary();

        // Protected & private protected via derived class
        details.DisplayEmployeeDetails();
    }
}
