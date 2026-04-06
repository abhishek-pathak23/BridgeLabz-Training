using System;
using System.IO;
using System.Linq;

class Problem5_SearchCSV
{
    static void Main()
    {
        string filePath = "employees.csv";

        if (!File.Exists(filePath))
        {
            Console.WriteLine("File not found: " + filePath);
            return;
        }

        Console.Write("Enter employee name to search: ");
        string searchName = Console.ReadLine();

        var lines = File.ReadAllLines(filePath);
        bool found = false;

        foreach (var line in lines.Skip(1))
        {
            var cols = line.Split(',');
            if (cols[1].Equals(searchName, StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine($"Name: {cols[1]}, Department: {cols[2]}, Salary: {cols[3]}");
                found = true;
                break;
            }
        }

        if (!found)
            Console.WriteLine("Employee not found.");
    }
}