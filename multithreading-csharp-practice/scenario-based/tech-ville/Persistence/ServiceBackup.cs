using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

public class ServiceBackup
{
    private readonly string filePath = "services_backup.json";

    public void Save(List<Service> services)
    {
        string json = JsonSerializer.Serialize(services, new JsonSerializerOptions
        {
            WriteIndented = true
        });

        File.WriteAllText(filePath, json);
    }

    public List<Service> Load()
    {
        if (!File.Exists(filePath))
            return new List<Service>();

        string json = File.ReadAllText(filePath);
        return JsonSerializer.Deserialize<List<Service>>(json)
               ?? new List<Service>();
    }
}
