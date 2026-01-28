using System;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;

class Student
{
    public int ID;
    public string Name;
    public int Age;
}

class Problem14_JSONCSV
{
    static void Main()
    {
        // JSON to CSV
        string jsonFile = "students.json";
        string csvFile = "students.csv";

        var json = File.ReadAllText(jsonFile);
        var students = JsonConvert.DeserializeObject<List<Student>>(json);

        using (var writer = new StreamWriter(csvFile))
        {
            writer.WriteLine("ID,Name,Age");
            foreach (var s in students)
                writer.WriteLine($"{s.ID},{s.Name},{s.Age}");
        }

        Console.WriteLine("CSV file created from JSON.");

        // CSV to JSON
        var lines = File.ReadAllLines(csvFile).Skip(1);
        var list = new List<Student>();
        foreach (var line in lines)
        {
            var cols = line.Split(',');
            list.Add(new Student { ID = int.Parse(cols[0]), Name = cols[1], Age = int.Parse(cols[2]) });
        }

        string jsonOutput = JsonConvert.SerializeObject(list, Formatting.Indented);
        File.WriteAllText("students_from_csv.json", jsonOutput);
        Console.WriteLine("JSON file created from CSV.");
    }
}