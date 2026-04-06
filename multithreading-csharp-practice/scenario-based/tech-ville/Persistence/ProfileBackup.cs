using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

public class ProfileBackup
{
    private readonly string filePath = "citizens_backup.json";

    public void Save(List<Citizen> citizens)
    {
        var options = new JsonSerializerOptions
        {
            WriteIndented = true
        };

        string json = JsonSerializer.Serialize(citizens, options);
        File.WriteAllText(filePath, json);

        Console.WriteLine("Backup saved to JSON.");
    }

    public List<Citizen> Load()
    {
        if (!File.Exists(filePath))
        {
            Console.WriteLine("No backup file found.");
            return new List<Citizen>();
        }

        string json = File.ReadAllText(filePath);
        return JsonSerializer.Deserialize<List<Citizen>>(json)
               ?? new List<Citizen>();
    }
}
