using System;
using System.Reflection;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

public class EventTracker : IScannerI
{
    private List<EventLog> events = new List<EventLog>();

    // Scan all classes and methods with [AuditTrail]
    public List<EventLog> ScanClasses()
    {
        events.Clear();
        var assembly = Assembly.GetExecutingAssembly();

        foreach (Type type in assembly.GetTypes())
        {
            foreach (MethodInfo method in type.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly))
            {
                var attr = method.GetCustomAttribute<AuditTrailAttribute>();
                if (attr != null)
                {
                    events.Add(new EventLog
                    {
                        ClassName = type.Name,
                        MethodName = method.Name,
                        Description = attr.Description,
                        Timestamp = DateTime.Now
                    });
                }
            }
        }

        Console.WriteLine($"\n[Scan Complete] Found {events.Count} audited methods.\n");
        return events;
    }

    // Generate JSON log file
    public void GenerateJSON(string filePath)
    {
        if (events.Count == 0)
        {
            Console.WriteLine("No events scanned. Please scan classes first.\n");
            return;
        }

        var options = new JsonSerializerOptions { WriteIndented = true };
        string json = JsonSerializer.Serialize(events, options);

        File.WriteAllText(filePath, json);
        Console.WriteLine($"JSON log generated at {filePath}\n");
    }

    // Show scanned events in console
    public void ShowEvents()
    {
        if (events.Count == 0)
        {
            Console.WriteLine("No events scanned.\n");
            return;
        }

        Console.WriteLine("\n--- Audited Methods ---");
        foreach (var e in events)
        {
            Console.WriteLine(e);
        }
        Console.WriteLine();
    }
}
