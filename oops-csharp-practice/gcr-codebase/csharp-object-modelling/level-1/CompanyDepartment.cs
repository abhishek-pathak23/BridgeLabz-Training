using System;
using System.Collections.Generic;

namespace CompanyManagement
{
    // Employee class represents an employee
    class Employee
    {
        public string Name { get; set; }
        public Employee(string name) { Name = name; }
        public void ShowEmployee() => Console.WriteLine($"Employee: {Name}");
    }

    // Department class represents a department containing employees
    class Department
    {
        public string Name { get; set; }
        public List<Employee> Employees { get; set; }

        public Department(string name)
        {
            Name = name;
            Employees = new List<Employee>();
        }

        public void AddEmployee(Employee emp)
        {
            Employees.Add(emp);
            Console.WriteLine($"Employee '{emp.Name}' added to {Name} department.");
        }

        public void ShowEmployees()
        {
            Console.WriteLine($"\nEmployees in {Name} Department:");
            foreach (var emp in Employees) emp.ShowEmployee();
        }
    }

    // Company class composes departments
    class Company
    {
        public string Name { get; set; }
        public List<Department> Departments { get; set; }

        public Company(string name)
        {
            Name = name;
            Departments = new List<Department>();
        }

        public void AddDepartment(Department dept)
        {
            Departments.Add(dept);
            Console.WriteLine($"Department '{dept.Name}' added to {Name}.");
        }

        public void ShowCompany()
        {
            Console.WriteLine($"\nCompany: {Name}");
            foreach (var dept in Departments)
            {
                dept.ShowEmployees();
            }
        }
    }

    class CompanyDepartment
    {
        static void Main()
        {
            Console.WriteLine("Enter Company Name:");
            string companyName = Console.ReadLine();
            Company company = new Company(companyName);

            Console.WriteLine("Enter number of departments:");
            int numDepts = int.Parse(Console.ReadLine());

            for (int i = 0; i < numDepts; i++)
            {
                Console.WriteLine($"\nEnter Department {i + 1} Name:");
                string deptName = Console.ReadLine();
                Department dept = new Department(deptName);

                Console.WriteLine($"Enter number of employees in {deptName}:");
                int numEmp = int.Parse(Console.ReadLine());
                for (int j = 0; j < numEmp; j++)
                {
                    Console.WriteLine($"Enter name of Employee {j + 1}:");
                    string empName = Console.ReadLine();
                    dept.AddEmployee(new Employee(empName));
                }

                company.AddDepartment(dept);
            }

            company.ShowCompany();
        }
    }
}
