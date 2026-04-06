using System;
using System.Collections.Generic;
using System.Threading;
using System.Data;
using System.Data.SqlClient;
namespace PayrollService
{
    class Program
    {
        static void Main(string[] args)
        {
            IEmployeePayrollService payrollService = new EmployeePayrollService();
            List<Employee> employees = new List<Employee>();

            while (true)
            {
                Console.WriteLine("\n====== Employee Payroll Menu ======");
                Console.WriteLine("1. Add Single Employee");
                Console.WriteLine("2. Add Multiple Employees with Threads");
                Console.WriteLine("3. Add Employee with Payroll Details");
                Console.WriteLine("4. Update Employee Salary");
                Console.WriteLine("5. Exit");
                Console.Write("Select Option: ");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.Write("Enter Name: ");
                        string name1 = Console.ReadLine();
                        Console.Write("Enter Salary: ");
                        double salary1 = double.Parse(Console.ReadLine());
                        payrollService.AddEmployee(new Employee(name1, salary1));
                        break;

                    case 2:
                        Console.Write("Enter number of employees: ");
                        int n = int.Parse(Console.ReadLine());
                        employees.Clear();
                        for (int i = 0; i < n; i++)
                        {
                            Console.Write($"Enter Name for Employee {i + 1}: ");
                            string name2 = Console.ReadLine();
                            Console.Write($"Enter Salary: ");
                            double salary2 = double.Parse(Console.ReadLine());
                            employees.Add(new Employee(name2, salary2));
                        }
                        payrollService.AddEmployeesWithThreads(employees);
                        break;

                    case 3:
                        Console.Write("Enter Name: ");
                        string name3 = Console.ReadLine();
                        Console.Write("Enter Salary: ");
                        double salary3 = double.Parse(Console.ReadLine());
                        payrollService.AddEmployeeWithDetails(new Employee(name3, salary3));
                        break;

                    case 4:
                        Console.Write("Enter Name: ");
                        string name4 = Console.ReadLine();
                        Console.Write("Enter Updated Salary: ");
                        double salary4 = double.Parse(Console.ReadLine());
                        payrollService.UpdateEmployeeSalary(new Employee(name4, salary4));
                        break;

                    case 5:
                        return;

                    default:
                        Console.WriteLine("Invalid Option!");
                        break;
                }
            }
        }
    }
}
