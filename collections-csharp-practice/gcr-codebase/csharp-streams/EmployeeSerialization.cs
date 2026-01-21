using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

class Employee
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Department { get; set; }
    public double Salary { get; set; }
}

class EmployeeSerialization
{
    static void Main()
    {
        List<Employee> employees = new List<Employee>();

        Console.Write("How many employees do you want to enter? ");
        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"\nEnter details for Employee {i + 1}:");

            Console.Write("Id: ");
            int id = int.Parse(Console.ReadLine());

            Console.Write("Name: ");
            string name = Console.ReadLine();

            Console.Write("Department: ");
            string dept = Console.ReadLine();

            Console.Write("Salary: ");
            double salary = double.Parse(Console.ReadLine());

            employees.Add(new Employee
            {
                Id = id,
                Name = name,
                Department = dept,
                Salary = salary
            });
        }

        try
        {
            // Serialize to JSON and save to file
            string json = JsonSerializer.Serialize(employees, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText("employees.json", json);

            Console.WriteLine("\nData saved successfully to employees.json\n");

            // Read from file and deserialize
            string readJson = File.ReadAllText("employees.json");
            List<Employee> data = JsonSerializer.Deserialize<List<Employee>>(readJson);

            Console.WriteLine("Employees from JSON file:");
            foreach (var e in data)
                Console.WriteLine($"{e.Id} {e.Name} {e.Department} {e.Salary}");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
