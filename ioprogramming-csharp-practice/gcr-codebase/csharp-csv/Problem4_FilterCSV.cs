using System;
using System.IO;
using System.Linq;

class Problem4_FilterCSV
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
        Console.WriteLine("Students with Marks > 80:");
        Console.WriteLine("ID\tName\tAge\tMarks");

        foreach (var line in lines.Skip(1))
        {
            var cols = line.Split(',');
            int marks = int.Parse(cols[3]);
            if (marks > 80)
            {
                Console.WriteLine($"{cols[0]}\t{cols[1]}\t{cols[2]}\t{cols[3]}");
            }
        }
    }
}