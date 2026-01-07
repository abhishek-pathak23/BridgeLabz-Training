namespace EmployeeWage;
using System;

public sealed class EmployeeMenu
{
    private readonly IEmployee employeeUtility;

    public EmployeeMenu(IEmployee employeeUtility)
    {
        this.employeeUtility = employeeUtility;
    }

    public void DisplayMenu()
    {
        int choice;
        do
        {
            Console.WriteLine("\n----- Employee Wage Menu -----");
            Console.WriteLine("1. Check Attendance");
            Console.WriteLine("0. Exit");
            Console.Write("Enter choice: ");

            choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    employeeUtility.CheckAttendance();
                    break;
                
            }

        } while (choice != 0);
    }
}
