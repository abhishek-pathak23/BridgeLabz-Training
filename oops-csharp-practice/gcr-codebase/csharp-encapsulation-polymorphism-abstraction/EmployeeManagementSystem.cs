using System;
using System.Collections.Generic;

// Interface for department-related behavior
interface IDepartment
{
    void AssignDepartment(string deptName);
    string GetDepartmentDetails();
}

// Abstract base class
abstract class Employee
{
    private int employeeId;
    private string name;
    private double baseSalary;
    protected string department;

    public int EmployeeId
    {
        get { return employeeId; }
        set { employeeId = value; }
    }

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public double BaseSalary
    {
        get { return baseSalary; }
        set
        {
            if (value > 0)
                baseSalary = value;
        }
    }

    public abstract double CalculateSalary();

    public void DisplayDetails()
    {
        Console.WriteLine($"ID: {EmployeeId}, Name: {Name}, Dept: {department}, Salary: {CalculateSalary()}");
    }
}

// Full-time employee
class FullTimeEmployee : Employee, IDepartment
{
    public override double CalculateSalary()
    {
        return BaseSalary;
    }

    public void AssignDepartment(string deptName)
    {
        department = deptName;
    }

    public string GetDepartmentDetails()
    {
        return department;
    }
}

// Part-time employee
class PartTimeEmployee : Employee, IDepartment
{
    private int hoursWorked;

    public int HoursWorked
    {
        get { return hoursWorked; }
        set { hoursWorked = value; }
    }

    public override double CalculateSalary()
    {
        return HoursWorked * BaseSalary;
    }

    public void AssignDepartment(string deptName)
    {
        department = deptName;
    }

    public string GetDepartmentDetails()
    {
        return department;
    }
}

class EmployeeManagementSystem
{
    static void Main()
    {
        List<Employee> employees = new List<Employee>();

        Console.Write("Enter Full-Time Employee ID: ");
        FullTimeEmployee fte = new FullTimeEmployee();
        fte.EmployeeId = int.Parse(Console.ReadLine());

        Console.Write("Enter Name: ");
        fte.Name = Console.ReadLine();

        Console.Write("Enter Salary: ");
        fte.BaseSalary = double.Parse(Console.ReadLine());

        Console.Write("Enter Department: ");
        fte.AssignDepartment(Console.ReadLine());

        employees.Add(fte);

        Console.WriteLine("\nEmployee Details:");
        foreach (Employee emp in employees)
        {
            emp.DisplayDetails(); // Polymorphism
        }
    }
}
