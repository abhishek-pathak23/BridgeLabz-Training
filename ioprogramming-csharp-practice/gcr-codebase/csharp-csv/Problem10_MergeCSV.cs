using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

class Problem10_MergeCSV
{
    static void Main()
    {
        string file1 = "students1.csv";
        string file2 = "students2.csv";
        string outputFile = "merged_students.csv";

        var data1 = File.ReadAllLines(file1).Skip(1)
            .Select(l => l.Split(','))
            .ToDictionary(a => a[0], a => new { Name = a[1], Age = a[2] });

        var data2 = File.ReadAllLines(file2).Skip(1)
            .Select(l => l.Split(','))
            .ToDictionary(a => a[0], a => new { Marks = a[1], Grade = a[2] });

        List<string> merged = new List<string> { "ID,Name,Age,Marks,Grade" };

        foreach (var id in data1.Keys)
        {
            if (data2.ContainsKey(id))
            {
                merged.Add($"{id},{data1[id].Name},{data1[id].Age},{data2[id].Marks},{data2[id].Grade}");
            }
        }

        File.WriteAllLines(outputFile, merged);
        Console.WriteLine("Merged CSV created: " + outputFile);
    }
}