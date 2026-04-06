namespace EmployeeWage;
using System;
class EmployeeMain{
static void Main(){
Console.WriteLine("Welcome to Employee Wage Computation Program");

Console.Write("Enter Employee ID: ");
int empId = Convert.ToInt32(Console.ReadLine());

Console.Write("Enter Employee Name: ");
string empName = Console.ReadLine()?? "";

Employee employee = new Employee(empId, empName);
IEmployee utility = new EmployeeUtilityImpl(employee);

EmployeeMenu menu = new EmployeeMenu(utility);
menu.DisplayMenu();

Console.WriteLine("Thank You");
}}
