using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

class Problem12_DetectDuplicatesCSV
{
    static void Main()
    {
        string filePath = "students.csv";

        if (!File.Exists(filePath))
        {
            Console.WriteLine("File not found: " + filePath);
            return;
        }

        var lines = File.ReadAllLines(filePath).Skip(1);
        var duplicates = lines
            .GroupBy(l => l.Split(',')[0]) // group by ID
            .Where(g => g.Count() > 1);

        Console.WriteLine("Duplicate records:");
        foreach (var group in duplicates)
        {
            foreach (var record in group)
                Console.WriteLine(record);
        }
    }
}