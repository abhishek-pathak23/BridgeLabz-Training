using System;
using System.IO;
using System.Linq;
using System.Globalization;

class Problem7_SortCSV
{
    static void Main()
    {
        string filePath = "employees.csv";

        if (!File.Exists(filePath))
        {
            Console.WriteLine("File not found: " + filePath);
            return;
        }

        var lines = File.ReadAllLines(filePath).Skip(1)
            .Select(line =>
            {
                var cols = line.Split(',');
                return new
                {
                    ID = cols[0],
                    Name = cols[1],
                    Department = cols[2],
                    Salary = double.Parse(cols[3], CultureInfo.InvariantCulture)
                };
            })
            .OrderByDescending(emp => emp.Salary)
            .Take(5)
            .ToList();

        Console.WriteLine("Top 5 highest-paid employees:");
        Console.WriteLine("ID\tName\tDepartment\tSalary");

        foreach (var emp in lines)
        {
            Console.WriteLine($"{emp.ID}\t{emp.Name}\t{emp.Department}\t{emp.Salary}");
        }
    }
}