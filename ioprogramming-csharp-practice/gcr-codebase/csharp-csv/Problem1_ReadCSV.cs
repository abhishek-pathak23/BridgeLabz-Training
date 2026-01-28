using System;
using System.IO;
using System.Linq;

class Problem1_ReadCSV
{
    static void Main()
    {
        string filePath = "students.csv";

        if (!File.Exists(filePath))
        {
            Console.WriteLine("File not found: " + filePath);
            return;
        }

        var lines = File.ReadAllLines(filePath);

        Console.WriteLine("ID\tName\tAge\tMarks");

        foreach (var line in lines.Skip(1))
        {
            var cols = line.Split(',');
            Console.WriteLine($"{cols[0]}\t{cols[1]}\t{cols[2]}\t{cols[3]}");
        }
    }
}