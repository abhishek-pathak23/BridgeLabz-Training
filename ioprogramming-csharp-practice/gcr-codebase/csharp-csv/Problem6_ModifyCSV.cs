using System;
using System.IO;
using System.Linq;
using System.Globalization;

class Problem6_ModifyCSV
{
    static void Main()
    {
        string inputFile = "employees.csv";
        string outputFile = "employees_updated.csv";

        if (!File.Exists(inputFile))
        {
            Console.WriteLine("File not found: " + inputFile);
            return;
        }

        var lines = File.ReadAllLines(inputFile).ToList();
        var header = lines[0];
        var updatedLines = lines.Take(1).ToList(); // include header

        foreach (var line in lines.Skip(1))
        {
            var cols = line.Split(',');
            string department = cols[2];
            double salary = double.Parse(cols[3], CultureInfo.InvariantCulture);

            if (department.Equals("IT", StringComparison.OrdinalIgnoreCase))
            {
                salary = salary * 1.10; // increase by 10%
            }

            updatedLines.Add($"{cols[0]},{cols[1]},{cols[2]},{salary}");
        }

        File.WriteAllLines(outputFile, updatedLines);
        Console.WriteLine("Updated CSV saved as: " + outputFile);
    }
}